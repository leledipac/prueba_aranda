
namespace Clean.Architecture.Web.Endpoints.ProductoEndpoints;

public class GetProductoByIdRequest
{
  public const string Route = "/Productos/{ProductoId:int}";
  public static string BuildRoute(int productoId) => Route.Replace("{ProductoId:int}", productoId.ToString());

  public int ProductoId { get; set; }
}
