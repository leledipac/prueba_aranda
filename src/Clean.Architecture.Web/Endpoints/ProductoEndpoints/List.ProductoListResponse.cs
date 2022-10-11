
namespace Clean.Architecture.Web.Endpoints.ProductoEndpoints;

public class ProductoListResponse
{
  public int Pagina { get; set; } = 0;
  public int Total { get; set; } = 0;
  public List<ProductoRecord> Productos { get; set; } = new();
}
