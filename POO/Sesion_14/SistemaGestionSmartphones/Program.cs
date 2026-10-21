/*
    Ejercicio 1: Referencia this e Inicialización de Objetos

    Contexto: Sistema de Gestión de Smartphones

    Objetivo: El estudiante deberá demostrar el uso correcto de la palabra reservada this para
    resolver la ambigüedad entre los parámetros del constructor y los atributos de la clase,
    además de inicializar correctamente el estado del objeto.

    Enunciado:
    Crea una clase llamada Smartphone que permita registrar las especificaciones
    de un dispositivo.

    Atributos (Privados):
    * marca (string)
    * modelo (string)
    * ram (int) - Representa los GB de memoria.
    * almacenamiento (int) - Representa los GB de espacio.

    Constructor:
    *Debe recibir 4 parámetros con los mismos nombres que los atributos 
    (ejemplo: public Smartphone(string marca, string modelo...)).
    * Es obligatorio usar this para asignar los valores de los parámetros a los atributos de
    la clase.

    Métodos:
    * MostrarEspecificaciones(): Debe imprimir en consola un mensaje con el formato:
    "Smartphone: [marca] [modelo] | RAM: [ram]GB | Espacio: [almacenamiento]GB".
    * ActualizarAlmacenamiento(int almacenamiento): Este método debe recibir un
    nuevo valor y actualizar el atributo del objeto usando this para evitar confusiones.

    Clase Principal (Program):
    * Instanciar dos objetos Smartphone con diferentes datos.
    * Llamar al método MostrarEspecificaciones() para cada uno.
    * Actualizar el almacenamiento de uno de ellos y mostrar los datos nuevamente.
*/

class Smartphone
{
    private string marca;
    private string modelo;
    private int ram;
    private int almacenamiento;

    public Smartphone(string marca, string modelo, int ram, int almacenamiento)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.ram = ram;
        this.almacenamiento = almacenamiento;
    }

    public void MostrarEspecificaciones()
    {
        Console.WriteLine($"Smartphone: {this.marca} {this.modelo} | RAM: {this.ram}GB | Espacio: {this.almacenamiento}GB");
    }

    public void ActualizarAlmacenamiento(int almacenamiento)
    {
        this.almacenamiento = almacenamiento;
    }
}

class Program
{
    static void Main()
    {
        Smartphone s1 = new Smartphone("Samsung", "S23", 8, 128);
        Smartphone s2 = new Smartphone("iPhone", "15", 6, 256);

        s1.MostrarEspecificaciones();
        s2.MostrarEspecificaciones();

        s1.ActualizarAlmacenamiento(512);

        s1.MostrarEspecificaciones();
    }
}