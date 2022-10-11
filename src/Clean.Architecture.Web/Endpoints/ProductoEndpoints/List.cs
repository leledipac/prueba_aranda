using Ardalis.ApiEndpoints;
using Ardalis.Specification;
using Clean.Architecture.SharedKernel.Entities;
using Clean.Architecture.SharedKernel.Interfaces;
using Clean.Architecture.SharedKernel.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Clean.Architecture.Web.Endpoints.ProductoEndpoints;

public class List : EndpointBaseAsync
    .WithRequest<ProductoListRequest>
    .WithActionResult<ProductoListResponse>
{
  private readonly IRepositorioProducto _repository;

  public List(IRepositorioProducto repository)
  {
    _repository = repository;
  }

  [HttpPost("/Productos/Consultar")]
  [SwaggerOperation(
      Summary = "Obtiene una lista de todos los productos",
      Description = "Obtiene una lista de todos los productos",
      OperationId = "Productos.List",
      Tags = new[] { "ProductoEndpoints" })
  ]
  public override async Task<ActionResult<ProductoListResponse>> HandleAsync(
    ProductoListRequest? request = null,  
    //string? nombre = null, string? descripcion = null, string? categoria = null, bool ordenarPorCategoria= false, int pagina = 1,
    CancellationToken cancellationToken = new())
  {
    var resultado = await _repository.GetProductos(request?.Nombre, request?.Descripcion, request?.Categoria, request?.Pagina ?? 1);
    var response = new ProductoListResponse
    {
      Pagina = resultado.Pagina,
      Total = resultado.Total,
      Productos = resultado.Productos
        .Select(item => new ProductoRecord(item.Id, item.Nombre, item.Descripcion, item.Categoria, item.Imagen))
        .ToList()
    };

    return Ok(response);
  }
}
