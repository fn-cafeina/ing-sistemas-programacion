// int dato1 = 20;
// int dato2 = 10;
// int resultado;

// resultado = dato1 + dato2;
// Console.WriteLine($"{dato1} + {dato2} = {resultado}");

// resultado = dato1 - dato2;
// Console.WriteLine($"{dato1} - {dato2} = {resultado}");

// resultado = dato1 * dato2;
// Console.WriteLine($"{dato1} * {dato2} = {resultado}");

// resultado = dato1 / dato2;
// Console.WriteLine($"{dato1} / {dato2} = {resultado}");

int dato1 = 20;
int dato2 = 10;

string[] signos = ["+", "-", "*", "/"];

for (int i = 0; i < 4; i++)
{
    string formula = $"{dato1} {signos[i]} {dato2}";
    var resultado = new System.Data.DataTable().Compute(formula, null);
    Console.WriteLine($"{formula} = {resultado}");
}