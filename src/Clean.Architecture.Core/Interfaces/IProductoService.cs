using Ardalis.Result;
using Clean.Architecture.Core.Productos.Entities;

namespace Clean.Architecture.Core.Interfaces;

public interface IProductoService
{
  Task<Result<Producto>> GetAsync(int productoId);
  Task<Result<List<Producto>>> GetAllAsync();
}
