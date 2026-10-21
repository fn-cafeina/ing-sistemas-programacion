// Escribe 4 programas en C utilizando el método burbuja, el ejercicio puede ser de su elección.

#include <stdio.h>
#include <stdlib.h>

#define CANTIDAD_FECHAS 6

typedef struct
{
        int dia;
        int mes;
        int anio;
} Fecha;

void bubble_sort_fechas(Fecha *, size_t);
void imprimir_fechas(Fecha *, size_t);
int comparar_fechas(const Fecha *, const Fecha *);

int main()
{
        Fecha fechas[CANTIDAD_FECHAS] = {
            {25, 12, 2023},
            {1, 1, 2022},
            {15, 8, 2024},
            {30, 6, 2022},
            {1, 1, 2023},
            {5, 5, 2023}};

        printf("Fechas originales:\n");
        imprimir_fechas(fechas, CANTIDAD_FECHAS);

        bubble_sort_fechas(fechas, CANTIDAD_FECHAS);

        printf("\nFechas ordenadas cronológicamente:\n");
        imprimir_fechas(fechas, CANTIDAD_FECHAS);

        return 0;
}

void bubble_sort_fechas(Fecha *array, size_t n)
{
        for (size_t i = 0; i < n - 1; i++)
        {
                for (size_t j = 0; j < n - 1 - i; j++)
                {
                        if (comparar_fechas(&array[j], &array[j + 1]) > 0)
                        {
                                Fecha temp = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = temp;
                        }
                }
        }
}

int comparar_fechas(const Fecha *f1, const Fecha *f2)
{
        if (f1->anio != f2->anio)
        {
                return f1->anio - f2->anio;
        }

        if (f1->mes != f2->mes)
        {
                return f1->mes - f2->mes;
        }

        return f1->dia - f2->dia;
}

void imprimir_fechas(Fecha *array, size_t n)
{
        for (size_t i = 0; i < n; i++)
        {
                printf("%zu. %02d/%02d/%04d\n", i + 1, array[i].dia, array[i].mes, array[i].anio);
        }
}
