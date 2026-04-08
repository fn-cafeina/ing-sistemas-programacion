/*
    Objetivo: Practicar la validación de datos en el set y el uso de atributos privados.

    Enunciado: Crea una clase llamada Termostato. Esta clase debe controlar la temperatura
    de una habitación.

    Atributo: Crea un atributo privado de tipo entero llamado _temperatura.

    Propiedad: Crea una propiedad pública llamada Temperatura.
    * Get: Debe devolver el valor de _temperatura.
    * Set: Debe validar que la temperatura que se intenta asignar esté entre 15 y 30 grados inclusive. 
    Si el valor está fuera de ese rango, el atributo no debe cambiar (ignora el valor).

    Importante: No utilices constructores. En tu archivo Program.cs, crea un objeto de tipo Termostato, 
    intenta asignarle una temperatura de 10 (debería fallar) y luego una de 22 (debería funcionar).
*/

class Termostato
{
    private int _temperatura;

    public int Temperatura
    {
        get
        {
            return _temperatura;
        }

        set
        {
            if (value >= 15 && value <= 30)
            {
                _temperatura = value;
                Console.WriteLine("Temperatura asignada.");
            }
            else
            {
                Console.WriteLine("No se pudo asignar la temperatura.");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Termostato termostato = new Termostato();

        termostato.Temperatura = 10;
        termostato.Temperatura = 20;
    }
}