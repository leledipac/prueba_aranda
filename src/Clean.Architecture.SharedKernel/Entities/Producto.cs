using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Clean.Architecture.SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.SharedKernel.Entities;
public class Producto:EntityBase, IAggregateRoot
{
  //public Producto()
  //{
  //  Nombre = "";
  //  Descripcion = "";
  //  Categoria = "";
  //  Imagen = "";
  //}
  public Producto(string Nombre, string Descripcion, string Categoria, string? Imagen)
  {
    this.Nombre = Nombre;
    this.Descripcion = Descripcion;
    this.Categoria = Categoria;
    this.Imagen = Imagen;
  }
  [StringLength(100)]
  public string Nombre { get; set; }
  public string Descripcion { get; set; }
  [StringLength(50)]
  public string Categoria { get; set; }
  public string? Imagen { get; set; }


  //public override string ToString()
  //{
  //  string status = IsDone ? "Done!" : "Not done.";
  //  return $"{Id}: Status: {status} - {Title} - {Description}";
  //}

  public void UpdateNombre(string newValue)
  {
    Nombre = newValue;
  }
  public void UpdateDescripcion(string newValue)
  {
    Descripcion = newValue;
  }
  public void UpdateCategoria(string newValue)
  {
    Categoria = newValue;
  }
  public void UpdateImagen(string? newValue)
  {
    Imagen = newValue;
  }
}
