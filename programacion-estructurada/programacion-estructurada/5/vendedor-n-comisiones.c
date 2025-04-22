// Un vendedor desea calcular la comisión total sobre la venta de varios artículos. Al vendedor
// le corresponde el 10% de comisión sobre artículos, cuyo precio es menor o igual a $1000 y el
// 7% de comisión sobre aquellos artículos cuyo precio sea mayor de $1000. Elabore un
// programa para obtener la comisión total, si se conoce que el vendedor hizo N ventas.

#include <stdio.h>
#include <stdlib.h>

void limpiarBuffer()
{
        while (getchar() != '\n')
                ;
}

int main()
{
        if (system("cls"))
                system("clear");

        int nVentas;
        int esValido;
        float valorArticulo, pagoComisiones;

        printf("Ingrese la cantidad de ventas: ");
        esValido = scanf("%d", &nVentas);

        if (esValido)
        {
                if (nVentas <= 0)
                {
                        printf("\nIngrese un numero de ventas positivos.\n");
                        return 1;
                }
        }
        else
        {
                printf("\nIngrese un tipo de dato valido.\n");
                return 1;
        }

        int i;

        for (i = 1; i <= nVentas; i++)
        {
                printf("\nIngrese el precio del articulo vendido #%d: $", i);
                esValido = scanf("%f", &valorArticulo);

                if (esValido)
                {
                        if (valorArticulo <= 0)
                        {
                                printf("\nAl parecer regaló un articulo, esto afectara su pago.\n");
                                limpiarBuffer();
                                continue;
                        }

                        if (valorArticulo <= 1000)
                                pagoComisiones += valorArticulo * 0.1;
                        else
                                pagoComisiones += valorArticulo * 0.07;
                }
                else
                {
                        printf("\nIngrese un tipo de dato valido, volviendo a iterar...\n");
                        limpiarBuffer();
                        i--;
                        continue;
                }
        }

        printf("\nEl pago total de las comisiones de %d ventas es de: $%.2f\n", nVentas, pagoComisiones);

        return 0;
}