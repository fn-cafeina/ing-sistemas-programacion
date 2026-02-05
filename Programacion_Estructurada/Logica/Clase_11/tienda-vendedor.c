// Escribir un programa en C que lea un array de N * 5 indicando
// que una empresa tiene N vendedores cada uno de los cuales vende
// 5 productos. El array almacena los ingresos obtenidos por cada
// vendedor en cada producto, imprimir el total de cada vendedor y
// obtener los ingresos totales de la tienda.

#include <stdio.h>

#define PRODUCTOS 5

int main()
{
        int n, i, j;
        float ingresosTotal = 0;

        printf("Numero de vendedores: ");
        scanf("%d", &n);

        float ventas[n][PRODUCTOS];
        float totalVendedor[n];

        printf("\nIngrese los ingresos por producto:\n");
        for (i = 0; i < n; i++)
        {
                printf("\nVendedor %d:\n", i + 1);
                totalVendedor[i] = 0;

                for (j = 0; j < PRODUCTOS; j++)
                {
                        printf("Producto %d: ", j + 1);
                        scanf("%f", &ventas[i][j]);
                        totalVendedor[i] += ventas[i][j];
                }

                ingresosTotal += totalVendedor[i];
        }

        printf("\nTotales por vendedor:\n");
        for (i = 0; i < n; i++)
        {
                printf("Vendedor %d: %.2f\n", i + 1, totalVendedor[i]);
        }

        printf("\nIngresos totales de la tienda: %.2f\n", ingresosTotal);

        return 0;
}