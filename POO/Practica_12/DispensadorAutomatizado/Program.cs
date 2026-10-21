/*
    Ejercicio 1: Dispensador Automatizado de Almacen (Manipulacion de Objetos Complejos)

    Conceptos POO: Clases Abstractas, Herencia, Restricciones de Genericos (where T : ClaseBase).

    Tipo de Dato Manipulado: Objetos de una jerarquia de clases (ProductoFisico).

    Contexto:
    En un sistema de inventario logistico, se requiere disenar un brazo robotico o
    dispensador automatico capaz de gestionar la salida de productos. Existen
    diferentes tipos de productos (como Electronico o Alimento), pero el
    dispensador debe ser generico para poder trabajar con cualquier producto,
    siempre y cuando herede de una clase base comun que provea el peso y las
    dimensiones.

    Enunciado:
    1. Crea una clase abstracta llamada Producto con propiedades como Nombre y Precio.
    2. Crea al menos dos clases derivadas: Medicamento (con propiedad Dosis)
    y Alimento (con propiedad FechaVencimiento).
    3. Disena una clase generica llamada Dispensador donde T representa el tipo de producto.
    4. Restriccion obligatoria: Aplica una restriccion para que T solo pueda
    ser una clase derivada de Producto (where T : Producto).
    5. La clase debe incluir un metodo Despachar(T item) que muestre un
    mensaje polimorfico usando las propiedades del producto.
*/

class Program
{
    static int LeerOpcion(int min, int max, int maxIntentos)
    {
        for (int i = 0; i < maxIntentos; i++)
        {
            Console.Write("\nOpcion: ");
            if (int.TryParse(Console.ReadLine(), out int opcion) && opcion >= min && opcion <= max)
                return opcion;
            if (i < maxIntentos - 1)
                Console.WriteLine($"Valor invalido. Intentos restantes: {maxIntentos - i - 1}");
        }
        return -1;
    }

