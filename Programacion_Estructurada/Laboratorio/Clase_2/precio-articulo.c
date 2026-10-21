#include <stdio.h>

int main()
{
        float pgr, desc, precio;

        printf("Ingrese el precio del articulo: ");
        scanf("%f", &precio);

        desc = precio * 0.5;

        pgr = precio - desc;

        printf("Total a pagar: %f \n", pgr);

        return 0;
}