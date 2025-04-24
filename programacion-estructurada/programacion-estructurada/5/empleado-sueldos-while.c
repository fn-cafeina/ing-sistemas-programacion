// Construya un programa que, al recibir como datos la clave del empleado y los seis
// primeros sueldos del año, calcule el ingreso total semestral y el promedio mensual, e
// imprima la clave del empleado, el ingreso total y el promedio mensual.

#include <stdio.h>

int main()
{

        int claveEmpleado;

        printf("Ingrese la clave del empleado: ");
        scanf("%d", &claveEmpleado);

        float ingresoTotal;

        int i;

        while (i <= 6)
        {
                float sueldo;

                printf("\nIngrese el sueldo #%d: ", i);
                scanf("%f", &sueldo);

                ingresoTotal += sueldo;

                i++;
        }

        float promedioMensual = ingresoTotal / 6;

        printf("\nClave del empleado: %d\n", claveEmpleado);
        printf("Ingreso total del empleado: %.2f\n", ingresoTotal);
        printf("Promedio mensual: %.2f\n", promedioMensual);

        return 0;
}