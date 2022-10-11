using Clean.Architecture.SharedKernel;
using Clean.Architecture.SharedKernel.Entities;

namespace Clean.Architecture.Core.Productos.Events;

public class ProductoAddedEvent : DomainEventBase
{
  public Producto Producto { get; set; }

  public ProductoAddedEvent(Producto producto)
  {
    Producto = producto;
  }
}
