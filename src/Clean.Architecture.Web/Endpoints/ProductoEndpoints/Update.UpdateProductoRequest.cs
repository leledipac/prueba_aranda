using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Endpoints.ProductoEndpoints;

public class UpdateProductoRequest
{
  public const string Route = "/Productos";
  [Required]
  public int Id { get; set; }
  [Required]
  public string? Nombre { get; set; }
  [Required]
  public string? Descripcion { get; set; }
  [Required]
  public string? Categoria { get; set; }
  [Required]
  public string? Imagen { get; set; }
}
