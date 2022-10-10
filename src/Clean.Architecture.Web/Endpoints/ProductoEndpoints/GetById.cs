using Ardalis.ApiEndpoints;
using Clean.Architecture.Core.Productos.Entities;
using Clean.Architecture.Core.Productos.Specifications;
using Clean.Architecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Clean.Architecture.Web.Endpoints.ProductoEndpoints;

public class GetById : EndpointBaseAsync
  .WithRequest<GetProductoByIdRequest>
  .WithActionResult<GetProductoByIdResponse>
{
  private readonly IRepository<Producto> _repository;

  public GetById(IRepository<Producto> repository)
  {
    _repository = repository;
  }

  [HttpGet(GetProductoByIdRequest.Route)]
  [SwaggerOperation(
    Summary = "Gets a single Project",
    Description = "Gets a single Project by Id",
    OperationId = "Productos.GetById",
    Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<GetProductoByIdResponse>> HandleAsync(
    [FromRoute] GetProductoByIdRequest request,
    CancellationToken cancellationToken = new())
  {
    var spec = new ProductoByIdWithItemsSpec(request.ProductoId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }

    var response = new GetProductoByIdResponse
    (
      id: entity.Id,
      nombre: entity.Nombre,
      descripcion: entity.Descripcion,
      categoria: entity.Categoria,
      imagen: entity.Imagen
    );

    return Ok(response);
  }
}
