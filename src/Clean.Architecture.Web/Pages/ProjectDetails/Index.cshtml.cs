
using Clean.Architecture.Core.Productos.Specifications;
using Clean.Architecture.SharedKernel.Interfaces;
using Clean.Architecture.SharedKernel.Repositorio;
using Clean.Architecture.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clean.Architecture.Web.Pages.ProjectDetails;

public class IndexModel : PageModel
{
  private readonly IRepositorioProducto _repository;

  [BindProperty(SupportsGet = true)]
  public int ProductoId { get; set; }

  public string Message { get; set; } = "";

  public ProductoDTO? Producto { get; set; }

  public IndexModel(IRepositorioProducto repository)
  {
    _repository = repository;
  }

  public async Task OnGetAsync()
  {
    var projectSpec = new ProductoByIdWithItemsSpec(ProductoId);
    var project = await _repository.FirstOrDefaultAsync(projectSpec);
    if (project == null)
    {
      Message = "No project found.";

      return;
    }

    Producto = new ProductoDTO
    (
        id: project.Id,
        nombre: project.Nombre,
        descripcion: project.Descripcion,
        categoria: project.Categoria,
        imagen: project.Imagen
    );
  }
}
