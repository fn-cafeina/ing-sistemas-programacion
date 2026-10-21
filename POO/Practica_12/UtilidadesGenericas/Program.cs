/*
    Opcion 3.- Libreria de utilidades genericas
    Desarrollar una clase llamada UtilidadesGenericas.
    La clase debe incluir metodos para:
    - Intercambiar valores.
    - Buscar elementos.
    - Ordenar arreglos o listas.
    - Mostrar colecciones.
    - Contar elementos.
    Requisitos obligatorios:
    - Implementar al menos 3 metodos genericos funcionales.
    - Aplicar reutilizacion de codigo.
    - Trabajar con distintos tipos de datos.
*/

class UtilidadesGenericas
{
    public static void Intercambiar<T>(ref T a, ref T b)
    {
        T temporal = a;
        a = b;
        b = temporal;
    }

    public static int BuscarElemento<T>(T[] arreglo, T elemento)
    {
        return Array.IndexOf(arreglo, elemento);
    }

    public static void Ordenar<T>(T[] arreglo) where T : IComparable<T>
    {
        Array.Sort(arreglo);
    }

    public static void MostrarColeccion<T>(IEnumerable<T> coleccion)
    {
        int contador = 0;
        foreach (T item in coleccion)
        {
            Console.Write($"{item} ");
            contador++;
        }
        if (contador == 0)
            Console.Write("(vacio)");
        Console.WriteLine();
    }

    public static int ContarElementos<T>(IEnumerable<T> coleccion)
    {
        int contador = 0;
        foreach (T _ in coleccion)
            contador++;
        return contador;
    }
}

class Program
{
    static int MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("=== LIBRERIA DE UTILIDADES GENERICAS ===\n");
        Console.WriteLine("1. Trabajar con numeros (int)");
        Console.WriteLine("2. Trabajar con textos (string)");
        Console.WriteLine("3. Trabajar con decimales (double)");
        Console.WriteLine("4. Salir");
        Console.Write("\nOpcion: ");
        if (int.TryParse(Console.ReadLine(), out int opcion) && opcion >= 1 && opcion <= 4)
            return opcion;
        return 0;
    }

    static int[]? LeerArregloEnteros()
    {
        Console.Write("Cantidad de numeros: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Error: Ingrese una cantidad valida.");
            return null;
        }

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Numero {i + 1}: ");
            if (!int.TryParse(Console.ReadLine(), out arr[i]))
            {
                Console.WriteLine("Error: Numero invalido.");
                i--;
            }
        }
        return arr;
    }

    static string[]? LeerArregloTextos()
    {
        Console.Write("Cantidad de textos: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Error: Ingrese una cantidad valida.");
            return null;
        }

        string[] arr = new string[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Texto {i + 1}: ");
            string texto = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(texto))
            {
                Console.WriteLine("Error: El texto no puede estar vacio.");
                i--;
                continue;
            }
            arr[i] = texto;
        }
        return arr;
    }

    static double[]? LeerArregloDoubles()
    {
        Console.Write("Cantidad de valores: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Error: Ingrese una cantidad valida.");
            return null;
        }

        double[] arr = new double[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Valor {i + 1}: ");
            if (!double.TryParse(Console.ReadLine(), out arr[i]))
            {
                Console.WriteLine("Error: Valor invalido.");
                i--;
            }
        }
        return arr;
    }

    static void ProbarConEnteros()
    {
        int[]? arr = LeerArregloEnteros();
        if (arr == null) return;

        Console.WriteLine("\n--- Resultados ---");
        Console.Write("Original: ");
        UtilidadesGenericas.MostrarColeccion(arr);
        Console.WriteLine($"Cantidad: {UtilidadesGenericas.ContarElementos(arr)}");

        if (arr.Length >= 2)
        {
            int a = arr[0], b = arr[1];
            Console.WriteLine($"Intercambiar {a} y {b}:");
            UtilidadesGenericas.Intercambiar(ref a, ref b);
            Console.WriteLine($"a={a}, b={b}");
        }

        int indice = UtilidadesGenericas.BuscarElemento(arr, arr[0]);
        Console.WriteLine($"Indice del primer elemento ({arr[0]}): {indice}");

        UtilidadesGenericas.Ordenar(arr);
        Console.Write("Ordenado: ");
        UtilidadesGenericas.MostrarColeccion(arr);
    }

    static void ProbarConTextos()
    {
        string[]? arr = LeerArregloTextos();
        if (arr == null) return;

        Console.WriteLine("\n--- Resultados ---");
        Console.Write("Original: ");
        UtilidadesGenericas.MostrarColeccion(arr);
        Console.WriteLine($"Cantidad: {UtilidadesGenericas.ContarElementos(arr)}");

        if (arr.Length >= 2)
        {
            string a = arr[0], b = arr[1];
            Console.WriteLine($"Intercambiar \"{a}\" y \"{b}\":");
            UtilidadesGenericas.Intercambiar(ref a, ref b);
            Console.WriteLine($"a={a}, b={b}");
        }

        int indice = UtilidadesGenericas.BuscarElemento(arr, arr[0]);
        Console.WriteLine($"Indice del primer elemento ({arr[0]}): {indice}");

        UtilidadesGenericas.Ordenar(arr);
        Console.Write("Ordenado: ");
        UtilidadesGenericas.MostrarColeccion(arr);
    }

    static void ProbarConDoubles()
    {
        double[]? arr = LeerArregloDoubles();
        if (arr == null) return;

        Console.WriteLine("\n--- Resultados ---");
        Console.Write("Original: ");
        UtilidadesGenericas.MostrarColeccion(arr);
        Console.WriteLine($"Cantidad: {UtilidadesGenericas.ContarElementos(arr)}");

        if (arr.Length >= 2)
        {
            double a = arr[0], b = arr[1];
            Console.WriteLine($"Intercambiar {a} y {b}:");
            UtilidadesGenericas.Intercambiar(ref a, ref b);
            Console.WriteLine($"a={a}, b={b}");
        }

        int indice = UtilidadesGenericas.BuscarElemento(arr, arr[0]);
        Console.WriteLine($"Indice del primer elemento ({arr[0]}): {indice}");

        UtilidadesGenericas.Ordenar(arr);
        Console.Write("Ordenado: ");
        UtilidadesGenericas.MostrarColeccion(arr);
    }

    static void Main()
    {
        int opcion;
        do
        {
            opcion = MostrarMenu();

            if (opcion == 0)
            {
                Console.WriteLine("Opcion no valida.");
                Console.Write("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                continue;
            }

            Console.Clear();

            switch (opcion)
            {
                case 1: ProbarConEnteros(); break;
                case 2: ProbarConTextos(); break;
                case 3: ProbarConDoubles(); break;
                case 4: Console.WriteLine("Saliendo del programa..."); break;
            }

            if (opcion != 4)
            {
                Console.Write("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        } while (opcion != 4);
    }
}
