/*
    3. Crea un programa que solicite al usuario un número entero y
    muestre su tabla de multiplicar del 1 al 10. Usar sentencia for.
*/

Console.Clear();

Console.Write("Ingrese un número entero: ");
if (!int.TryParse(Console.ReadLine(), out int numero))
{
    Console.WriteLine("Error: dato no válido. Debe ingresar un número entero.");
    return;
}

Console.WriteLine($"\n--- Tabla de multiplicar del {numero} ---");

for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"{numero} x {i} = {numero * i}");
}