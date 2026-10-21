/*
    2. Una farmacia desea registrar las ventas de 2 medicamentos (Paracetamol y Ibuprofeno) durante 3 días. 

    Crea un programa en C# que:
    * Solicite al usuario ingresar las ventas de cada medicamento por día (matriz 2x3).
    * Muestre la matriz completa en formato tabular.
    * Calcule y muestre el total vendido de cada medicamento en los 3 días.
*/

int[,] ventas = new int[2, 3];
string[] medicamentos = { "Paracetamol", "Ibuprofeno" };

for (int i = 0; i < 2; i++)
{
    for (int j = 0; j < 3; j++)
    {
        ventas[i, j] = LeerEnteroPositivo($"Ingrese las ventas de {medicamentos[i]} en el Día {j + 1}: ");
    }
}

Console.WriteLine("\nReporte de Ventas:");
Console.WriteLine("Medicamento".PadRight(15) + "Día 1".PadRight(10) + "Día 2".PadRight(10) + "Día 3");

for (int i = 0; i < 2; i++)
{
    Console.WriteLine(medicamentos[i].PadRight(15) + ventas[i, 0].ToString().PadRight(10) + ventas[i, 1].ToString().PadRight(10) + ventas[i, 2]);
}

Console.WriteLine("\nTotal Vendido por Medicamento:");
for (int i = 0; i < 2; i++)
{
    int total = ventas[i, 0] + ventas[i, 1] + ventas[i, 2];
    Console.WriteLine($"{medicamentos[i].PadRight(15)} {total}");
}

int LeerEnteroPositivo(string mensaje)
{
    int valor;
    while (true)
    {
        Console.Write(mensaje);
        if (int.TryParse(Console.ReadLine(), out valor) && valor >= 0)
        {
            return valor;
        }
        Console.WriteLine("Error: Entrada inválida. Debe ingresar un número entero mayor o igual a cero.");
    }
}