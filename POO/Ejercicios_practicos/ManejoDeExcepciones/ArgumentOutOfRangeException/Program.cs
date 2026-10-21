using System;

namespace Articulos.Cap04.Excepciones.Parte5
{
    public class Invitado
    {
        private String Nombre;
        private String Apellido;
        private int Edad;

        public Invitado(String nombre, String apellido, int edad)
        {
            Nombre = nombre;
            Apellido = apellido;

            // Valida que el invitado no sea menor de 30 años.
            if (edad <= 30)
            {
                throw new ArgumentOutOfRangeException(
                    "edad",
                    "Los invitados deben ser mayores de 30.");
            }
            else
            {
                Edad = edad;
            }
        }

        // Muestra resumen del invitado:
        public override String ToString()
        {
            return String.Format(
                "Nombre: {0} - Apellido: {1} - Edad: {2}",
                Nombre,
                Apellido,
                Edad
            );
        }
    }

    public class Program
    {
        public static void Main()
        {
            Invitado invitado1 = new Invitado("Jasmir", "Medina", 20);
        }
    }
}