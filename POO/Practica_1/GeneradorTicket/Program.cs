/*
    Ejercicio 3: Generador de Ticket de Venta Simple (Manejo de string
    y operaciones básicas)
    Crea un programa que simule un sistema de cobro rápido para una
    tienda.
    Requerimiento: El programa debe pedir tres datos: 1. El nombre del
    producto (texto), 2. El precio unitario (decimal) y 3. La cantidad
    comprada (entero).
    Salida esperada: Debe mostrar un resumen que diga: "Usted ha
    comprado [cantidad] unidades de [producto]. El total a pagar es: [total]
    dólares".
    Objetivo: Practicar la combinación de diferentes tipos de datos (string,
    double, int) en una misma operación y salida de consola.
*/

Console.Clear();

Console.Write("Ingrese el nombre del producto: ");
string? nombreProducto = Console.ReadLine();

Console.Write("Ingrese el precio unitario: ");
decimal precioUnitario = Convert.ToDecimal(Console.ReadLine());

Console.Write("Ingrese la cantidad de productos comprados: ");
int cantidadComprada = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Usted ha comprado {cantidadComprada} unidades de {nombreProducto}.");
Console.WriteLine($"El total a pagar es: {precioUnitario * cantidadComprada} dólares");