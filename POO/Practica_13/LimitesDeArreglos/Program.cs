/*
    Ejercicio 2: El Aula Virtual y los Grupos de Trabajo (Límites de Arreglos)
    - Objetivo: Controlar el desbordamiento de estructuras de datos fijas dentro de un objeto.
    - Excepción clave: IndexOutOfRangeException.

    Contexto:
    En la universidad, los grupos de proyectos de sistemas tienen un límite
    estricto de integrantes. Si un objeto GrupoTrabajo tiene capacidad para
    3 alumnos, intentar agregar un cuarto miembro romperá el índice del arreglo.

    Instrucciones:
    1. Crea una clase GrupoTrabajo que contenga un arreglo de strings de
    tamaño fijo (por ejemplo, capacidad para 3 alumnos) y un contador entero
    para saber cuántos se han inscrito.
    2. Crea un método AgregarIntegrante(string nombre).
    3. El reto: Deja que el arreglo intente llenarse de forma natural usando
    el contador como índice. Cuando se intente agregar un 4to integrante,
    C# lanzará automáticamente un IndexOutOfRangeException.
    4. Implementa el bloque try-catch-finally en el código principal.
    Utiliza el bloque finally para mostrar un mensaje que diga:
    "Proceso de inscripción finalizado", asegurando que se ejecute sin
    importar si el grupo se llenó con éxito o si falló.
*/

using LimitesDeArreglos;

GrupoTrabajo grupo = new(3);

try
{
    grupo.AgregarIntegrante("Ana");
    grupo.AgregarIntegrante("Luis");
    grupo.AgregarIntegrante("Carlos");
    grupo.AgregarIntegrante("Marta");
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("Error: El grupo ya está completo. Máximo 3 integrantes.");
}
finally
{
    Console.WriteLine("Proceso de inscripción finalizado.");
}
