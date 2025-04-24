// Construya un programa que al recibir como datos el nombre, las horas trabajadas, el
// sueldo por hora, calcule e imprima el pago para cada uno de los empleados de una
// empresa. Además, calcule la nómina total, pero no sabemos exactamente cuántos
// empleados existen.

#include <stdio.h>
#include <string.h>
#include <stdlib.h>

void limpiarPantalla()
{
        if (system("cls"))
                system("clear");
}

int main()
{
        char centinela[2] = "s";
        float nominaTotal = 0;

        while (strcmp(centinela, "s") == 0)
        {
                char nombre[50];
                float horasTrabajadas, sueldoHora, pago;

                printf("Nombre del empleado: ");
                scanf("%s", nombre);

                printf("Horas trabajadas: ");
                scanf("%f", &horasTrabajadas);

                printf("Sueldo por hora: ");
                scanf("%f", &sueldoHora);

                pago = horasTrabajadas * sueldoHora;
                nominaTotal += pago;

                printf("\nPago para %s: %.2f\n", nombre, pago);

                printf("\nTeclee s para continuar, n para parar: ");
                scanf("%s", centinela);

                limpiarPantalla();
        }

        printf("La nómina total es: %.2f\n", nominaTotal);

        return 0;
}
