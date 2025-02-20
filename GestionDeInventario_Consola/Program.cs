using GestionDeInventario_Consola;
using System;

class Program
{
    static void Main(string[] args)
    {
        Inventario inventario = new Inventario();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n--- Sistema de Gestión de Inventario ---");
            Console.WriteLine("1. Agregar Producto");
            Console.WriteLine("2. Editar Producto");
            Console.WriteLine("3. Eliminar Producto");
            Console.WriteLine("4. Buscar Producto");
            Console.WriteLine("5. Mostrar Todos los Productos");
            Console.WriteLine("6. Guardar Datos");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el ID del producto: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el nombre del producto: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese la descripción del producto: ");
                    string descripcion = Console.ReadLine();
                    Console.Write("Ingrese el precio del producto: ");
                    decimal precio = decimal.Parse(Console.ReadLine());
                    Console.Write("Ingrese la cantidad en stock: ");
                    int cantidad = int.Parse(Console.ReadLine());

                    Producto nuevoProducto = new Producto(id, nombre, descripcion, precio, cantidad);
                    inventario.AgregarProducto(nuevoProducto);
                    Console.WriteLine("Producto agregado correctamente.");
                    break;
                case "2":
                    Console.Write("Ingrese el ID del producto que desea editar: ");
                    if (int.TryParse(Console.ReadLine(), out int idEditar))
                    {
                        // Buscar el producto por ID
                        var productoEditar = inventario.BuscarProductoPorId(idEditar);

                        if (productoEditar != null)
                        {
                            // Mostrar los datos actuales del producto
                            Console.WriteLine("\nDatos actuales del producto:");
                            Console.WriteLine(productoEditar);

                            // Solicitar los nuevos datos
                            Console.Write("\nIngrese el nuevo nombre (deje en blanco para no modificar): ");
                            string nuevoNombre = Console.ReadLine();
                            Console.Write("Ingrese la nueva descripción (deje en blanco para no modificar): ");
                            string nuevaDescripcion = Console.ReadLine();
                            Console.Write("Ingrese el nuevo precio (deje en blanco para no modificar): ");
                            string nuevoPrecioInput = Console.ReadLine();
                            Console.Write("Ingrese la nueva cantidad (deje en blanco para no modificar): ");
                            string nuevaCantidadInput = Console.ReadLine();

                            // Actualizar solo los campos que no estén en blanco
                            if (!string.IsNullOrWhiteSpace(nuevoNombre))
                            {
                                productoEditar.Nombre = nuevoNombre;
                            }
                            if (!string.IsNullOrWhiteSpace(nuevaDescripcion))
                            {
                                productoEditar.Descripcion = nuevaDescripcion;
                            }
                            if (!string.IsNullOrWhiteSpace(nuevoPrecioInput))
                            {
                                if (decimal.TryParse(nuevoPrecioInput, out decimal nuevoPrecio))
                                {
                                    productoEditar.Precio = nuevoPrecio;
                                }
                                else
                                {
                                    Console.WriteLine("Precio no válido. No se modificará el precio.");
                                }
                            }
                            if (!string.IsNullOrWhiteSpace(nuevaCantidadInput))
                            {
                                if (int.TryParse(nuevaCantidadInput, out int nuevaCantidad))
                                {
                                    productoEditar.Cantidad = nuevaCantidad;
                                }
                                else
                                {
                                    Console.WriteLine("Cantidad no válida. No se modificará la cantidad.");
                                }
                            }

                            Console.WriteLine("Producto actualizado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró un producto con ese ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID no válido. Intente de nuevo.");
                    }
                    break;
                case "3":
                    // Lógica para eliminar producto
                    break;
                case "4":
                    // Lógica para buscar producto
                    break;
                case "5":
                    inventario.MostrarProductos();
                    break;
                case "6":
                    inventario.GuardarDatos(); // Guardar datos antes de salir
                    //salir = true;
                    break;
                case "7":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}