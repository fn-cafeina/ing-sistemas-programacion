/*
    Ejercicios Propuesto 1:

    Enunciado: Una empresa de logística necesita un módulo para calcular
    el costo de envío de diferentes tipos de paquetes.
    Se ha definido una clase abstracta CPaquete que obliga a
    cada tipo de envío a calcular su propio costo.

    Instrucciones: Complete los espacios en blanco (__________)
    con las palabras reservadas o identificadores correctos para que el
    código sea funcional y aplique los conceptos de abstracción y herencia.
*/

using System;
using System.Collections.Generic;
using LogisticaUNAN;

namespace LogisticaUNAN
{
    // Definición de la clase base que no puede ser instanciada
    public abstract class CPaquete
    {
        protected string codigo;
        protected double peso;

        public CPaquete(string codigo, double peso)
        {
            this.codigo = codigo;
            this.peso = peso;
        }

        // Método que obliga a las clases hijas a implementar su lógica
        public abstract double CalcularCosto();

        public virtual void MostrarDetalle()
        {
            Console.WriteLine($"Paquete: {codigo} | Peso: {peso}kg");
        }
    }

    public class CEnvioNacional : CPaquete
    {
        public CEnvioNacional(string cod, double p) : base(cod, p) { }

        // Implementación del cálculo: C$ 20 por kilo
        public override double CalcularCosto()
        {
            return peso * 20;
        }
    }
}

class Program
{
    static void Main()
    {
        // Uso de polimorfismo con una lista de la clase base
        // List<CPaquete> listaEnvios = new List<CPaquete>();

        // listaEnvios.Add(new CEnvioNacional("NAC-001", 10.5));

        // foreach (CPaquete item in listaEnvios)
        // {
        //     item.MostrarDetalle();
        //     Console.WriteLine($"Costo: C$ {item.CalcularCosto()}");
        // }

        List<CPaquete> listaEnvios = new List<CPaquete>();

        int cantidadDeEnvios;
        while (true)
        {
            Console.Write("Ingrese la cantidad de envíos: ");
            string entradaCantidad = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(entradaCantidad, out cantidadDeEnvios) && cantidadDeEnvios > 0)
            {
                break;
            }
            Console.WriteLine("Cantidad inválida. Ingrese un número entero mayor a 0.");
        }

        for (int i = 1; i <= cantidadDeEnvios; i++)
        {
            Console.WriteLine($"\nEnvío #{i}");

            string codigo;
            while (true)
            {
                Console.Write("Código: ");
                codigo = Console.ReadLine()?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(codigo))
                {
                    break;
                }
                Console.WriteLine("Código inválido. El código no puede quedar vacío.");
            }

            double peso;
            while (true)
            {
                Console.Write("Peso (kg): ");
                string entradaPeso = Console.ReadLine() ?? string.Empty;
                if (double.TryParse(entradaPeso, out peso) && peso > 0)
                {
                    break;
                }
                Console.WriteLine("Peso inválido. Ingrese un número mayor a 0.");
            }

            listaEnvios.Add(new CEnvioNacional(codigo, peso));
        }

        Console.WriteLine("\nResumen de envíos:");
        foreach (CPaquete item in listaEnvios)
        {
            item.MostrarDetalle();
            Console.WriteLine($"Costo: C$ {item.CalcularCosto():F2}");
        }
    }
}