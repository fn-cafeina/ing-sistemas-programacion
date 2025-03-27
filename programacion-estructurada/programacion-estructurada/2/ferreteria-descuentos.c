// La ferretería Leiva está ofreciendo descuentos de acuerdo a las siguientes
// condiciones: Si el monto de la compra es menor que C$ 10,000 el descuento será
// del 5%, si el monto es mayor que C$ 10,000 el descuento será del 15%. El cajero desea
// determinar cuál será el monto que debe pagar un cliente por su compra.

#include <stdio.h>

int main()
{
        float montoCompra, precioFinal;
        int descuento;

        printf("Ingrese el monto de la compra: ");
        scanf("%f", &montoCompra);

        if (montoCompra < 10000)
        {
                descuento = 5;
                precioFinal = montoCompra - (descuento * montoCompra / 100);
        }
        else
        {
                descuento = 15;
                precioFinal = montoCompra - (descuento * montoCompra / 100);
        }

        printf("El precio final es de: %.2fC$\n", precioFinal);
        printf("El descuento aplicado es del: %d%c\n", descuento, '%');

        return 0;
}