using System;

class Estudiante
{
    public string Nombre;

    public static int TotalInscritos = 0;

    public Estudiante(string nombre)
    {
        Nombre = nombre;
        TotalInscritos++;
    }

    public static void Saludar()
    {
        Console.WriteLine("Bienvenidos a la universidad!");
    }
}

class Program
{
    static void Main()
    {
        Estudiante[] lista = new Estudiante[10];

        lista[0] = new Estudiante("Ana");
        lista[1] = new Estudiante("Juan");
        lista[2] = new Estudiante("Pedro");
        lista[3] = new Estudiante("Lucia");
        lista[4] = new Estudiante("Erick");
        lista[5] = new Estudiante("Gonzalo");
        lista[6] = new Estudiante("Josue");
        lista[7] = new Estudiante("Martin");
        lista[8] = new Estudiante("Jasmir");
        lista[9] = new Estudiante("Moises");

        Console.WriteLine("Lista de estudiantes incremento");
        for (int i = 0; i < lista.Length; i++)
        {
            Console.WriteLine("- " + lista[i].Nombre);
        }

        Console.WriteLine("Lista de estudiantes decremento");
        for (int i = lista.Length - 1; i >= 0; i--)
        {
            Console.WriteLine("- " + lista[i].Nombre);
        }

        Console.WriteLine("\nTotal de estudiantes registrados: " + Estudiante.TotalInscritos);
        Estudiante.Saludar();
    }
}