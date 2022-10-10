using Ardalis.ApiEndpoints;
using Clean.Architecture.Core.Productos.Entities;
using Clean.Architecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Clean.Architecture.Web.Endpoints.ProductoEndpoints;

public class Delete : EndpointBaseAsync
    .WithRequest<DeleteProductoRequest>
    .WithoutResult
{
  private readonly IRepository<Producto> _repository;

  public Delete(IRepository<Producto> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeleteProductoRequest.Route)]
  [SwaggerOperation(
      Summary = "Elimina un producto",
      Description = "Elimina un producto",
      OperationId = "Productos.Delete",
      Tags = new[] { "ProductoEndpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(
    [FromRoute] DeleteProductoRequest request,
      CancellationToken cancellationToken = new())
  {
    var aggregateToDelete = await _repository.GetByIdAsync(request.ProductoId, cancellationToken);
    if (aggregateToDelete == null)
    {
      return NotFound();
    }

    await _repository.DeleteAsync(aggregateToDelete, cancellationToken);

    return NoContent();
  }
}
