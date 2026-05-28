/*
    Opcion 1.- Sistema generico de gestion de colecciones
    Desarrollar un sistema utilizando una clase generica llamada Gestor<T>.
    El sistema debe permitir:
    - Agregar elementos.
    - Eliminar elementos.
    - Buscar elementos.
    - Mostrar informacion almacenada.
    Requisitos obligatorios:
    - Uso de listas genericas (List<T>).
    - Implementar al menos:
      o 2 metodos genericos funcionales.
      o 1 metodo con restriccion (where T).
    - Debe funcionar con diferentes tipos de datos:
      o int
      o string
      o objetos personalizados
    Ejemplo de aplicacion:
    - Gestion de estudiantes
    - Gestion de productos
    - Gestion de vehiculos
*/

class Estudiante
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public Estudiante(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}, Edad: {Edad}";
    }
}

class Gestor<T>
{
    private List<T> _elementos = new List<T>();

    public void Agregar(T elemento)
    {
        _elementos.Add(elemento);
    }

    public bool Eliminar(T elemento)
    {
        return _elementos.Remove(elemento);
    }

    public List<T> Buscar(Predicate<T> condicion)
    {
        return _elementos.FindAll(condicion);
    }

    public void Mostrar()
    {
        if (_elementos.Count == 0)
        {
            Console.WriteLine("No hay elementos almacenados.");
            return;
        }
        for (int i = 0; i < _elementos.Count; i++)
            Console.WriteLine($"{i + 1}. {_elementos[i]}");
    }

    public List<U> Transformar<U>(Func<T, U> transformador)
    {
        List<U> resultado = new List<U>();
        foreach (T e in _elementos)
            resultado.Add(transformador(e));
        return resultado;
    }

    public void AgregarRango<U>(U coleccion) where U : IEnumerable<T>
    {
        foreach (T item in coleccion)
            _elementos.Add(item);
    }
}

class Program
{
    static int MenuTipo()
    {
        Console.Clear();
        Console.WriteLine("=== SISTEMA GENERICO DE GESTION DE COLECCIONES ===\n");
        Console.WriteLine("Seleccione el tipo de datos a gestionar:");
        Console.WriteLine("1. Numeros (int)");
        Console.WriteLine("2. Textos (string)");
        Console.WriteLine("3. Estudiantes");
        Console.WriteLine("4. Salir");
        Console.Write("\nOpcion: ");
        if (int.TryParse(Console.ReadLine(), out int opcion) && opcion >= 1 && opcion <= 4)
            return opcion;
        return 0;
    }

