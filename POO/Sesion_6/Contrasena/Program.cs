/*
    1. Crea un programa que solicite al usuario ingresar una
    contraseña. El programa debe seguir pidiendo la contraseña
    mientras no sea igual a "1234". Cuando el usuario ingrese la
    contraseña correcta, debe mostrar el mensaje "Acceso
    concedido". Usar la sentencia while.
*/

Console.Clear();

string contrasena = "";

while (contrasena != "1234")
{
    Console.Write("Ingrese la contraseña: ");
    contrasena = Console.ReadLine() ?? "";

    if (contrasena != "1234")
    {
        Console.WriteLine("Error: contraseña incorrecta.\n");
    }
}

Console.WriteLine("Acceso concedido.");