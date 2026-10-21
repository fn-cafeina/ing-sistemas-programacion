/*
    2. Escribe un programa que calcule el Índice de Masa Corporal (IMC).
    El usuario debe ingresar su peso en kilogramos y su altura en metros.
    Usa double.TryParse para validar ambos datos. Luego, calcula el IMC con la
    fórmula:

    IMC = peso / altura^2

    Clasifica el resultado como:

    "Bajo peso" si el IMC < 18.5
    "Normal" si está entre 18.5 y 24.9
    "Sobrepeso" si está entre 25 y 29.9
    "Obesidad" si es 30 o más
*/

Console.Clear();

Console.Write("Ingrese su peso (kg): ");
if (!double.TryParse(Console.ReadLine(), out double peso))
{
    Console.WriteLine("Error: Dato no válido.");
    return;
}

Console.Write("Ingrese su altura (metros): ");
if (!double.TryParse(Console.ReadLine(), out double altura))
{
    Console.WriteLine("Error: Dato no válido.");
    return;
}

double IMC = peso / (altura * altura);

string resultado = IMC switch
{
    >= 30 => "Obesidad",
    >= 25 => "Sobrepreso",
    >= 18.5 => "Normal",
    _ => "Bajo peso"
};

Console.WriteLine($"\nSu IMC es: {IMC:F2}");
Console.WriteLine($"Clasificación: {resultado}");