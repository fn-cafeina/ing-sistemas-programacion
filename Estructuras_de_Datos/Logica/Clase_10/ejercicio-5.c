/*
        EJERCICIO 5

        Desarrolle una aplicación que permita determinar a partir de un numero de días
        ingresado por pantalla. Cuantos años, meses, semanas y días, constituyen el numero de
        días proporcionado.
*/

#include <stdio.h>

#define DAYS_PER_YEAR 365
#define DAYS_PER_MONTH 30
#define DAYS_PER_WEEK 7

void calculate_time(int total_days)
{
        int years, months, weeks, days, remaining_days;

        if (total_days < 0)
        {
                printf("El numero de dias no puede ser negativo.\n");
                return;
        }

        years = total_days / DAYS_PER_YEAR;
        remaining_days = total_days % DAYS_PER_YEAR;

        months = remaining_days / DAYS_PER_MONTH;
        remaining_days %= DAYS_PER_MONTH;

        weeks = remaining_days / DAYS_PER_WEEK;
        days = remaining_days % DAYS_PER_WEEK;

        printf("\n%d dias equivalen a:\n", total_days);
        printf(" -> %d anio(s)\n", years);
        printf(" -> %d mes(es)\n", months);
        printf(" -> %d semana(s)\n", weeks);
        printf(" -> %d dia(s)\n", days);
}

int main(void)
{
        int input_days;

        printf("Ingrese el numero total de dias: ");
        scanf("%d", &input_days);

        calculate_time(input_days);

        return 0;
}