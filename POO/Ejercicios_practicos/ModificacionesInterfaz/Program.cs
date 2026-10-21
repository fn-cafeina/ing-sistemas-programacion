using System.Net.Mime;

public interface IArchivable
{
    void Leer();
    void Escribir();
}

public interface IImprimible
{
    void Imprimir();
}

public class Documento : IImprimible, IArchivable
{
    int contenido;

    public Documento(int x1, int x2)
    {
        this.contenido = x1 + x2;
    }

    public void Imprimir()
    {
        Console.WriteLine($"La suma de los valores es: {contenido}");
    }

    public void Leer()
    {
        Console.WriteLine("Leyendo CONTENIDO desde el disco duro");
    }

    public void Escribir()
    {
        Console.WriteLine("Escribiendo CONTENIDO en disco duro");
    }
}

class Program
{
    static void Main()
    {
        Console.Clear();

        Documento unDocumento = new Documento(5, 10);

        unDocumento.Imprimir();
        unDocumento.Leer();
        unDocumento.Escribir();

        Console.WriteLine("-----------------------------");

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}