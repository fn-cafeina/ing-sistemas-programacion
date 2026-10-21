/*
    Enunciado: Crea una clase llamada Habitación.

    Atributos: Numero (int), Tipo (string) y Precio (double).

    Constructores:
    Un constructor que reciba los 3 parámetros.
    Un constructor que reciba solo Numero y Tipo, y asigne un precio de 0.0 por defecto mediante
    encadenamiento (this).

    Destructor: Implementa un destructor que imprima un mensaje: "La habitación [Numero] ha sido
    liberada de la memoria".

    Prueba: En el Main, crea un objeto y luego asígnale null. Nota: El destructor puede no ejecutarse
    inmediatamente a menos que llames a GC.Collect(), pero debes escribir la sintaxis correcta.
*/

class Habitacion
{
    public int Numero { get; set; }
    public string Tipo { get; set; }
    public double Precio { get; set; }

    public Habitacion(int numero, string tipo, double precio)
    {
        Numero = numero;
        Tipo = tipo;
        Precio = precio;
    }

    public Habitacion(int numero, string tipo) : this(numero, tipo, 0.0) { }

    ~Habitacion()
    {
        Console.WriteLine($"La habitación [{Numero}] ha sido liberada de la memoria");
    }
}

class Program
{
    static void Main()
    {
        CrearHabitacion();

        GC.Collect();
        GC.WaitForPendingFinalizers();

        static void CrearHabitacion()
        {
            Habitacion h = new Habitacion(101, "Individual", 250.0);
            Console.WriteLine($"Se creó la habitación [{h.Numero}]");
        }
    }
}