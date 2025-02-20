using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeInventario_Consola
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    

    public Producto(int id, string nombre, string descripcion,
            decimal precio, int cantidad)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Cantidad = cantidad;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Descripcion: {Descripcion}, Precio {Precio:C}, Cantidad: {Cantidad}";

        }
    }
}
