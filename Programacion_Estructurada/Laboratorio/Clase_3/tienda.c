// Una tienda ofrece un descuento del 15% sobre el total de la compra
// y un cliente desea saber cuanto deberá pagar finalmente por su compra.

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