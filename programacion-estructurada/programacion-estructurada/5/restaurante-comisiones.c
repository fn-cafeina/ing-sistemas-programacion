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

enum tipoVenta
{
        contado = 1,
        cheque,
        tarjeta
};

int main()
{
        int meseros, ventas, tipo, i, j;
        float ventaActual, totalComision, comisionVenta, comisionTipo;

        printf("Ingrese la cantidad de meseros: ");
        scanf("%d", &meseros);

        for (i = 1; i <= meseros; i++)
        {
                totalComision = 0;

                printf("\nIngrese la cantidad de ventas para el mesero #%d: ", i);
                scanf("%d", &ventas);

                for (j = 1; j <= ventas; j++)
                {
                        printf("Ingrese la venta #%d y el tipo de venta (1: contado; 2: cheque; 3: tarjeta): ", j);
                        scanf("%f %d", &ventaActual, &tipo);

                        comisionVenta = ventaActual * 0.07;

                        if (tipo == contado)
                                comisionTipo = ventaActual * 0.15;
                        else if (tipo == cheque)
                                comisionTipo = ventaActual * 0.10;
                        else if (tipo == tarjeta)
                                comisionTipo = ventaActual * 0.05;

                        totalComision += comisionVenta + comisionTipo;
                }

                printf("\nEl total a pagar al mesero #%d es: %.2f\n", i, totalComision);
        }

        return 0;
}
