// En una tienda de artículos para caballeros al final del día se carga en la computadora las
// boletas que confeccionaron los distintos vendedores para saber cuanto fue la comisión del día
// de cada uno de ellos. Los datos que se ingresan (por boleta) son: el número de vendedor y el
// importe. Cuando no hay más boletas para cargar se ingresa 0. Teniendo en cuenta que el
// negocio tiene 3 vendedores y que el porcentaje sobre las ventas es del 5%, indicar cuánto ganó
// cada vendedor en el día.

#include <stdio.h>

int main()
{
        int vendedor;
        float importe;
        float totalVendedor1 = 0, totalVendedor2 = 0, totalVendedor3 = 0;
        float comisionVendedor1, comisionVendedor2, comisionVendedor3;

        printf("=== Ingreso de boletas ===\n");
        printf("Ingrese los datos de cada boleta.\n");
        printf("Para finalizar, ingrese 0 como número de vendedor.\n");

        while (1)
        {
                printf("\n- Número de vendedor (1 a 3, o 0 para terminar): ");
                scanf("%d", &vendedor);

                if (vendedor == 0)
                        break;

                if (vendedor < 1 || vendedor > 3)
                {
                        printf("Número de vendedor inválido. Intente de nuevo.\n");
                        continue;
                }

                printf("  - Importe de la boleta: ");
                scanf("%f", &importe);

                if (importe < 0)
                {
                        printf("Importe inválido. Debe ser un número positivo.\n");
                        continue;
                }

                if (vendedor == 1)
                        totalVendedor1 += importe;
                else if (vendedor == 2)
                        totalVendedor2 += importe;
                else if (vendedor == 3)
                        totalVendedor3 += importe;
        }

        comisionVendedor1 = totalVendedor1 * 0.05;
        comisionVendedor2 = totalVendedor2 * 0.05;
        comisionVendedor3 = totalVendedor3 * 0.05;

        printf("\n===== Comisiones del día =====\n");
        printf("- Vendedor 1: $%.2f\n", comisionVendedor1);
        printf("- Vendedor 2: $%.2f\n", comisionVendedor2);
        printf("- Vendedor 3: $%.2f\n", comisionVendedor3);

        return 0;
}
