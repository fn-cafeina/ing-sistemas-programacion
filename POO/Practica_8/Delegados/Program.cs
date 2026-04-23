/*
    2. Delegados

    Objetivo: Entender que podemos "guardar" una función en una variable y ejecutarla después.

    Ejercicio: Crea un delegado llamado Operacion que reciba dos números.

    * Funciones: Crea una función Suma y otra Resta.

    * Validación: En el Main, asigna la función Suma al delegado, ejecútalo y muestra el
    resultado. Luego, cambia el delegado a la función Resta y repite. Esto les enseña que
    el comportamiento puede cambiar dinámicamente.
*/

class Program
{
    delegate int Operacion(int a, int b);

    static int Suma(int a, int b)
    {
        return a + b;
    }

    static int Resta(int a, int b)
    {
        return a - b;
    }

    static void Main()
    {
        Operacion op;

        op = Suma;
        Console.WriteLine(op(10, 5));

        op = Resta;
        Console.WriteLine(op(10, 5));
    }
}