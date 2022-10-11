using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Clean.Architecture.SharedKernel.Entities;

namespace Clean.Architecture.SharedKernel.Repositorio;
public interface IRepositorioProducto : IRepositoryBase<Producto>
{
  Task<ProductoPag> GetProductos(string? nombre = null, string? descripcion = null, string? categoria = null, int pagina = 1, int registros = 100, bool ordenarCategoria = false);

}
