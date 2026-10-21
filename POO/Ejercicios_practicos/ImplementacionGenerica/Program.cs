using System;

class Program
{
    // 1. DEFINICIÓN DE LA CLASE GENÉRICA
    // <T> es el "comodín". Representa el tipo de contenido que tendrá el mensaje.
    public class Mensaje<T>
    {
        // Propiedad que almacena el contenido. Su tipo cambia según lo que decidamos al crear el objeto.
        public T Contenido { get; set; }

        // Propiedad normal para registrar la hora de envío (siempre es DateTime)
        public DateTime FechaEnvio { get; set; }

        // Constructor de la clase. Recibe el contenido genérico y guarda la hora actual.
        public Mensaje(T contenido)
        {
            Contenido = contenido; // Guarda el dato (sea texto, número, etc.)
            FechaEnvio = DateTime.Now; // Captura la hora exacta del sistema
        }

        // Método para mostrar los datos en pantalla
        public void Enviar()
        {
            // Imprime la fecha de envío y el contenido sea del tipo que sea
            Console.WriteLine($"[{FechaEnvio}] Mensaje enviado: {Contenido}");
        }
    }

    // 2. DEFINICIÓN DE UN MÉTODO GENÉRICO
    // Este método no pertenece a una clase genérica, pero él mismo puede procesar cualquier tipo de datos.
    // Recibe un mensaje de tipo 'T' y simula un guardado en el disco.
    public static void GuardarEnHistorial<T>(Mensaje<T> mensaje)
    {
        // Indica en la consola que se está guardando el archivo
        Console.WriteLine($"-> Guardando en la base de datos un mensaje de tipo: {typeof(T).Name}");
    }

    // 3. EJECUCIÓN DEL PROGRAMA
    static void Main(string[] args)
    {
        Console.WriteLine("=== INICIO DEL PROGRAMA DE GENÉRICOS ===\n");

        // --- CASO 1: Usando el genérico con texto (string) ---
        // Aquí la 'T' se transforma internamente en 'string'
        Mensaje<string> mensajeTexto = new Mensaje<string>("¡Hola! Esta es una notificación de texto.");

        mensajeTexto.Enviar(); // Llama al método para mostrar el texto

        GuardarEnHistorial(mensajeTexto); // C# detecta automáticamente que T es 'string'

        Console.WriteLine(); // Espacio en blanco en la consola

        // --- CASO 2: Usando el mismo genérico con números (int) ---
        // Aquí la misma 'T' se transforma internamente en 'int'
        Mensaje<int> codigoError = new Mensaje<int>(404);

        codigoError.Enviar(); // Llama al método para mostrar el número

        GuardarEnHistorial(codigoError); // C# detecta automáticamente que T es 'int'

        Console.WriteLine("\n=== FIN DEL PROGRAMA ===");
    }
}