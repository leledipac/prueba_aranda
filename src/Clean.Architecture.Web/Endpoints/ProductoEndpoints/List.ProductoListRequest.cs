
namespace Clean.Architecture.Web.Endpoints.ProductoEndpoints;

public class ProductoListRequest
{
  public int Pagina { get; set; } = 1;
  public string Nombre { get; set; } = string.Empty;
  public string Descripcion { get; set; } = string.Empty;
  public string Categoria { get; set; } = string.Empty;
}
