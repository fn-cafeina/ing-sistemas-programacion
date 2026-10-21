/* 
    1. Una ferretería desea registrar las existencias de 3 tipos de
    productos (martillos, clavos y destornilladores) en 2 bodegas distintas. 

    Crea un programa en C# que:
    * Solicite al usuario ingresar la cantidad de cada producto en cada bodega (matriz 3x2).
    * Muestre la matriz completa en formato tabular.
    * Calcule y muestre el total de cada producto sumando las dos bodegas.
*/

int[,] existencias = new int[3, 2];
string[] productos = { "Martillos", "Clavos", "Destornilladores" };

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 2; j++)
    {
        existencias[i, j] = LeerEnteroPositivo($"Ingrese la cantidad de {productos[i]} en Bodega {j + 1}: ");
    }
}

Console.WriteLine("\nReporte de Existencias:");
Console.WriteLine("Producto".PadRight(20) + "Bodega 1".PadRight(15) + "Bodega 2");

for (int i = 0; i < 3; i++)
{
    Console.WriteLine(productos[i].PadRight(20) + existencias[i, 0].ToString().PadRight(15) + existencias[i, 1]);
}

Console.WriteLine("\nTotal por Producto:");
for (int i = 0; i < 3; i++)
{
    int total = existencias[i, 0] + existencias[i, 1];
    Console.WriteLine($"{productos[i].PadRight(20)} {total}");
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