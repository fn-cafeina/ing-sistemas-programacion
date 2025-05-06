// En un supermercado un cajero captura los precios de los artículos que los clientes
// compran e indica a cada cliente cual es el monto de lo que deben pagar,
// al final del día le indica a su supervisor cuanto fue lo que cobro
// en total a los clientes que pasaron por la caja.

#include <stdio.h>
#include <stdlib.h>

int main()
{
        int hayClientes;
        printf("¿Tuvo clientes el dia de hoy?\n1 - Si\n2 - No\nR = ");
        scanf("%d", &hayClientes);

        if (hayClientes == 2)
                exit(0);

        int cantidadDeArticulos;
        float precioArticulo, montoTotal, monto;

        char respuesta;

        int i = 1, j = 1;

        while (i)
        {
                monto = 0;
                j = 1;

                printf("\nCliente %d\n", i);

                printf("Ingrese la cantidad de articulos comprados: ");
                scanf("%d", &cantidadDeArticulos);

                while (j <= cantidadDeArticulos)
                {
                        printf("Ingrese el precio del articulo #%d: ", j);
                        scanf("%f", &precioArticulo);

                        monto += precioArticulo;

                        j++;
                }

                montoTotal += monto;

                printf("El cliente #%d debera pagar: %.2f\n", i, monto);

                printf("\nHay mas clientes? (s, n): ");
                scanf(" %c", &respuesta);

                if (respuesta != 's')
                        break;

                i++;
        }

        printf("\nEl monto total es de: %.2f\n", montoTotal);

        return 0;
}