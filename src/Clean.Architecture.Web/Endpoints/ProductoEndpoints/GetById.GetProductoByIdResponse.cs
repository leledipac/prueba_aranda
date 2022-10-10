
namespace Clean.Architecture.Web.Endpoints.ProductoEndpoints;

public class GetProductoByIdResponse
{
  public GetProductoByIdResponse(int id, string nombre, string descripcion, string categoria, string? imagen)
  {
    Id = id;
    Nombre = nombre;
    Descripcion = descripcion;
    Categoria = categoria;
    Imagen = imagen;
  }

  public int Id { get; set; }
  public string Nombre { get; set; }
  public string Descripcion { get; set; }
  public string Categoria { get; set; }
  public string? Imagen { get; set; }
}
