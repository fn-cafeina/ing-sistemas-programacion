/*
    Ejercicios Propuesto 4:

    Enunciado:
    El concesionario de vehículos "Auto-Sistemas" necesita un módulo para gestionar su inventario.
    El sistema debe permitir manejar diferentes tipos de vehículos. Todos los vehículos poseen un numeroChasis,
    marca y precioBase. Sin embargo, el Costo de Venta Final y el Plan de Mantenimiento se calculan de forma distinta según el tipo de unidad:

    Vehículo de Pasajeros: El costo final es el precioBase más el 15% de IVA. Su mantenimiento se sugiere cada 5,000 km.
    Vehículo de Carga (Camiones): El costo final es el precioBase más el 15% de IVA, pero se le suma un impuesto adicional de "Rodamiento Pesado" de C$ 2,500.
    Su mantenimiento se sugiere cada 10,000 km.

    Instrucciones de desarrollo:
    Estructura: Defina una clase abstracta llamada CVehiculo con los atributos protegidos necesarios y un constructor que los inicialice.
    Abstracción: Declare un método abstracto CalcularCostoFinal() y un método virtual ObtenerMantenimiento() que retorne una cadena de texto.
    Implementación: Cree las clases derivadas CPasajero y CCarga, redefiniendo los métodos según la lógica de negocio planteada en el enunciado.
    Polimorfismo: En la clase principal, declare una List<CVehiculo>. El programa debe permitir al usuario registrar al menos 3 vehículos
    (mezclando tipos) y luego, mediante un solo ciclo foreach, imprimir una "Ficha Técnica" que muestre:
    Marca y Chasis.
    Costo Final (aplicando el cálculo polimórfico).
    Recomendación de mantenimiento.
*/

abstract class CVehiculo
{
    protected string numeroChasis;
    protected string marca;
    protected double precioBase;

    protected CVehiculo(string numeroChasis, string marca, double precioBase)
    {
        this.numeroChasis = numeroChasis;
        this.marca = marca;
        this.precioBase = precioBase;
    }

    public abstract double CalcularCostoFinal();

    public virtual string ObtenerMantenimiento()
    {
        return "No disponible";
    }

    public virtual void MostrarFichaTecnica()
    {
        Console.WriteLine("====================================");
        Console.WriteLine($"Marca: {marca}");
        Console.WriteLine($"Chasis: {numeroChasis}");
        Console.WriteLine($"Costo Final: C$ {CalcularCostoFinal():F2}");
        Console.WriteLine($"Recomendación de mantenimiento: {ObtenerMantenimiento()}");
    }
}

class CPasajero : CVehiculo
{
    public CPasajero(string numeroChasis, string marca, double precioBase) : base(numeroChasis, marca, precioBase) { }

    public override double CalcularCostoFinal()
    {
        return precioBase + (precioBase * 0.15);
    }

    public override string ObtenerMantenimiento()
    {
        return "Cada 5,000 km";
    }

    public override void MostrarFichaTecnica()
    {
        Console.WriteLine("=== Vehículo de Pasajeros ===");
        base.MostrarFichaTecnica();
    }
}

class CCarga : CVehiculo
{
    public CCarga(string numeroChasis, string marca, double precioBase) : base(numeroChasis, marca, precioBase) { }

    public override double CalcularCostoFinal()
    {
        return precioBase + (precioBase * 0.15) + 2500;
    }

    public override string ObtenerMantenimiento()
    {
        return "Cada 10,000 km";
    }

    public override void MostrarFichaTecnica()
    {
        Console.WriteLine("=== Vehículo de Carga ===");
        base.MostrarFichaTecnica();
    }
}

class Program
{
    static void Main()
    {
        const int minimoVehiculos = 3;
        int cantidadVehiculos;

        while (true)
        {
            Console.Write($"Ingrese la cantidad de vehículos a registrar (mínimo {minimoVehiculos}): ");
            string entrada = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(entrada, out cantidadVehiculos) && cantidadVehiculos >= minimoVehiculos)
            {
                break;
            }
            Console.WriteLine($"Cantidad inválida. Ingrese un número entero mayor o igual a {minimoVehiculos}.");
        }

        var inventario = new List<CVehiculo>();

        for (int i = 1; i <= cantidadVehiculos; i++)
        {
            Console.WriteLine($"\nRegistro de vehículo #{i}");

            string tipo;
            while (true)
            {
                Console.Write("Tipo de vehículo (1 - Pasajero, 2 - Carga): ");
                tipo = (Console.ReadLine() ?? string.Empty).Trim();
                if (tipo == "1" || tipo == "2")
                {
                    break;
                }
                Console.WriteLine("Tipo inválido. Ingrese 1 para Pasajero o 2 para Carga.");
            }

            string numeroChasis;
            while (true)
            {
                Console.Write("Número de chasis: ");
                numeroChasis = Console.ReadLine()?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(numeroChasis))
                {
                    break;
                }
                Console.WriteLine("El número de chasis no puede quedar vacío.");
            }

            string marca;
            while (true)
            {
                Console.Write("Marca: ");
                marca = Console.ReadLine()?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(marca))
                {
                    break;
                }
                Console.WriteLine("La marca no puede quedar vacía.");
            }

            double precioBase;
            while (true)
            {
                Console.Write("Precio base: ");
                string entradaPrecio = Console.ReadLine() ?? string.Empty;
                if (double.TryParse(entradaPrecio, out precioBase) && precioBase >= 0)
                {
                    break;
                }
                Console.WriteLine("Precio inválido. Ingrese un número mayor o igual a 0.");
            }

            CVehiculo vehiculo = tipo == "1"
                ? new CPasajero(numeroChasis, marca, precioBase)
                : new CCarga(numeroChasis, marca, precioBase);

            inventario.Add(vehiculo);
        }

        Console.WriteLine("\n=== Fichas Técnicas del Inventario ===\n");
        foreach (CVehiculo vehiculo in inventario)
        {
            vehiculo.MostrarFichaTecnica();
        }
    }
}
