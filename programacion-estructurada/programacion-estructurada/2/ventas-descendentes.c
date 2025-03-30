// Realice un programa en C que, al recibir como datos las ventas de tres vendedores
// de una librería, imprima las mismas en forma descendente.

#include <stdio.h>

int main()
{
        int venta1, venta2, venta3;

        printf("Ingrese las ventas de los 3 vendedores:\n");
        scanf("%d %d %d", &venta1, &venta2, &venta3);

        if (venta1 > venta2 && venta1 > venta3)
        {
                if (venta2 > venta3)
                        printf("%d %d %d\n", venta1, venta2, venta3);
                else
                        printf("%d %d %d\n", venta1, venta3, venta2);
        }
        else if (venta2 > venta1 && venta2 > venta3)
        {
                if (venta1 > venta3)
                        printf("%d %d %d\n", venta2, venta1, venta3);
                else
                        printf("%d %d %d\n", venta2, venta3, venta1);
        }
        else
        {
                if (venta1 > venta2)
                        printf("%d %d %d\n", venta3, venta1, venta2);
                else
                        printf("%d %d %d\n", venta3, venta2, venta1);
        }

        return 0;
}