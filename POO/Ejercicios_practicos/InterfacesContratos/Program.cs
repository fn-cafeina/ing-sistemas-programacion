/*
    Ejercicio 3: Interfaces (Contratos de Comportamiento)

    Enunciado: En C#, las interfaces son fundamentales.
    Crearemos una interfaz Inotificable para asegurar que diferentes objetos puedan enviar alertas.

    * Define interface INotificable con el método Enviar(string mensaje).
    * Implementa la interfaz en las clases Email y SMS.
    * Crea un método que reciba la interfaz para demostrar el polimorfismo.
*/

public interface INotificable
{
    void Enviar(string mensaje); // Por defecto son public y abstract
}

public class Email : INotificable
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"Enviando Email: {mensaje}");
    }
}

public class SMS : INotificable
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"Enviando SMS: {mensaje}");
    }
}

class Program
{
    static void Main()
    {
        INotificable miNotificador = new Email();
        miNotificador.Enviar("Alerta de sistema");

        miNotificador = new SMS();
        miNotificador.Enviar("Código de acceso: 5542");
    }
}