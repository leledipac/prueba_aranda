using Clean.Architecture.Core.Productos.Entities;
using Clean.Architecture.Core.Productos.Specifications;
using Clean.Architecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clean.Architecture.Web.Pages.ProjectDetails;

public class IncompleteModel : PageModel
{
  private readonly IRepository<Producto> _repository;

  [BindProperty(SupportsGet = true)]
  public int ProjectId { get; set; }


  public IncompleteModel(IRepository<Producto> repository)
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
