/*
    Ejercicio 3: Herencia de Interfaces (Gestión de Farmacia)

    Enunciado: Desarrolle un sistema de control para productos farmacéuticos utilizando el
    concepto de herencia múltiple de interfaces.

    -Interfaz IVentable: Debe declarar un método CalcularPrecio(double costo).
    -Interfaz IAlmacenable: Debe declarar un método VerificarLote(string codigo).
    -Interfaz Derivada IMedicamentoEspecializado: Esta interfaz debe heredar de las dos
    anteriores e incluir un método propio llamado ValidarReceta(string medico).
    -Clase Antibiotico: Debe implementar la interfaz derivada. La clase debe incluir un
    atributo propio string nombreGenerico. Al implementar los métodos, debe mostrar la
    información en consola incluyendo el nombre del medicamento.
*/

interface IVentable
{
    void CalcularPrecio(double costo);
}

interface IAlmacenable
{
    void VerificarLote(string codigo);
}

interface IMedicamentoEspecializado : IVentable, IAlmacenable
{
    void ValidarReceta(string medico);
}

public class Antibiotico : IMedicamentoEspecializado
{
    protected string nombreGenerico;

    public Antibiotico(string nombreGenerico)
    {
        this.nombreGenerico = nombreGenerico;
    }

    public void CalcularPrecio(double costo)
    {
        double precioFinal = costo * 1.20;

        Console.WriteLine($"{nombreGenerico} | Precio final: ${precioFinal:N2}");
    }

    public void VerificarLote(string codigo)
    {
        Console.WriteLine($"{nombreGenerico} | Lote verificado: {codigo}");
    }

    public void ValidarReceta(string medico)
    {
        Console.WriteLine($"{nombreGenerico} | Receta validada por Dr. {medico}");
    }
}

class Program
{
    static void Main()
    {
        Antibiotico medicamento = new Antibiotico("Amoxicilina");

        medicamento.CalcularPrecio(25.50);
        medicamento.VerificarLote("LOT-2026");
        medicamento.ValidarReceta("Martínez");
    }
}