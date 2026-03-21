/*
    Control de inventario en Bucle (WHILE / DO-WHILE)

    Problema: Existe un stock inicial de 20 productos.

    Requerimiento: El programa debe preguntar cuántos productos desea retirar el usuario.
    Debe restar del stock hasta que llegue a 0 o el usuario ingrese el número "0" para salir.

    Punto clave: No permitir retirar más de lo que hay en el stock
    (validación con if dentro del bucle).
*/

Console.Clear();

int stock = 20;
int opcion;

do
{
    Console.Clear();
    Console.WriteLine($"Stock: {stock}.");
    Console.Write("¿Cuantos productos desea retirar? (Puede ingresar '0' para salir)\nR = ");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Error: Dato no válido.");
        return;
    }

    if (opcion > stock)
    {
        Console.Clear();
        Console.Write("No puede retirar esa cantidad, presiona cualquier tecla para continuar.");
        Console.ReadKey();
        continue;
    }

    stock -= opcion;
} while (stock > 0 || opcion == 0);