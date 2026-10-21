/*
    Ejercicio 2 – Control de inventario automotriz (Relación Vehículo - Motor)

    Objetivo: Practicar la composición con tipos de datos más técnicos y resolución de ambigüedad.
    
    Clase Motor:
    * Atributos privados: numeroSerie (string) y tipoCombustible (string).
    * Constructor: Usar this obligatoriamente para diferenciar parámetros de atributos.
    * Redefinir ToString(): Retornar: "Motor Serie: [numeroSerie] (Tipo: [tipoCombustible])".

    Clase Vehiculo:
    * Atributos privados: marca (string), modelo (string) y un objeto Motor.
    * Constructor: Recibir marca, modelo y el objeto Motor.
    * Redefinir ToString(): Retornar: "Vehículo: [marca] [modelo] -> [Motor]".

    En el Main:
    * Instanciar un objeto Motor.
    * Instanciar un objeto Vehiculo pasando el motor previamente creado.
    * Mostrar el resultado en consola asegurando que la información del motor se visualice
    correctamente al imprimir el vehículo.
*/

class Motor
{
    private string numeroSerie;
    private string tipoCombustible;

    public Motor(string numeroSerie, string tipoCombustible)
    {
        this.numeroSerie = numeroSerie;
        this.tipoCombustible = tipoCombustible;
    }

    public override string ToString()
    {
        return $"Motor Serie: [{numeroSerie}] (Tipo: [{tipoCombustible}])";
    }
}

class Vehiculo
{
    private string marca;
    private string modelo;
    private Motor motorVehiculo;

    public Vehiculo(string marca, string modelo, Motor motorVehiculo)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.motorVehiculo = motorVehiculo;
    }

    public override string ToString()
    {
        return $"Vehículo: [{marca}] [{modelo}] -> {motorVehiculo}";
    }
}

class Program
{
    static void Main()
    {
        Motor motor1 = new Motor("MZ-987654", "Diésel");
        Vehiculo vehiculo1 = new Vehiculo("Toyota", "Hilux", motor1);

        Console.WriteLine(vehiculo1);
    }
}