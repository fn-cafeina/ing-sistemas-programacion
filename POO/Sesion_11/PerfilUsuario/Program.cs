/*
    Objetivo: Practicar propiedades de solo lectura (get público, set privado) y sobrecarga de métodos.
    Enunciado: Crea una clase llamada PerfilUsuario.

    1. Atributos y Propiedades:
    * Crea una propiedad para el NombreUsuario. El get debe ser público, pero el set debe ser privado 
    (simulando que el nombre no se puede cambiar desde fuera una vez asignado internamente).
    * Crea una propiedad pública para la Biografia (con get y set normales).
    2. Método Sobrecargado: Crea un método llamado PublicarEstado.
    * Versión 1: No recibe parámetros y solo imprime: "El usuario está en línea".
    * Versión 2: Recibe un string con un mensaje e imprime: "NombreUsuario dice: [mensaje]".

    3. Importante: No utilices constructores ni destructores. 
    Para probar el set privado, intenta asignar un valor inicial al atributo
    privado directamente en la clase y observa cómo desde Program.cs no puedes modificar el NombreUsuario.
*/

class PerfilUsuario
{
    private string _nombre_usuario = "Cafeina";

    public string NombreUsuario
    {
        get
        {
            return _nombre_usuario;
        }
        private set
        {
            _nombre_usuario = value;
        }
    }

    public string? Biografia { get; set; }

    public void PublicarEstado()
    {
        Console.WriteLine("El usuario está en línea");
    }

    public void PublicarEstado(string mensaje)
    {
        Console.WriteLine($"{NombreUsuario} dice: [ {mensaje} ]");
    }
}

class Program
{
    static void Main()
    {
        PerfilUsuario miPerfil = new PerfilUsuario();

        // miPerfil.NombreUsuario = "NuevoNombre"; 

        miPerfil.PublicarEstado();

        miPerfil.PublicarEstado("Hola");
    }
}