    static string? LeerString(string mensaje, int maxIntentos = 3)
    {
        for (int i = 0; i < maxIntentos; i++)
        {
            Console.Write(mensaje);
            string valor = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(valor))
                return valor;
            if (i < maxIntentos - 1)
                Console.WriteLine($"Valor invalido. Intentos restantes: {maxIntentos - i - 1}");
        }
        return null;
    }

    static decimal? LeerDecimal(string mensaje, decimal min, int maxIntentos = 3)
    {
        for (int i = 0; i < maxIntentos; i++)
        {
            Console.Write(mensaje);
            if (decimal.TryParse(Console.ReadLine(), out decimal valor) && valor >= min)
                return valor;
            if (i < maxIntentos - 1)
                Console.WriteLine($"Valor invalido. Intentos restantes: {maxIntentos - i - 1}");
        }
        return null;
    }

    static int? LeerInt(string mensaje, int min, int max, int maxIntentos = 3)
    {
        for (int i = 0; i < maxIntentos; i++)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out int valor) && valor >= min && valor <= max)
                return valor;
            if (i < maxIntentos - 1)
                Console.WriteLine($"Valor invalido. Intentos restantes: {maxIntentos - i - 1}");
        }
        return null;
    }

    static int MenuTipo()
    {
        Console.Clear();
        Console.WriteLine("=== DISPENSADOR AUTOMATIZADO DE ALMACEN ===\n");
        Console.WriteLine("Seleccione el tipo de producto:");
        Console.WriteLine("1. Medicamento");
        Console.WriteLine("2. Alimento");
        Console.WriteLine("3. Salir");
        return LeerOpcion(1, 3, 3);
    }

    static void MenuOperaciones<T>(Dispensador<T> dispensador, string nombreTipo) where T : Producto
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine($"=== GESTION DE {nombreTipo.ToUpper()} ===  |  Inventario: {dispensador.Contar()} productos\n");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Despachar producto");
            Console.WriteLine("3. Mostrar inventario");
            Console.WriteLine("4. Buscar productos");
            Console.WriteLine("5. Volver al menu principal");
            opcion = LeerOpcion(1, 5, 3);

            if (opcion == -1)
            {
                Console.WriteLine("Demasiados intentos fallidos. Volviendo...");
                Console.Write("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                break;
            }

            Console.Clear();

            switch (opcion)
            {
                case 1:
                    AgregarProducto(dispensador, nombreTipo);
                    break;
                case 2:
                    DespacharProducto(dispensador);
                    break;
                case 3:
                    Console.WriteLine($"=== INVENTARIO ({nombreTipo.ToUpper()}) ===\n");
                    dispensador.MostrarInventario();
                    break;
                case 4:
                    BuscarProductos(dispensador, nombreTipo);
                    break;
            }

            if (opcion != 5)
            {
                Console.Write("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        } while (opcion != 5);
    }

    static bool ValidarNombre(string nombre)
    {
        if (nombre.Length > 50)
        {
            Console.WriteLine("Error: El nombre no puede exceder 50 caracteres.");
            return false;
        }
        if (!nombre.All(c => char.IsLetter(c) || c == ' '))
        {
            Console.WriteLine("Error: El nombre solo puede contener letras y espacios.");
            return false;
        }
        return true;
    }

    static void AgregarProducto<T>(Dispensador<T> dispensador, string nombreTipo) where T : Producto
    {
        if (typeof(T) == typeof(Medicamento))
        {
            string? nombre = LeerString("Nombre del medicamento: ");
            if (nombre == null) return;
            if (!ValidarNombre(nombre)) return;

            decimal? precio = LeerDecimal("Precio del medicamento (ej: 25.50): ", 0);
            if (precio == null) return;

            int? dosis = LeerInt("Dosis en mg (ej: 500): ", 1, int.MaxValue);
            if (dosis == null) return;

            (dispensador as Dispensador<Medicamento>)?.Agregar(new Medicamento(nombre, precio.Value, dosis.Value));
            Console.WriteLine("Medicamento agregado correctamente.");
        }
        else if (typeof(T) == typeof(Alimento))
        {
            string? nombre = LeerString("Nombre del alimento: ");
            if (nombre == null) return;
            if (!ValidarNombre(nombre)) return;

            decimal? precio = LeerDecimal("Precio del alimento (ej: 12.00): ", 0);
            if (precio == null) return;

            string? fecha = LeerString("Fecha de vencimiento (DD/MM/AAAA): ");
            if (fecha == null) return;
            if (!DateTime.TryParseExact(fecha, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _))
            {
                Console.WriteLine("Error: Fecha invalida. Use DD/MM/AAAA (ej: 15/06/2026).");
                return;
            }

            (dispensador as Dispensador<Alimento>)?.Agregar(new Alimento(nombre, precio.Value, fecha));
            Console.WriteLine("Alimento agregado correctamente.");
        }
    }

    static void DespacharProducto<T>(Dispensador<T> dispensador) where T : Producto
    {
        Console.WriteLine("=== PRODUCTOS DISPONIBLES ===\n");
        dispensador.MostrarInventario();

        if (dispensador.Contar() == 0)
            return;

        int? indice = LeerInt("\nSeleccione el numero del producto a despachar: ", 1, dispensador.Contar());
        if (indice == null) return;

        T item = dispensador.ObtenerPorIndice(indice.Value - 1);
        if (dispensador.Despachar(item))
            Console.WriteLine("Producto retirado del inventario.");
    }

    static void BuscarProductos<T>(Dispensador<T> dispensador, string nombreTipo) where T : Producto
    {
        if (dispensador.Contar() == 0)
        {
            Console.WriteLine("No hay productos registrados para buscar.");
            return;
        }

        if (typeof(T) == typeof(Medicamento))
        {
            string? nombre = LeerString("Buscar por nombre (ej: Paracetamol): ");
            if (nombre == null) return;

            int? dosisMin = LeerInt("Dosis minima en mg (ej: 500): ", 0, int.MaxValue);
            if (dosisMin == null) return;

            var resultados = (dispensador as Dispensador<Medicamento>)?.Buscar(m =>
                m.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase) &&
                m.Dosis >= dosisMin.Value) ?? new List<Medicamento>();

            Console.WriteLine(resultados.Count > 0 ? "Resultados:" : "No se encontraron medicamentos con ese criterio.");
            foreach (var r in resultados)
                Console.WriteLine(r);
        }
        else if (typeof(T) == typeof(Alimento))
        {
            string? nombre = LeerString("Buscar por nombre (ej: Manzana): ");
            if (nombre == null) return;

            var resultados = (dispensador as Dispensador<Alimento>)?.Buscar(a =>
                a.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)) ?? new List<Alimento>();

            Console.WriteLine(resultados.Count > 0 ? "Resultados:" : "No se encontraron alimentos con ese nombre.");
            foreach (var r in resultados)
                Console.WriteLine(r);
        }
    }

    static void Main()
    {
        int opcion;
        do
        {
            opcion = MenuTipo();

            if (opcion == -1)
            {
                Console.WriteLine("Demasiados intentos fallidos. Saliendo...");
                break;
            }

            switch (opcion)
            {
                case 1:
                    MenuOperaciones(new Dispensador<Medicamento>(), "Medicamentos");
                    break;
                case 2:
                    MenuOperaciones(new Dispensador<Alimento>(), "Alimentos");
                    break;
            }
        } while (opcion != 3);
    }
}
