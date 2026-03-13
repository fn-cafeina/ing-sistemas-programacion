/*
    Ejercicio 2: Calculador de Perímetro y Área de un Rectángulo
    (Manejo de múltiples entradas)
    Desarrolla una aplicación de consola que calcule el área y el perímetro
    de un rectángulo.
    Requerimiento: El programa debe solicitar al usuario la base y la altura
    del rectángulo por separado.
    Salida esperada: El programa debe mostrar en líneas diferentes los dos
    resultados (Ejemplo: "El área es: X" y "El perímetro es: Y").
    Objetivo: Reforzar la captura de múltiples variables, la declaración de
    identificadores significativos y el uso de la concatenación o interpolación
    de cadenas de texto ($"{variable}").
*/

Console.Clear();

Console.Write("Ingrese la base: ");
double base_ = Convert.ToDouble(Console.ReadLine());

Console.Write("Ingrese la altura: ");
double altura = Convert.ToDouble(Console.ReadLine());

var perimetro = 2 * (base_ + altura);
var area = base_ * altura;

Console.WriteLine($"El área es: {area} y el perímetro es: {perimetro}");