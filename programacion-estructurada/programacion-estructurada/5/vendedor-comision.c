// Un vendedor desea calcular la comisión total sobre la venta de varios artículos. Al vendedor
// le corresponde el 10% de comisión sobre artículos, cuyo precio es menor o igual a $1000 y el
// 7% de comisión sobre aquellos artículos cuyo precio sea mayor de $1000. Elabore un
// programa para obtener la comisión total, si se conoce que el vendedor hizo N ventas.

#include <stdio.h>
#include <stdlib.h>

int main()
{
        int n, i;
        float precio, comision = 0;

        printf("Ingrese la cantidad de ventas realizadas: ");
        scanf("%d", &n);

        if (n < 1)
        {
                printf("Ingrese un número válido de ventas.\n");
                exit(0);
        }

        for (i = 0; i < n; i++)
        {
                printf("Ingrese el precio del artículo %d: ", i + 1);
                scanf("%f", &precio);

                if (precio <= 1000)
                        comision += precio * 0.10;
                else
                        comision += precio * 0.07;
        }

        printf("La comisión total del vendedor es: $%.2f\n", comision);

        return 0;
}
