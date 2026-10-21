// Dada las horas trabajadas de una persona y el valor por hora.
// Calcular su salario e imprimirlo.

#include <stdio.h>
#include <stdlib.h>

int main()
{
        int horasTrabajadas;
        float salario, pagoPorHora;

        printf("Ingrese el valor por horas: ");
        scanf("%f", &pagoPorHora);

        printf("Ingrese las horas trabajadas: ");
        scanf("%d", &horasTrabajadas);

        salario = horasTrabajadas * pagoPorHora;

        system("clear");

        printf("Las horas trabajadas son: %d y el salario es de: %.2f \n", horasTrabajadas, salario);

        return 0;
}