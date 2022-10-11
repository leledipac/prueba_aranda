using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Clean.Architecture.SharedKernel.Entities;
using Clean.Architecture.SharedKernel.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Repositorio;
public class RepositorioProducto : RepositoryBase<Producto>, IRepositorioProducto
{
  private readonly DbContext contexto;
  public RepositorioProducto(DbContext dbContext) : base(dbContext)
  {
    contexto = dbContext;
  }

  public RepositorioProducto(DbContext dbContext, ISpecificationEvaluator specificationEvaluator) : base(dbContext, specificationEvaluator)
  {
    contexto = dbContext;
  }


  public async Task<ProductoPag> GetProductos(string? nombre = null, string? descripcion = null, string? categoria = null, int pagina = 1, int registros = 100, bool ordenarCategoria = false)
  {
    var query = contexto.Set<Producto>();
    if (!string.IsNullOrEmpty(nombre))
    {
      query.Where(x => x.Nombre.Contains(nombre));
    }
    if (!string.IsNullOrEmpty(descripcion))
    {
      query.Where(x => x.Descripcion.Contains(descripcion));
    }
    if (!string.IsNullOrEmpty(categoria))
    {
      query.Where(x => x.Categoria.Contains(categoria));
    }
    if (ordenarCategoria)
    {
      query.OrderBy(x => x.Categoria);
    } else
    {
      query.OrderBy(x => x.Nombre);
    }
    int skip = 0;
    int take = registros;
    if (pagina > 1)
    {
      skip = (pagina - 1) * registros;
    }
    ProductoPag result = new ProductoPag(await query.Skip(skip).Take(take).ToListAsync(), await query.CountAsync(), pagina);
    return result;
  }
}
