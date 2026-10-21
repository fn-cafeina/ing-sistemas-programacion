using System;

namespace Articulos.Cap04.Excepciones.Parte5
{
    public sealed class UsoArgumentException
    {
        // Método para dividir un número par entre 2:
        private static int DividirPorDos(int numero)
        {
            // En caso de que el número no sea par, entonces
            // se lanzará la excepción ArgumentException:
            if ((numero % 2) == 1)
            {
                throw new ArgumentException("El número debe ser par.", "numero");
            }

            return numero / 2;
        }

        public static void Main()
        {
            // Ejemplo de uso del método 'DividirPorDos':
            Console.WriteLine("\nDivisión de 100 entre 2 = {0}", DividirPorDos(100));

            try
            {
                // Aquí la excepción ArgumentException es lanzada debido a que
                // dividiendo es un número impar:
                Console.WriteLine("13 dividido por 2 = {0}", DividirPorDos(13));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Mensaje de error: {0}", ae.Message);
            }
        }
    }
}