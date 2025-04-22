// Un restaurante paga a sus meseros dos clases de comisiones:
// • Una comisión del 7% sobre toda venta.
// • Otra comisión que depende del tipo de venta: 15% si la venta es de contado, 10% si la
// venta se hizo en cheque y, 5% si se hizo con tarjeta de crédito.
// El restaurante tiene por cada venta:
// Identificación del vendedor(1, 2, 3)
// Tipos de ventas(1: contado; 2: cheque; 3: tarjeta)
// Cuantía de la venta.
// Elaborar un programa que obtenga el total a pagar a cada uno de los empleados.

#include <stdio.h>
#include <stdlib.h>

void limpiarPantalla()
{
        if (system("cls"))
                system("clear");
}

void limpiarBuffer()
{
        while (getchar() != '\n')
                ;
}

enum tipoVenta
{
        contado = 1,
        cheque,
        tarjeta
};

int main()
{
        limpiarPantalla();

        int meseros;

        printf("\nIngrese la cantidad de meseros: ");

        if (!scanf("%d", &meseros) || meseros <= 0)
        {
                printf("\nIngrese un dato valido.\n");
                return 1;
        }

        limpiarBuffer();

        int i = 1;
        do
        {
                printf("\nEvaluación del mesero #%d\n", i);
                int ventas;
                printf("Ingrese la cantidad de ventas para este mesero: ");

                if (!scanf("%d", &ventas) || ventas < 0)
                {
                        printf("\nIngrese un dato valido.\n");
                        return 1;
                }

                limpiarBuffer();

                float totalComision = 0.0;
                int j = 1;
                do
                {
                        float ventaActual;
                        enum tipoVenta tipo;

                        printf("Ingrese la venta #%d y el tipo de venta (1: contado; 2: cheque; 3: tarjeta): ", j);

                        if (scanf("%f%d", &ventaActual, &tipo) != 2 || ventaActual < 0 || tipo > tarjeta || tipo < contado)
                        {
                                printf("\nIngrese un dato valido, volviendo a iterar...\n");
                                limpiarBuffer();
                                continue;
                        }

                        limpiarBuffer();

                        float comisionVenta = ventaActual * 0.07;
                        float comisionTipo;

                        switch (tipo)
                        {
                        case contado:
                                comisionTipo = ventaActual * 0.15;
                                break;
                        case cheque:
                                comisionTipo = ventaActual * 0.10;
                                break;
                        case tarjeta:
                                comisionTipo = ventaActual * 0.05;
                                break;
                        }

                        totalComision += comisionVenta + comisionTipo;
                        j++;
                } while (j <= ventas);

                printf("\nEl total a pagar al mesero #%d es: %.2f\n", i, totalComision);
                i++;
        } while (i <= meseros);

        return 0;
}