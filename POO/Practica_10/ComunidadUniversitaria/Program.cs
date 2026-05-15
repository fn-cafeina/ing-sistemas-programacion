/*
    Ejercicios Propuesto 3:

    Enunciado: La universidad desea un sistema centralizado para enviar alertas a la comunidad
    universitaria. Existen tres canales: Correo Electrónico, Mensajería SMS y Notificación Push.

    Instrucciones de desarrollo:
    Defina la estructura de clases necesaria. La clase base debe ser abstracta e incluir
    un método EnviarMensaje(string contenido).
    Para cada canal derivado, la implementación del método debe simular el envío
    (ej. "Enviando Correo a [direccion]: [contenido]").

    Requerimiento Especial: Implemente un menú interactivo que permita al usuario:
    Registrar una nueva notificación (eligiendo el tipo).
    Visualizar todas las notificaciones enviadas hasta el momento.
    Utilice una lista genérica List<> de la clase base para gestionar la memoria de forma dinámica.
*/

public abstract class Canal
{
    protected string contenido;
    protected string direccion;

    public Canal(string contenido, string direccion)
    {
        this.contenido = contenido;
        this.direccion = direccion;
    }

    public abstract string Tipo { get; }

    public abstract void EnviarMensaje(string contenido);

    public override string ToString()
    {
        return $"{Tipo} -> Destino: {direccion}, Mensaje: {contenido}";
    }
}

public class CorreoElectronico : Canal
{
    public CorreoElectronico(string contenido, string direccion) : base(contenido, direccion) { }

    public override string Tipo => "Correo Electronico";

    public override void EnviarMensaje(string contenido)
    {
        this.contenido = contenido;
        Console.WriteLine($"Enviando Correo a [{direccion}]: [{contenido}]");
    }
}

public class MensajeriaSMS : Canal
{
    public MensajeriaSMS(string contenido, string direccion) : base(contenido, direccion) { }

    public override string Tipo => "SMS";

    public override void EnviarMensaje(string contenido)
    {
        this.contenido = contenido;
        Console.WriteLine($"Enviando SMS a [{direccion}]: [{contenido}]");
    }
}

public class NotificacionPush : Canal
{
    public NotificacionPush(string contenido, string direccion) : base(contenido, direccion) { }

    public override string Tipo => "Notificacion Push";

    public override void EnviarMensaje(string contenido)
    {
        this.contenido = contenido;
        Console.WriteLine($"Enviando Push a [{direccion}]: [{contenido}]");
    }
}

public class Program
{
    public static void Main()
    {
        var notificaciones = new List<Canal>();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== Menu de Alertas Universidad ===");
            Console.WriteLine("1. Registrar nueva notificacion");
            Console.WriteLine("2. Mostrar notificaciones enviadas");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opcion: ");

            var opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.WriteLine("Seleccione el canal:");
                Console.WriteLine("1. Correo Electronico");
                Console.WriteLine("2. Mensajeria SMS");
                Console.WriteLine("3. Notificacion Push");
                Console.Write("Opcion: ");

                var tipo = Console.ReadLine();
                if (tipo != "1" && tipo != "2" && tipo != "3")
                {
                    Console.WriteLine("Opcion invalida. Intente de nuevo.");
                    continue;
                }

                Console.Write("Ingrese el destino (correo, telefono o token push): ");
                var direccion = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(direccion))
                {
                    Console.WriteLine("El destino no puede estar vacio.");
                    continue;
                }

                Console.Write("Ingrese el contenido del mensaje: ");
                var mensaje = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(mensaje))
                {
                    Console.WriteLine("El contenido no puede estar vacio.");
                    continue;
                }

                Canal canal = tipo switch
                {
                    "1" => new CorreoElectronico(mensaje, direccion),
                    "2" => new MensajeriaSMS(mensaje, direccion),
                    "3" => new NotificacionPush(mensaje, direccion),
                    _ => throw new InvalidOperationException("Tipo de canal no valido.")
                };

                canal.EnviarMensaje(mensaje);
                notificaciones.Add(canal);
                Console.WriteLine("Notificacion registrada y enviada con exito.");
            }
            else if (opcion == "2")
            {
                Console.WriteLine();
                Console.WriteLine("Notificaciones enviadas:");
                if (notificaciones.Count == 0)
                {
                    Console.WriteLine("No se han enviado notificaciones aun.");
                }
                else
                {
                    for (int i = 0; i < notificaciones.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {notificaciones[i]}");
                    }
                }
            }
            else if (opcion == "3")
            {
                Console.WriteLine("Saliendo del sistema. Hasta luego.");
                break;
            }
            else
            {
                Console.WriteLine("Opcion no valida. Intente nuevamente.");
            }
        }
    }
}