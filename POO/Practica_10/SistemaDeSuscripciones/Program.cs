/*
    5. Caso de Estudio: Sistema de Suscripciones "Claro"

    Contexto:
    La plataforma de "Claro" ofrece diferentes tipos de suscripciones a sus servicios.
    Aunque todas tienen un nombre de usuario y un precio base,
    la forma en que se calcula el costo final varía según el tipo de plan debido a
    impuestos o descuentos específicos.

    Instrucciones para el estudiante:

    Crear la clase abstracta Suscripcion:
    Atributos protegidos: usuario (string) y precioBase (double).
    Constructor que inicialice ambos atributos.
    Método abstracto CalcularPago() que devuelva un double.
    Método concreto MostrarRecibo() que imprima el usuario y el monto a pagar.

    Implementar la clase PlanFamiliar:
    Hereda de Suscripcion.
    Tiene un atributo adicional numeroPerfiles (int).
    Lógica: El pago es el precioBase más un cargo adicional de C$ 50 por cada perfil
    extra (después del primero).

    Implementar la clase PlanEstudiantil:
    Hereda de Suscripcion.
    Lógica: Al ser estudiantes de cualquier entidad educativa,
    tienen un descuento fijo del 40% sobre el precioBase.

    En el Main:
    Instanciar un objeto de cada tipo.
    Demostrar el polimorfismo almacenando ambos en una lista de tipo Suscripcion
    y ejecutando el cobro en un ciclo.
*/

public abstract class Suscripcion
{
    protected string usuario;
    protected double precioBase;

    public Suscripcion(string usuario, double precioBase)
    {
        this.usuario = usuario;
        this.precioBase = precioBase;
    }

    public abstract double CalcularPago();

    public void MostrarRecibo()
    {
        Console.WriteLine($"Usuario: {usuario} | Monto a pagar: {CalcularPago()}");
    }
}

public class PlanFamiliar : Suscripcion
{
    int numeroPerfiles;

    public PlanFamiliar(string usuario, double precioBase, int numeroPerfiles) : base(usuario, precioBase)
    {
        this.numeroPerfiles = numeroPerfiles;
    }

    public override double CalcularPago()
    {
        double pago = precioBase;

        if (numeroPerfiles > 1)
        {
            pago += (numeroPerfiles - 1) * 50;
        }

        return pago;
    }
}

public class PlanEstudiantil : Suscripcion
{
    public PlanEstudiantil(string usuario, double precioBase) : base(usuario, precioBase) { }

    public override double CalcularPago()
    {
        return precioBase * 0.6;
    }
}

public class Program
{
    public static void Main()
    {
        List<Suscripcion> listaDeSuscripciones =
        [
            new PlanFamiliar("Familia Pérez", 300, 4),
            new PlanEstudiantil("Estudiante Juan", 200),
        ];

        foreach (var suscripcion in listaDeSuscripciones)
        {
            suscripcion.MostrarRecibo();
        }
    }
}