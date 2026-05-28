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
    static int MenuTipo()
    {
        Console.Clear();
        Console.WriteLine("=== DISPENSADOR AUTOMATIZADO DE ALMACEN ===\n");
        Console.WriteLine("Seleccione el tipo de producto:");
        Console.WriteLine("1. Medicamento");
        Console.WriteLine("2. Alimento");
        Console.WriteLine("3. Salir");
        Console.Write("\nOpcion: ");
        if (int.TryParse(Console.ReadLine(), out int opcion) && opcion >= 1 && opcion <= 3)
            return opcion;
        return 0;
    }

    static void MenuOperaciones<T>(Dispensador<T> dispensador, string nombreTipo) where T : Producto
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine($"=== GESTION DE {nombreTipo.ToUpper()} ===\n");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Despachar producto");
            Console.WriteLine("3. Mostrar inventario");
            Console.WriteLine("4. Buscar productos");
            Console.WriteLine("5. Volver al menu principal");
            Console.Write("\nOpcion: ");
            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
            {
                Console.WriteLine("Opcion no valida.");
                Console.Write("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                continue;
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

    static void AgregarProducto<T>(Dispensador<T> dispensador, string nombreTipo) where T : Producto
    {
        if (typeof(T) == typeof(Medicamento))
        {
            Console.Write("Nombre del medicamento: ");
            string nombre = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Error: El nombre no puede estar vacio.");
                return;
            }

            Console.Write("Precio del medicamento: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal precio) || precio < 0)
            {
                Console.WriteLine("Error: Ingrese un precio valido mayor o igual a 0.");
                return;
            }

            Console.Write("Dosis en mg: ");
            if (!int.TryParse(Console.ReadLine(), out int dosis) || dosis <= 0)
            {
                Console.WriteLine("Error: Ingrese una dosis valida mayor a 0.");
                return;
            }

            (dispensador as Dispensador<Medicamento>)?.Agregar(new Medicamento(nombre, precio, dosis));
            Console.WriteLine("Medicamento agregado correctamente.");
        }
        else if (typeof(T) == typeof(Alimento))
        {
            Console.Write("Nombre del alimento: ");
            string nombre = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Error: El nombre no puede estar vacio.");
                return;
            }

            Console.Write("Precio del alimento: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal precio) || precio < 0)
            {
                Console.WriteLine("Error: Ingrese un precio valido mayor o igual a 0.");
                return;
            }

            Console.Write("Fecha de vencimiento (DD/MM/AAAA): ");
            string fecha = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(fecha))
            {
                Console.WriteLine("Error: La fecha no puede estar vacia.");
                return;
            }

            (dispensador as Dispensador<Alimento>)?.Agregar(new Alimento(nombre, precio, fecha));
            Console.WriteLine("Alimento agregado correctamente.");
        }
    }

    static void DespacharProducto<T>(Dispensador<T> dispensador) where T : Producto
    {
        Console.WriteLine("=== PRODUCTOS DISPONIBLES ===\n");
        dispensador.MostrarInventario();

        if (dispensador.Contar() == 0)
            return;

        Console.Write("\nSeleccione el numero del producto a despachar: ");
        if (!int.TryParse(Console.ReadLine(), out int indice) || indice < 1 || indice > dispensador.Contar())
        {
            Console.WriteLine("Error: Seleccion invalida.");
            return;
        }

        T item = dispensador.ObtenerPorIndice(indice - 1);
        if (item != null)
        {
            if (dispensador.Despachar(item))
                Console.WriteLine("Producto retirado del inventario.");
        }
    }

    static void BuscarProductos<T>(Dispensador<T> dispensador, string nombreTipo) where T : Producto
    {
        if (typeof(T) == typeof(Medicamento))
        {
            Console.Write("Buscar medicamentos con dosis minima: ");
            if (!int.TryParse(Console.ReadLine(), out int dosisMin) || dosisMin < 0)
            {
                Console.WriteLine("Error: Dosis invalida.");
                return;
            }

            var resultados = (dispensador as Dispensador<Medicamento>)?.Buscar(m => m.Dosis >= dosisMin) ?? new List<Medicamento>();
            Console.WriteLine(resultados.Count > 0 ? "Resultados:" : "No se encontraron medicamentos.");
            foreach (var r in resultados)
                Console.WriteLine(r);
        }
        else if (typeof(T) == typeof(Alimento))
        {
            Console.Write("Buscar alimentos con fecha que contenga: ");
            string patron = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(patron))
            {
                Console.WriteLine("Error: El patron de busqueda no puede estar vacio.");
                return;
            }

            var resultados = (dispensador as Dispensador<Alimento>)?.Buscar(a => a.FechaVencimiento.Contains(patron)) ?? new List<Alimento>();
            Console.WriteLine(resultados.Count > 0 ? "Resultados:" : "No se encontraron alimentos.");
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

            if (opcion == 0)
            {
                Console.WriteLine("Opcion no valida.");
                Console.Write("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                continue;
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
