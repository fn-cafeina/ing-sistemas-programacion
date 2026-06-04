/*
    Ejercicio 1: El Sistema de Gestión de Notas (Control de Nulidad)
    - Objetivo: Aprender a proteger los métodos de una clase contra objetos no instanciados (null).
    - Excepción clave: NullReferenceException.

    Contexto:
    Imagina que estás desarrollando el sistema de control de estudios de la universidad.
    Tienes una clase Asignatura y una clase Estudiante.
    Si un profesor intenta calcular el promedio de un estudiante
    que aún no ha sido registrado en la asignatura, el sistema podría colapsar.

    Instrucciones:
    1. Crea una clase Estudiante con la propiedad Nombre y un arreglo o lista de Notas.
    2. Crea una clase Asignatura. Esta clase debe tener un atributo de tipo Estudiante.
    3. Implementa un método en Asignatura llamado MostrarReporte().
    Este método debe imprimir el nombre del estudiante y su promedio.
    4. El reto: En el programa principal,
    crea una Asignatura pero no instancies al Estudiante (déjalo en null).
    Envuelve la llamada a MostrarReporte() en un bloque try-catch para capturar el error
    de referencia nula y mostrar un mensaje educativo al usuario.
*/

using ControlDeNulidad;

Asignatura asignatura = new(null);

try
{
    asignatura.MostrarReporte();
}
catch (NullReferenceException)
{
    Console.WriteLine("Error: El estudiante no está registrado en la asignatura.");
}
