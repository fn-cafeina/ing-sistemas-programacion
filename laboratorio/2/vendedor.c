#include <stdio.h>

int main()
{
        float sueldoBase, venta1, venta2, venta3, comisiones, pagoFinal;

        printf("Ingrese el sueldo base: ");
        scanf("%f", &sueldoBase);

        printf("Ingrese la venta 1: ");
        scanf("%f", &venta1);

        printf("Ingrese la venta 2: ");
        scanf("%f", &venta2);

        printf("Ingrese la venta 3: ");
        scanf("%f", &venta3);

        comisiones = (venta1 * 0.1) + (venta1 * 0.1) + (venta3 * 0.1);

        pagoFinal = sueldoBase + comisiones;

        printf("El pago total del sueldo base mas las comisiones es de: %.2f \n", pagoFinal);

        return 0;
}