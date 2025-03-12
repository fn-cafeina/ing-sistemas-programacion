#include <stdio.h>

int main()
{
        float compra, pago;

        printf("Ingrese el precio de la compra: ");
        scanf("%f", &compra);

        pago = compra - (compra * 0.15);

        printf("El pago total con el descuento aplicado es: %.2f \n", pago);

        return 0;
}