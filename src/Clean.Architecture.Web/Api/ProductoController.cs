using Clean.Architecture.Core.Productos.Entities;
using Clean.Architecture.Core.Productos.Specifications;
using Clean.Architecture.SharedKernel.Interfaces;
using Clean.Architecture.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.Web.Api;

/// <summary>
/// A sample API Controller. Consider using API Endpoints (see Endpoints folder) for a more SOLID approach to building APIs
/// https://github.com/ardalis/ApiEndpoints
/// </summary>
public class ProductoController : BaseApiController
{
  private readonly IRepository<Producto> _repository;

  public ProductoController(IRepository<Producto> repository)
  {
    _repository = repository;
  }

  // GET: api/Productos
  [HttpGet]
  public async Task<IActionResult> List()
  {
    var productosDTOs = (await _repository.ListAsync())
        .Select(item => new ProductoDTO
        (
            id: item.Id,
            nombre: item.Nombre,
            descripcion: item.Nombre,
            categoria: item.Nombre,
            imagen: item.Nombre
        ))
        .ToList();

    return Ok(productosDTOs);
  }

  // GET: api/Productos
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetById(int id)
  {
    var productoSpec = new ProductoByIdWithItemsSpec(id);
    var producto = await _repository.FirstOrDefaultAsync(productoSpec);
    if (producto == null)
    {
      return NotFound();
    }

    var result = new ProductoDTO
    (
        id: producto.Id,
        nombre: producto.Nombre,
        descripcion: producto.Descripcion,
        categoria: producto.Categoria,
        imagen: producto.Imagen
    );

    return Ok(result);
  }

  // POST: api/Productos
  [HttpPost]
  public async Task<IActionResult> Post([FromBody] CreateProductoDTO request)
  {
    var newProducto = new Producto(request.Nombre, request.Descripcion, request.Categoria, request.Imagen);

    var createdProducto = await _repository.AddAsync(newProducto);

    var result = new ProductoDTO
    (
        id: createdProducto.Id,
        nombre: createdProducto.Nombre,
        descripcion: createdProducto.Descripcion,
        categoria: createdProducto.Categoria,
        imagen: createdProducto.Imagen
    );
    return Ok(result);
  }

}
