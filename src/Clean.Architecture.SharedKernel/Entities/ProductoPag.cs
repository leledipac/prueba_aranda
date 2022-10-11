using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.SharedKernel.Entities;
public class ProductoPag
{
  public int Total { get; set; }
  public int Pagina { get; set; }
  public ProductoPag(List<Producto> productos, int total, int pagina)
  {
    Total = total;
    Pagina = pagina;

    Productos = productos;
  }

  public List<Producto> Productos { get; set; }  
}
