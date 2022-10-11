using Ardalis.Specification;
using Clean.Architecture.SharedKernel.Entities;

namespace Clean.Architecture.Core.Productos.Specifications;

public class ProductoByIdWithItemsSpec : Specification<Producto>, ISingleResultSpecification
{
  public ProductoByIdWithItemsSpec(int productoId)
  {
    Query
        .Where(item => item.Id == productoId);
        //.Include(project => project.Items);
  }
}
