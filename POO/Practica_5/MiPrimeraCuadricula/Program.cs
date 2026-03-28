/*
    Mi Primera Cuadrícula (Declaración y Llenado)
    Registro de Calificaciones por Parcial.

    Problema: Un docente necesita guardar las notas de 3 estudiantes en 2 parciales diferentes.
    Requerimiento: Declarar una matriz de double[3, 2]. Usar ciclos anidados para pedir las notas.
    Al final, imprimir la matriz en formato de tabla.

    Punto clave: Uso de matrix.GetLength(0) para filas y matrix.GetLength(1) para columnas.
*/

double[,] notas = new double[3, 2];

Console.Clear();
Console.WriteLine("--- Registro de Calificaciones por Parcial ---\n");

for (int i = 0; i < notas.GetLength(0); i++)
{
    for (int j = 0; j < notas.GetLength(1); j++)
    {
        while (true)
        {
            Console.Write($"Ingrese la nota del Estudiante {i + 1}, Parcial {j + 1}: ");
            if (double.TryParse(Console.ReadLine(), out double nota) && nota >= 0 && nota <= 10)
            {
                notas[i, j] = nota;
                break;
            }

            Console.Clear();
            Console.WriteLine("--- Registro de Calificaciones por Parcial ---\n");
            Console.WriteLine("Error: Ingrese una nota válida (0-10).");
        }
    }
}

Console.WriteLine("\n--- Tabla de Calificaciones ---");
Console.WriteLine("{0,-15} | {1,-10} | {2,-10}", "Estudiante", "Parcial 1", "Parcial 2");
Console.WriteLine(new string('-', 40));

for (int i = 0; i < notas.GetLength(0); i++)
{
    Console.WriteLine("{0,-15} | {1,-10} | {2,-10}",
        $"Estudiante {i + 1}",
        notas[i, 0],
        notas[i, 1]);
}