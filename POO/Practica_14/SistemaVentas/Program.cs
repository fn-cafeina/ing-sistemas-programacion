/*
    Ejercicio 3: Sistema de Ventas (Procesamiento de Facturas y Pagos)

    Contexto: En el punto de venta de una tienda, el proceso de facturación interactúa
    con métodos de pago y disponibilidad de productos. Un error no controlado aquí podría
    causar pérdidas de dinero o inconsistencias en el inventario.

    Enunciado: Implemente una simulación de facturación para un Sistema de Ventas.
    El sistema debe calcular el total de una compra basándose en un precio unitario
    y una cantidad de productos.

    Deberá validar el flujo del proceso utilizando el manejo defensivo de excepciones:
    - ArgumentException: Si el nombre del producto está vacío o la cantidad solicitada
      es menor o igual a cero.
    - OverflowException: Al simular la conversión de datos numéricos o si el cálculo
      del total de la factura supera los límites financieros permitidos por el tipo
      de datos seleccionado.
    - Excepción General (Exception): Para capturar cualquier otro fallo inesperado
      en el método que procesa el pago simulado.

    Requisito técnico: Utilice la propagación de excepciones. El método ProcesarFactura()
    debe lanzar la excepción hacia el método Main(), y será en este último donde se capture
    y se muestre el desglose del error utilizando las propiedades .Message y .StackTrace
    (esta última para que los estudiantes visualicen la ruta del error en la pila de ejecución).
*/

class Program
{
    static List<Producto> catalogo = new()
    {
        new Producto("Laptop", 800),
        new Producto("Mouse", 25),
        new Producto("Teclado", 45),
        new Producto("Monitor", 200),
    };

    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE VENTAS ===");
            Console.WriteLine();

            bool procesar = true;
            bool salir = false;
            Producto? producto = null;
            int cantidad = 0;

            try
            {
                Console.WriteLine("Productos disponibles:");
                for (int i = 0; i < catalogo.Count; i++)
                {
                    Console.WriteLine($"  [{i + 1}] {catalogo[i].Nombre} - {catalogo[i].PrecioUnitario:C}");
                }
                Console.WriteLine();

                while (producto == null && procesar)
                {
                    Console.Write("Seleccione un producto (numero, o '0' para salir): ");
                    string? entrada = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(entrada))
                    {
                        Console.WriteLine("Debe ingresar un numero valido.");
                        continue;
                    }

                    if (entrada == "0")
                    {
                        Console.WriteLine("Operacion cancelada.");
                        procesar = false;
                        salir = true;
                        break;
                    }

                    if (int.TryParse(entrada, out int idx) && idx >= 1 && idx <= catalogo.Count)
                    {
                        producto = catalogo[idx - 1];
                    }
                    else
                    {
                        Console.WriteLine("Numero invalido. Intente de nuevo.");
                    }
                }

                if (procesar)
                {
                    Console.Clear();
                    Console.WriteLine($"Producto seleccionado: {producto!.Nombre} - {producto.PrecioUnitario:C}");
                    Console.WriteLine();

                    Console.Write("Cantidad (ej: 3): ");
                    string? entradaCantidad = Console.ReadLine();

                    if (!int.TryParse(entradaCantidad, out cantidad))
                        throw new FormatException("La cantidad debe ser un numero entero valido. Ej: 3");

                    Console.Clear();
                    Console.WriteLine("Resumen de factura:");
                    Console.WriteLine($"  Producto: {producto.Nombre}");
                    Console.WriteLine($"  Precio unitario: {producto.PrecioUnitario:C}");
                    Console.WriteLine($"  Cantidad: {cantidad}");
                    Console.WriteLine();
                    Console.Write("Confirmar factura? (s/n): ");
                    string? conf = Console.ReadLine()?.Trim().ToLower();
                    if (conf != "s" && conf != "si" && conf != "y" && conf != "yes")
                    {
                        Console.WriteLine("Factura cancelada.");
                        procesar = false;
                    }
                }

                if (procesar)
                {
                    Console.Clear();
                    ProcesadorPagos.ProcesarFactura(producto!.Nombre, cantidad, producto.PrecioUnitario);
                }
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error de argumento: {ex.Message}");
                Console.WriteLine("Ruta del error (StackTrace):");
                foreach (var linea in (ex.StackTrace ?? "").Split('\n', StringSplitOptions.RemoveEmptyEntries))
                    Console.WriteLine($"  {linea.Trim()}");
                Console.ResetColor();
            }
            catch (OverflowException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error de desbordamiento: {ex.Message}");
                Console.WriteLine("Ruta del error (StackTrace):");
                foreach (var linea in (ex.StackTrace ?? "").Split('\n', StringSplitOptions.RemoveEmptyEntries))
                    Console.WriteLine($"  {linea.Trim()}");
                Console.ResetColor();
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error de formato: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error inesperado: {ex.Message}");
                Console.WriteLine("Ruta del error (StackTrace):");
                foreach (var linea in (ex.StackTrace ?? "").Split('\n', StringSplitOptions.RemoveEmptyEntries))
                    Console.WriteLine($"  {linea.Trim()}");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Intento de facturacion finalizado.");
                Console.Write("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }

            if (salir)
            {
                continuar = false;
                continue;
            }

            Console.WriteLine();
            Console.Write("Desea realizar otra factura? (s/n): ");
            string? respuesta = Console.ReadLine()?.Trim().ToLower();
            if (respuesta != "s" && respuesta != "si" && respuesta != "y" && respuesta != "yes")
                continuar = false;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nSesion de ventas concluida. Gracias por usar el sistema.");
        Console.ResetColor();
    }
}
