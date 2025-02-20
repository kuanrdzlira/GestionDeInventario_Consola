using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestionDeInventario_Consola
{
    public class Inventario
    {
        private List<Producto> productos;
        private string rutaArchivo = "Data/inventario.json";
        public Inventario()
        {
            productos = new List<Producto>();
            CargarDatos();
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public void EditarProducto(int id, string nombre, string descripcion, decimal precio, int cantidad)
        {
            var producto = productos.Find(p => p.Id == id);
            if (producto != null)
            {
                producto.Nombre = nombre;
                producto.Descripcion = descripcion;
                producto.Precio = precio;
                producto.Cantidad = cantidad;
            }
        }

        public void ElininarProducto(int id)
        {
            productos.RemoveAll(p => p.Id == id);
        }
        
        public List<Producto> BuscarProductos(string nombre)
        {
            return productos.FindAll(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public void MostrarProductos()
        {
            foreach(var producto in productos)
            {
                Console.WriteLine(producto);
            }
        }

        public Producto BuscarProductoPorId(int id)
        {
            return productos.Find(p => p.Id == id);
        }

        public void EliminarProducto(int id)
        {
            productos.RemoveAll(p => p.Id == id);
        }

        //Guardar Datos

        public void GuardarDatos()
        {
            try
            {
                // Crear la carpeta si no existe
                string carpeta = Path.GetDirectoryName(rutaArchivo);
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                // Serializar la lista de productos a JSON
                string json = JsonSerializer.Serialize(productos, new JsonSerializerOptions { WriteIndented = true });

                // Guardar el JSON en el archivo
                File.WriteAllText(rutaArchivo, json);
                Console.WriteLine("Datos guardados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar los datos: {ex.Message}");
            }
        }

        // Método para cargar los datos desde un archivo JSON
        public void CargarDatos()
        {
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    // Leer el archivo JSON
                    string json = File.ReadAllText(rutaArchivo);

                    // Deserializar el JSON a una lista de productos
                    productos = JsonSerializer.Deserialize<List<Producto>>(json);
                    Console.WriteLine("Datos cargados correctamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró el archivo de datos. Se creará uno nuevo al guardar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar los datos: {ex.Message}");
            }
        }


    }
}
