/*
    Ejercicio 2: Sistema de Matrícula Universitaria (Control de Cupos y Requisitos)

    Contexto: Durante el periodo de matrícula, el sistema debe validar que los estudiantes
    cumplan con las condiciones académicas y de capacidad antes de consolidar su inscripción
    en una asignatura.

    Enunciado: Diseñe un módulo de matrícula en C#. Defina una clase Asignatura
    (con Nombre, CupoMaximo, CuposInscritos) y una clase Estudiante (con Nombre, CreditosAprobados).

    El programa debe intentar matricular a un estudiante en una asignatura específica.
    Para este ejercicio, deberá crear e implementar excepciones personalizadas
    (heredando de la clase Exception de C#):
    - CupoAgotadoException: Se debe lanzar si el número de CuposInscritos ha alcanzado
      el CupoMaximo de la asignatura.
    - CreditosInsuficientesException: Se debe lanzar si la asignatura requiere un mínimo
      de créditos aprobados (por ejemplo, 40 créditos para una materia de tercer año)
      y el estudiante no cuenta con ellos.

    Requisito técnico: En el programa principal (Main), simule un escenario donde se intente
    registrar a varios estudiantes de forma consecutiva. Capture de forma ordenada las excepciones
    personalizadas de la más específica a la más general, mostrando mensajes claros y profesionales
    en la consola para cada caso.
*/

class Program
{
    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE MATRICULA UNIVERSITARIA ===");
            Console.WriteLine();

            try
            {
                if (!Matricula.RealizarMatricula())
                    continuar = false;
            }
            catch (CreditosInsuficientesException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error de creditos: {ex.Message}");
                Console.ResetColor();
            }
            catch (CupoAgotadoException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error de cupo: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Intento de matricula finalizado.");
                Console.Write("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }

            if (!continuar) continue;

            Console.WriteLine();
            Console.Write("Desea realizar otra matricula? (s/n): ");
            string? respuesta = Console.ReadLine()?.Trim().ToLower();
            if (respuesta != "s" && respuesta != "si" && respuesta != "y" && respuesta != "yes")
                continuar = false;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nSesion de matricula concluida. Gracias por usar el sistema.");
        Console.ResetColor();
    }
}
