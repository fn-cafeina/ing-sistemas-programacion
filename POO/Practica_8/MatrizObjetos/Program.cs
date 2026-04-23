/*
    4. Matriz de Objetos

    Objetivo: Aprender a gestionar colecciones de datos complejos en una estructura
    bidimensional.

    Ejercicio: Imagina un Laboratorio de Computación.

    * Clase: Computadora (con atributo Marca).

    * Matriz: Crea una matriz Computadora[,] lab = new Computadora[2, 2].

    * Validación: Pide a los alumnos que llenen la matriz con nombres de marcas (Dell, HP,
    etc.) usando un ciclo for anidado y que luego la impriman como si fuera el plano del
    salón.
*/

class Computadora
{
    public string Marca;

    public Computadora(string marca)
    {
        Marca = marca;
    }

    public override string ToString()
    {
        return Marca;
    }
}

class Program
{
    static void Main()
    {
        Computadora[,] lab = new Computadora[2, 2];

        string[] marcas = { "Dell", "HP", "Lenovo", "Asus" };
        int index = 0;

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                lab[i, j] = new Computadora(marcas[index]);
                index++;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write(lab[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}