/*
    Simulador de Ventas con Descuento por Volumen (Switch + Casting)

    • Problema: Un cliente compra camisas. El precio base es 300 C$.

    • Requerimiento: Pedir la cantidad. Si compra de 1 a 5 (sin descuento),
    de 6 a 12 (10% desc), más de 12 (20% desc).

    • Punto clave: El usuario debe elegir el tipo de pago (1. Efectivo, 2. Tarjeta).

    Si es tarjeta, se aplica un recargo del 5% al total final.

    Mostrar el total final como un número entero (usar casting).
*/

Console.Clear();

int precioBase = 300;

Console.Write("¿Cuántas camisas compró?\nR = ");
if (!int.TryParse(Console.ReadLine(), out int cantidadCamisas))
{
    Console.WriteLine("Error: Tipo de dato no válido");
    return;
}

Console.Write("Tipo de pago (1. Efectivo, 2. Tarjeta)\nR = ");
if (!int.TryParse(Console.ReadLine(), out int tipoDePago))
{
    Console.WriteLine("Error: Tipo de dato no válido");
    return;
}

double subtotal = cantidadCamisas * precioBase;

double totalConDescuento = cantidadCamisas switch
{
    > 12 => subtotal * 0.80,
    >= 6 => subtotal * 0.90,
    _ => subtotal
};

if (tipoDePago == 2)
{
    totalConDescuento *= 1.05;
}

Console.WriteLine($"\nEl total final es: {(int)totalConDescuento}");