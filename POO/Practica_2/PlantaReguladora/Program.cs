/*
    Planta Reguladora (If, if else, TryParse)

    Problema: En una planta de tratamiento de agua, un sensor de presión envía lecturas
    manuales que un operario debe registrar en el sistema.
    El sistema debe evaluar si la presión ingresada es segura para la tubería principal.

    Requerimientos: El sistema debe solicitar al usuario que ingrese el valor de la presión actual (en PSI).
    Dado que el dato se recibe como una cadena de texto (string),
    debe convertirse a un valor numérico decimal (double).
    Se debe utilizar double.TryParse para validar que el operario ingresó un número válido.

    Puntos clave: Si la presión es mayor a 150.5 PSI,
    el sistema debe mostrar un mensaje de "ALERTA: Presión excesiva. Abrir válvulas de escape.“
    Si la presión es menor o igual a 150.5 PSI,
    el sistema debe mostrar un mensaje de "ESTADO: Presión bajo control. Operación normal.“
    Si el usuario ingresa texto no numérico (ejemplo: "abc" o "diez"),
    el sistema debe informar un "Error de entrada: El valor ingresado no es un número válido."
*/

Console.Write("Ingrese la presión del agua actual (PSI): ");
if (double.TryParse(Console.ReadLine(), out double presionAgua))
{
    if (presionAgua > 150.5)
    {
        Console.WriteLine("ALERTA: Presión excesiva. Abrir válvulas de escape.");
    }
    else
    {
        Console.WriteLine("ESTADO: Presión bajo control. Operación normal.");
    }
}
else
{
    Console.WriteLine("Error de entrada: El valor ingresado no es un número válido.");
}