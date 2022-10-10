using Clean.Architecture.Core.Productos.Entities;
using Clean.Architecture.SharedKernel;

namespace Clean.Architecture.Core.Productos.Events;

public class ProductoAddedEvent : DomainEventBase
{
  public Producto Producto { get; set; }

  public ProductoAddedEvent(Producto producto)
  {
    Producto = producto;
  }
}
