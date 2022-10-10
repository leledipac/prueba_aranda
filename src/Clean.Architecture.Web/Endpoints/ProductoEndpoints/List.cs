using Ardalis.ApiEndpoints;
using Clean.Architecture.Core.Productos.Entities;
using Clean.Architecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Clean.Architecture.Web.Endpoints.ProductoEndpoints;

public class List : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<ProductoListResponse>
{
  private readonly IReadRepository<Producto> _repository;

  public List(IReadRepository<Producto> repository)
  {
    _repository = repository;
  }

  [HttpGet("/Productos")]
  [SwaggerOperation(
      Summary = "Obtiene una lista de todos los productos",
      Description = "Obtiene una lista de todos los productos",
      OperationId = "Productos.List",
      Tags = new[] { "ProductoEndpoints" })
  ]
  public override async Task<ActionResult<ProductoListResponse>> HandleAsync(
    CancellationToken cancellationToken = new())
  {
    var projects = await _repository.ListAsync(cancellationToken);
    var response = new ProductoListResponse
    {
      Productos = projects
        .Select(item => new ProductoRecord(item.Id, item.Nombre, item.Descripcion, item.Categoria, item.Imagen))
        .ToList()
    };

    return Ok(response);
  }
}
