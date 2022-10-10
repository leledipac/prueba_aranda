using Ardalis.ApiEndpoints;
using Clean.Architecture.Core.Productos.Entities;
using Clean.Architecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Clean.Architecture.Web.Endpoints.ProductoEndpoints;

public class Create : EndpointBaseAsync
  .WithRequest<CreateProductoRequest>
  .WithActionResult<CreateProductoResponse>
{
  private readonly IRepository<Producto> _repository;

  public Create(IRepository<Producto> repository)
  {
    _repository = repository;
  }

  [HttpPost("/Productos")]
  [SwaggerOperation(
    Summary = "Crea un nuevo producto",
    Description = "Crea un nuevo producto",
    OperationId = "Productos.Create",
    Tags = new[] { "ProductoEndpoints" })
  ]
  public override async Task<ActionResult<CreateProductoResponse>> HandleAsync(
    CreateProductoRequest request,
    CancellationToken cancellationToken = new())
  {
    if (request.Nombre == null || request.Descripcion == null || request.Categoria == null || request.Imagen == null)
    {
      return BadRequest();
    }

    var newProduct = new Producto(string.IsNullOrEmpty(request.Nombre) ? "" : request.Nombre, string.IsNullOrEmpty(request.Descripcion) ? "" : request.Descripcion, string.IsNullOrEmpty(request.Categoria) ? "" : request.Categoria, request.Imagen);
    var createdItem = await _repository.AddAsync(newProduct, cancellationToken);
    var response = new CreateProductoResponse
    (
      id: createdItem.Id,
      nombre: createdItem.Nombre,
      descripcion: createdItem.Descripcion,
      categoria: createdItem.Categoria,
      imagen: createdItem.Imagen
    );

    return Ok(response);
  }
}
