using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Endpoints.ProductoEndpoints;

public class CreateProductoRequest
{
  public const string Route = "/Productos";

  [Required]
  public string? Nombre { get; set; }
  [Required]
  public string? Descripcion { get; set; }
  [Required]
  public string? Categoria { get; set; }
  public string? Imagen { get; set; }
}
