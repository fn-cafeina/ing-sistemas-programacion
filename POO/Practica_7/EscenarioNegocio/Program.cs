/*
    Ejercicio 1: crear un proyecto de consola en C# que modele el siguiente escenario de negocio
    utilizando Programación Orientada a Objetos:

    Clase Cliente:
    Atributos privados: nombre y cedula.
    Constructor que reciba ambos parámetros usando this para resolver la ambigüedad.
    Redefinir ToString() para que retorne: "Cliente: [nombre] - ID: [cedula]".

    Clase Pedido (Aplica Composición):
    Atributos privados: numeroPedido, montoTotal y un objeto de tipo Cliente (el autor del pedido).
    Constructor que reciba el número, el monto y el objeto Cliente.
    Redefinir ToString() para que retorne una cadena con el formato:
    "Pedido N°: [numero] | Monto: C$ [monto] | [Datos del Cliente]". (Debe aprovechar el ToString del cliente
    implícitamente).

    Clase Program (Main):
    Instanciar al menos dos objetos Cliente.
    Instanciar al menos dos objetos Pedido pasándoles los clientes creados.
    Imprimir en consola los pedidos usando Console.WriteLine(pedido1); para demostrar que el override de
    ToString() funciona correctamente en cascada.
*/

class Cliente
{
    private string nombre;
    private string cedula;

    public Cliente(string nombre, string cedula)
    {
        this.nombre = nombre;
        this.cedula = cedula;
    }

    public override string ToString()
    {
        return $"Cliente: [{nombre}] - ID: [{cedula}]";
    }
}

class Pedido
{
    private int numeroPedido;
    private decimal montoTotal;
    private Cliente autorPedido;

    public Pedido(int numeroPedido, decimal montoTotal, Cliente autorPedido)
    {
        this.numeroPedido = numeroPedido;
        this.montoTotal = montoTotal;
        this.autorPedido = autorPedido;
    }

    public override string ToString()
    {
        return $"Pedido N°: [{numeroPedido}] | Monto: C$ [{montoTotal}] | {autorPedido}";
    }
}

class Program
{
    static void Main()
    {
        Cliente cliente1 = new Cliente("Roberto Silva", "001-150685-0002A");
        Cliente cliente2 = new Cliente("María Fonseca", "281-220990-1005F");

        Pedido pedido1 = new Pedido(1001, 4500.50m, cliente1);
        Pedido pedido2 = new Pedido(1002, 1250.00m, cliente2);

        Console.WriteLine(pedido1);
        Console.WriteLine(pedido2);
    }
}