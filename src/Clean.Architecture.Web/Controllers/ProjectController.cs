using Clean.Architecture.Core.Productos.Entities;
using Clean.Architecture.Core.Productos.Specifications;
using Clean.Architecture.SharedKernel.Interfaces;
using Clean.Architecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.Web.Controllers;

[Route("[controller]")]
public class ProjectController : Controller
{
  private readonly IRepository<Producto> _projectRepository;

  public ProjectController(IRepository<Producto> projectRepository)
  {
    _projectRepository = projectRepository;
  }

  // GET project/{projectId?}
  [HttpGet("{projectId:int}")]
  public async Task<IActionResult> Index(int projectId = 1)
  {
    var spec = new ProductoByIdWithItemsSpec(projectId);
    var project = await _projectRepository.FirstOrDefaultAsync(spec);
    if (project == null)
    {
      return NotFound();
    }

    var dto = new ProductoViewModel
    {
      Id = project.Id,
      Nombre = project.Nombre,
      Descripcion = project.Descripcion,
      Categoria = project.Categoria,
      Imagen = project.Imagen
    };
    return View(dto);
  }
}
