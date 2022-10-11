
using Clean.Architecture.Core.Productos.Specifications;
using Clean.Architecture.SharedKernel.Interfaces;
using Clean.Architecture.SharedKernel.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clean.Architecture.Web.Pages.ProjectDetails;

public class IncompleteModel : PageModel
{
  private readonly IRepositorioProducto _repository;

  [BindProperty(SupportsGet = true)]
  public int ProjectId { get; set; }


  public IncompleteModel(IRepositorioProducto repository)
  {
    _repository = repository;
  }

  public async Task OnGetAsync()
  {
    var projectSpec = new ProductoByIdWithItemsSpec(ProjectId);
    var project = await _repository.FirstOrDefaultAsync(projectSpec);
    if (project == null)
    {
      return;
    }

  }
}
