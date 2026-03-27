/*
    3. Crea un programa en C# que solicite al usuario ingresar un número del 1 al 5.
    El programa debe mostrar el nombre del día de la semana correspondiente (1 = lunes, 2 = martes, etc.).
    Si el número no está en ese rango, debe mostrar un mensaje de error.
*/

Console.Clear();

Console.Write("Ingresa un número del 1 al 5: ");
string numero = Console.ReadLine();

string resultado = numero switch
{
    "1" => "Lunes",
    "2" => "Martes",
    "3" => "Miércoles",
    "4" => "Jueves",
    "5" => "Viernes",
    _ => "Error: El número no está en el rango del 1 al 5."
};

Console.WriteLine(resultado);