using Clean.Architecture.Core.Productos.Entities;
using Clean.Architecture.Core.Productos.Specifications;
using Clean.Architecture.SharedKernel.Interfaces;
using Clean.Architecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.Web.Controllers;

[Route("[controller]")]
public class ProductoController : Controller
{
  private readonly IRepository<Producto> _productoRepository;

  public ProductoController(IRepository<Producto> productoRepository)
  {
    _productoRepository = productoRepository;
  }

  // GET project/{productoId?}
  [HttpGet("{productoId:int}")]
  public async Task<IActionResult> Index(int productoId = 1)
  {
    var spec = new ProductoByIdWithItemsSpec(productoId);
    var producto = await _productoRepository.FirstOrDefaultAsync(spec);
    if (producto == null)
    {
      return NotFound();
    }

    var dto = new ProductoViewModel
    {
      Id = producto.Id,
      Nombre = producto.Nombre,
      Descripcion = producto.Descripcion,
      Categoria = producto.Categoria,
      Imagen = producto.Imagen
    };
    return View(dto);
  }
}
