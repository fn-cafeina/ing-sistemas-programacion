/*
    1. Miembros Estáticos

    Objetivo: Entender que un dato puede ser compartido por todos los objetos, no solo
    pertenecer a uno.

    Ejercicio: Crea una clase ContadorEstudiantes.

    * Atributo estático: static int TotalEstudiantes.

    * Constructor: Cada vez que se crea un objeto, debe aumentar el contador en 1.

    * Validación: En el Main, crea 3 objetos y luego imprime el valor de TotalEstudiantes.
    Debe marcar "3" sin necesidad de usar una instancia específica.
*/

class ContadorEstudiantes
{
    public static int TotalEstudiantes = 0;

    public ContadorEstudiantes()
    {
        TotalEstudiantes++;
    }
}

class Program
{
    static void Main()
    {
        ContadorEstudiantes e1 = new ContadorEstudiantes();
        ContadorEstudiantes e2 = new ContadorEstudiantes();
        ContadorEstudiantes e3 = new ContadorEstudiantes();

        Console.WriteLine(ContadorEstudiantes.TotalEstudiantes);
    }
}