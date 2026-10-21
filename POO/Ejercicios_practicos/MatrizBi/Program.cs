// double valor = 12.2;
// int v_entero = Convert.ToInt32(valor);
// Console.WriteLine($"El valor entero es: {v_entero}");

// string texto = "123";
// int texto_convertido = int.Parse(texto);
// Console.WriteLine($"Texto convertido: {texto_convertido}");

// object valor = null;
// switch (valor)
// {
//     case int n when n > 0: Console.WriteLine($"Entero positivo: {n}"); break;
//     case double d: Console.WriteLine($"Número decimal: {d}"); break;
//     case null: Console.WriteLine("Valor nulo"); break;
//     default: Console.WriteLine("Otro tipo"); break;
// }

int[,] matriz = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
for (int i = 0; i < matriz.GetLength(0); i++)
{
    for (int j = 0; j < matriz.GetLength(1); j++)
    {
        Console.Write($"{matriz[i, j]} ");
    }
    Console.WriteLine();
}
