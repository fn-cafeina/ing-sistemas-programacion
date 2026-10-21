/*
    2. Escribe un programa en C# que solicite al usuario ingresar su edad.
    El programa debe mostrar un mensaje indicando si la persona es menor de edad (menos de 18 años),
    adulta (entre 18 y 64 años) o adulta mayor (65 años o más).
*/

Console.Clear();

Console.Write("Ingresa tu edad: ");

if (int.TryParse(Console.ReadLine(), out int edad))
{
    if (edad < 18)
        Console.WriteLine("Menor de edad.");
    else if (edad < 65)
        Console.WriteLine("Adulta.");
    else
        Console.WriteLine("Adulta mayor.");
}