using System;

class Program
{
    // Arreglos paralelos
    static string[] nombres = new string[100];
    static double[] precios = new double[100];
    static int[] stock = new int[100];

    static int contador = 0;

    static void Main()
    {
        int opcion;

        do
        {
            MostrarMenu();
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarProducto();
                    break;

                case 2:
                    ListarProductos();
                    break;

                case 3:
                    ActualizarStock();
                    break;

                case 4:
                    EliminarProducto();
                    break;

                case 5:
                    GenerarFactura();
                    break;

                case 6:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

        } while (opcion != 6);
    }

    // MENU
    static void MostrarMenu()
    {
        Console.WriteLine("\n===== LA TIENDITA =====");
        Console.WriteLine("1. Registrar producto");
        Console.WriteLine("2. Listar productos");
        Console.WriteLine("3. Actualizar stock");
        Console.WriteLine("4. Eliminar producto");
        Console.WriteLine("5. Generar factura");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción: ");
    }

    // REGISTRAR
    static void RegistrarProducto()
    {
        Console.Write("Nombre del producto: ");
        nombres[contador] = Console.ReadLine();

        Console.Write("Precio: ");
        precios[contador] = double.Parse(Console.ReadLine());

        Console.Write("Cantidad en stock: ");
        stock[contador] = int.Parse(Console.ReadLine());

        contador++;

        Console.WriteLine("Producto registrado correctamente.");
    }

    // LISTAR
    static void ListarProductos()
    {
        Console.WriteLine("\n=== INVENTARIO ===");

        for (int i = 0; i < contador; i++)
        {
            Console.WriteLine($"{i + 1}. {nombres[i]} - Precio: {precios[i]} - Stock: {stock[i]}");
        }
    }

    // ACTUALIZAR
    static void ActualizarStock()
    {
        ListarProductos();

        Console.Write("Seleccione el producto a modificar: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < contador)
        {
            Console.Write("Nuevo stock: ");
            stock[index] = int.Parse(Console.ReadLine());

            Console.WriteLine("Stock actualizado.");
        }
        else
        {
            Console.WriteLine("Producto inválido.");
        }
    }

    // ELIMINAR
    static void EliminarProducto()
    {
        ListarProductos();

        Console.Write("Seleccione el producto a eliminar: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < contador)
        {
            for (int i = index; i < contador - 1; i++)
            {
                nombres[i] = nombres[i + 1];
                precios[i] = precios[i + 1];
                stock[i] = stock[i + 1];
            }

            contador--;

            Console.WriteLine("Producto eliminado.");
        }
        else
        {
            Console.WriteLine("Producto inválido.");
        }
    }

    // FACTURA
    static void GenerarFactura()
    {
        double total = 0;

        char continuar;

        do
        {
            ListarProductos();

            Console.Write("Seleccione producto: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index < 0 || index >= contador)
            {
                Console.WriteLine("Producto inválido.");
                return;
            }

            Console.Write("Cantidad a comprar: ");
            int cantidad = int.Parse(Console.ReadLine());

            if (cantidad > stock[index])
            {
                Console.WriteLine("Stock insuficiente.");
            }
            else
            {
                double subtotal = cantidad * precios[index];
                total += subtotal;

                stock[index] -= cantidad;

                Console.WriteLine($"Agregado: {nombres[index]} x{cantidad} = {subtotal}");
            }

            Console.Write("¿Agregar otro producto? (s/n): ");
            continuar = char.Parse(Console.ReadLine());

        } while (continuar == 's' || continuar == 'S');

        Console.WriteLine($"\nTOTAL A PAGAR: {total}");
    }
}