    static void MenuOperaciones<T>(Gestor<T> gestor, string nombreTipo)
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine($"=== GESTION DE {nombreTipo.ToUpper()} ===\n");
            Console.WriteLine("1. Agregar elemento");
            Console.WriteLine("2. Eliminar elemento");
            Console.WriteLine("3. Buscar elementos");
            Console.WriteLine("4. Mostrar todos");
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
                    AgregarElemento(gestor, nombreTipo);
                    break;
                case 2:
                    EliminarElemento(gestor, nombreTipo);
                    break;
                case 3:
                    BuscarElementos(gestor, nombreTipo);
                    break;
                case 4:
                    Console.WriteLine($"=== ELEMENTOS ({nombreTipo.ToUpper()}) ===\n");
                    gestor.Mostrar();
                    break;
            }

            if (opcion != 5)
            {
                Console.Write("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        } while (opcion != 5);
    }

    static void AgregarElemento<T>(Gestor<T> gestor, string nombreTipo)
    {
        if (typeof(T) == typeof(int))
        {
            Console.Write("Ingrese un numero entero positivo: ");
            if (!int.TryParse(Console.ReadLine(), out int valor) || valor < 0)
            {
                Console.WriteLine("Error: Debe ingresar un numero entero valido mayor o igual a 0.");
                return;
            }
            (gestor as Gestor<int>)?.Agregar(valor);
        }
        else if (typeof(T) == typeof(string))
        {
            Console.Write("Ingrese un texto: ");
            string texto = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(texto))
            {
                Console.WriteLine("Error: El texto no puede estar vacio.");
                return;
            }
            (gestor as Gestor<string>)?.Agregar(texto);
        }
        else if (typeof(T) == typeof(Estudiante))
        {
            Console.Write("Nombre del estudiante: ");
            string nombre = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Error: El nombre no puede estar vacio.");
                return;
            }
            Console.Write("Edad del estudiante: ");
            if (!int.TryParse(Console.ReadLine(), out int edad) || edad <= 0)
            {
                Console.WriteLine("Error: Debe ingresar una edad valida mayor a 0.");
                return;
            }
            (gestor as Gestor<Estudiante>)?.Agregar(new Estudiante(nombre, edad));
        }
        Console.WriteLine("Elemento agregado correctamente.");
    }

    static void EliminarElemento<T>(Gestor<T> gestor, string nombreTipo)
    {
        if (typeof(T) == typeof(int))
        {
            Console.Write("Ingrese el numero a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int valor) || valor < 0)
            {
                Console.WriteLine("Error: Debe ingresar un numero valido.");
                return;
            }
            bool result = (gestor as Gestor<int>)?.Eliminar(valor) ?? false;
            Console.WriteLine(result ? "Elemento eliminado." : "Elemento no encontrado.");
        }
        else if (typeof(T) == typeof(string))
        {
            Console.Write("Ingrese el texto a eliminar: ");
            string texto = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(texto))
            {
                Console.WriteLine("Error: El texto no puede estar vacio.");
                return;
            }
            bool result = (gestor as Gestor<string>)?.Eliminar(texto) ?? false;
            Console.WriteLine(result ? "Elemento eliminado." : "Elemento no encontrado.");
        }
        else if (typeof(T) == typeof(Estudiante))
        {
            Console.Write("Nombre del estudiante a eliminar: ");
            string nombre = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Error: El nombre no puede estar vacio.");
                return;
            }
            Console.Write("Edad del estudiante: ");
            if (!int.TryParse(Console.ReadLine(), out int edad) || edad <= 0)
            {
                Console.WriteLine("Error: Edad invalida.");
                return;
            }
            bool result = (gestor as Gestor<Estudiante>)?.Eliminar(new Estudiante(nombre, edad)) ?? false;
            Console.WriteLine(result ? "Elemento eliminado." : "Elemento no encontrado.");
        }
    }

    static void BuscarElementos<T>(Gestor<T> gestor, string nombreTipo)
    {
        if (typeof(T) == typeof(int))
        {
            Console.Write("Buscar numeros mayores o iguales a: ");
            if (!int.TryParse(Console.ReadLine(), out int min))
            {
                Console.WriteLine("Error: Numero invalido.");
                return;
            }
            var resultados = (gestor as Gestor<int>)?.Buscar(n => n >= min) ?? new List<int>();
            Console.WriteLine(resultados.Count > 0 ? "Resultados:" : "No se encontraron elementos.");
            foreach (var r in resultados)
                Console.WriteLine(r);
        }
        else if (typeof(T) == typeof(string))
        {
            Console.Write("Buscar textos que contengan: ");
            string patron = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(patron))
            {
                Console.WriteLine("Error: El patron de busqueda no puede estar vacio.");
                return;
            }
            var resultados = (gestor as Gestor<string>)?.Buscar(t => t.Contains(patron)) ?? new List<string>();
            Console.WriteLine(resultados.Count > 0 ? "Resultados:" : "No se encontraron elementos.");
            foreach (var r in resultados)
                Console.WriteLine(r);
        }
        else if (typeof(T) == typeof(Estudiante))
        {
            Console.Write("Buscar estudiantes mayores a: ");
            if (!int.TryParse(Console.ReadLine(), out int edadMin))
            {
                Console.WriteLine("Error: Edad invalida.");
                return;
            }
            var resultados = (gestor as Gestor<Estudiante>)?.Buscar(e => e.Edad > edadMin) ?? new List<Estudiante>();
            Console.WriteLine(resultados.Count > 0 ? "Resultados:" : "No se encontraron estudiantes.");
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
                    MenuOperaciones(new Gestor<int>(), "Numeros");
                    break;
                case 2:
                    MenuOperaciones(new Gestor<string>(), "Textos");
                    break;
                case 3:
                    MenuOperaciones(new Gestor<Estudiante>(), "Estudiantes");
                    break;
            }
        } while (opcion != 4);
    }
}
