/*
    1. Crea un programa que solicite al usuario ingresar una temperatura en
    grados Celsius.

    El programa debe validar que el dato ingresado sea numérico usando int.TryParse.
    Luego, debe clasificar la temperatura como:

    "Muy frío" si es menor a 10°C
    "Frío" si está entre 10°C y 17°C
    "Templado" si está entre 18°C y 25°C
    "Caluroso" si está entre 26°C y 35°C
    "Extremo" si es mayor a 35°C

    Si el dato no es válido, debe mostrar un mensaje de error.
*/

Console.Clear();

Console.Write("Ingrese la temperatura en grados celcius: ");
if (!int.TryParse(Console.ReadLine(), out int C))
{
    Console.WriteLine("Error: Dato no válido.");
    return;
}

string resultado = C switch
{
    > 35 => "Extremo",
    >= 26 => "Caluroso",
    >= 18 => "Templado",
    >= 10 => "Frío",
    _ => "Muy frío"
};

Console.WriteLine($"Temperatura: {resultado}");