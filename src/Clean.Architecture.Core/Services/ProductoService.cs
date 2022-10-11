using Ardalis.Result;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.Productos.Specifications;
using Clean.Architecture.SharedKernel.Interfaces;
using Clean.Architecture.SharedKernel.Entities;
using Clean.Architecture.SharedKernel.Repositorio;

namespace Clean.Architecture.Core.Services;

public class ProductoService : IProductoService
{
  private readonly IRepositorioProducto _repository;

  public ProductoService(IRepositorioProducto repository)
  {
    _repository = repository;
  }

  public async Task<Result<List<Producto>>> GetAllAsync()
  {
    var productos = await _repository.ListAsync();

    // TODO: Optionally use Ardalis.GuardClauses Guard.Against.NotFound and catch
    if (productos != null)
    {
      return Result<List<Producto>>.Success(productos);
    }

    return Result<List<Producto>>.NotFound();
  }
  public async Task<Result<Producto>> GetAsync(int productoId)
  {

    var productoSpec = new ProductoByIdWithItemsSpec(productoId);
    var producto = await _repository.FirstOrDefaultAsync(productoSpec);

    // TODO: Optionally use Ardalis.GuardClauses Guard.Against.NotFound and catch
    if (producto != null)
    {
      return Result<Producto>.Success(producto);
    }
    return Result<Producto>.NotFound();
  }
}
