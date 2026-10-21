/*
    1) Practique la edición, la compilación y la ejecución con un programa similar al programa realizado en
    el apartado anterior. Modifíquelo para que ahora realice las operaciones de sumar, restar y
    multiplicar con tres datos: dato1, dato2 y dato3.

    2) En una segunda versión, se pide también combinar las operaciones aritméticas y realizar la lectura de
    valores para cada dato. (Leer datos desde la consola).
*/

int dato1 = 20;
int dato2 = 10;
int dato3 = 30;

string[] signos = ["+", "-", "*", "/"];

for (int i = 0; i < 4; i++)
{
    string formula = $"{dato1} {signos[i]} {dato2} {signos[i]} {dato3}";
    var resultado = new System.Data.DataTable().Compute(formula, null);
    Console.WriteLine($"{formula} = {resultado}");
}

Console.WriteLine("------------------");

Console.WriteLine("Ingrese 2 numeros enteros");
int n1 = Convert.ToInt32(Console.ReadLine());
int n2 = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < 4; i++)
{
    string formula = $"{n1} {signos[i]} {n2}";
    var resultado = new System.Data.DataTable().Compute(formula, null);
    Console.WriteLine($"{formula} = {resultado}");
}