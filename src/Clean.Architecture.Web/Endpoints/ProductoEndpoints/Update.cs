using Ardalis.ApiEndpoints;
using Clean.Architecture.Core.Productos.Entities;
using Clean.Architecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Clean.Architecture.Web.Endpoints.ProductoEndpoints;

public class Update : EndpointBaseAsync
    .WithRequest<UpdateProductoRequest>
    .WithActionResult<UpdateProductoResponse>
{
  private readonly IRepository<Producto> _repository;

  public Update(IRepository<Producto> repository)
  {
    _repository = repository;
  }

  [HttpPut(UpdateProductoRequest.Route)]
  [SwaggerOperation(
      Summary = "Actualiza un producto",
      Description = "Actualiza un producto",
      OperationId = "Productos.Update",
      Tags = new[] { "ProductoEndpoints" })
  ]
  public override async Task<ActionResult<UpdateProductoResponse>> HandleAsync(
    UpdateProductoRequest request,
      CancellationToken cancellationToken = new ())
  {
    if (request.Nombre == null || request.Descripcion == null || request.Categoria == null)
    {
      return BadRequest();
    }

    var existingProject = await _repository.GetByIdAsync(request.Id, cancellationToken);
    if (existingProject == null)
    {
      return NotFound();
    }

    existingProject.UpdateNombre(request.Nombre);
    existingProject.UpdateDescripcion(request.Descripcion);
    existingProject.UpdateCategoria(request.Categoria);
    existingProject.UpdateImagen(request.Imagen);

    await _repository.UpdateAsync(existingProject, cancellationToken);

    var response = new UpdateProductoResponse(
        project: new ProductoRecord(existingProject.Id, existingProject.Nombre,existingProject.Descripcion,existingProject.Categoria,existingProject.Imagen)
    );

    return Ok(response);
  }
}
