// En un supermercado han realizado una campaña bastante original. En la caja, una
// vez calculado el importe de la compra, se le solicita al cliente que extraiga de una
// bolsa una de las 10 esquelas que hay dentro. Las esquelas están numeradas del 1
// al 10 y tienen premio según la siguiente tabla:
// • Esquelas 1, 2, 3 -----Se le descuenta al cliente un 2% de la compra.
// • Esquela 7 ------Se le descuenta un 10%.
// • Esquelas 9 y 10-----Se le descuenta un 4%.
// • Esquela 8-------Se les descuenta 5%.
// • Las restantes no tienen premio.

#include <stdio.h>
#include <stdlib.h>

int main()
{
        float compra;
        int esquela, descuento = 0;

        printf("Ingrese el monto de la compra: ");
        scanf("%f", &compra);

        printf("Ingrese el numero de la esquela (1 - 10): ");
        scanf("%d", &esquela);

        switch (esquela)
        {
        case 1 ... 3:
                descuento = 2;
                compra -= descuento * compra / 100;
                break;
        case 7:
                descuento = 10;
                compra -= descuento * compra / 100;
                break;
        case 9 ... 10:
                descuento = 4;
                compra -= descuento * compra / 100;
                break;
        case 8:
                descuento = 5;
                compra -= descuento * compra / 100;
                break;
        default:
                break;
        }

        printf("Su compra ha sido de: %.2f con un descuento de: %d%c\n", compra, descuento, '%');

        return 0;
}