namespace Clean.Architecture.Web.Endpoints.ProductoEndpoints;

public class UpdateProductoResponse
{
  public UpdateProductoResponse(ProductoRecord project)
  {
    Producto = project;
  }
  public ProductoRecord Producto { get; set; }
}
