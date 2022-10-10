using System.Collections.Generic;

namespace Clean.Architecture.Web.ViewModels;

public class ProductoViewModel
{
  public int Id { get; set; }
  public string? Nombre { get; set; }
  public string? Descripcion { get; set; }
  public string? Imagen { get; set; }
  public string? Categoria { get; set; }
}
