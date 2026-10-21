/*
    Ejercicio 1: Convertidor de Temperaturas (Manejo de tipos double)
    Escribe un programa que permita convertir una temperatura dada en
    grados Celsius a grados Fahrenheit.
    Requerimiento: El programa debe solicitar al usuario que ingrese el
    valor en Celsius por teclado.
    Fórmula:
    F=(C×9/5)+32
    Objetivo: Practicar la lectura de datos numéricos con decimales
    (double.Parse o Convert.ToDouble) y el uso de operadores aritméticos.
*/

Console.Clear();

Console.Write("Ingrese la temperatura en Celcius: ");
double C = Convert.ToDouble(Console.ReadLine());
double F = (C * 9 / 5) + 32;

Console.WriteLine($"Temperatura en Fahrenheit: {F}");