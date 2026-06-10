/*
    Ejercicio 1: Sistema de Biblioteca (Gestión de Préstamos de Libros)

    Contexto: El sistema de la biblioteca universitaria permite a los estudiantes prestar libros,
    pero existen reglas de negocio estrictas que, de no cumplirse,
    deben interrumpir el flujo normal del programa mediante el uso de excepciones.

    Enunciado: Desarrolle un programa en C# que simule el proceso de préstamo de un libro.
    Deberá crear una clase Libro (con propiedades como Titulo, CopiasDisponibles) y una clase Prestamo.

    El sistema debe solicitar al usuario el título del libro que desea prestar y la cantidad de días que lo tendrá.
    Implemente una lógica donde se puedan disparar y capturar las siguientes excepciones:
    - InvalidOperationException: Si el estudiante intenta prestar un libro cuyo stock de CopiasDisponibles
    sea igual a cero.
    - ArgumentOutOfRangeException: Si el usuario ingresa una cantidad de días de préstamo negativa o mayor
    al límite permitido por la universidad (15 días).
    - FormatException: Al capturar los datos desde la consola,
    si el usuario introduce texto en lugar de un número entero para los días.

    Requisito técnico: Utilice un bloque try-catch-finally para asegurar que, al finalizar el intento de préstamo
    (con éxito o con error), se muestre un mensaje en pantalla indicando que la sesión de préstamo ha concluido.
*/

class Program
{
    static void Main()
    {
        try
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE BIBLIOTECA ===");

                Prestamo.HacerPrestamo();

                Console.WriteLine();
                Console.Write("Desea realizar otro prestamo? (s/n): ");
                string? respuesta = Console.ReadLine()?.Trim().ToLower();
                if (respuesta != "s")
                    continuar = false;
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("La sesion de prestamo ha concluido.");
        }
    }
}
