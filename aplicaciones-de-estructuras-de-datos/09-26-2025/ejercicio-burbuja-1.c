// Escribe 4 programas en C utilizando el método burbuja, el ejercicio puede ser de su elección.

#include <stdio.h>
#include <time.h>
#include <stdlib.h>

#define MAX_RANDOM 20
#define ARRAY_LON 10

void bubble_sort(int *, int);
void generar_array(int *, int);
void imprimir_array(int *, int);

int main()
{
        srand(time(NULL));

        int array[ARRAY_LON];

        generar_array(array, ARRAY_LON);

        printf("=== Array antes de ordenar ===\n");
        imprimir_array(array, ARRAY_LON);

        printf("\n=== Array despues de ordenar ===\n");
        bubble_sort(array, ARRAY_LON);
        imprimir_array(array, ARRAY_LON);

        return 0;
}

void bubble_sort(int *array, int n)
{
        for (size_t i = 0; i < n; i++)
        {
                for (size_t j = 0; j < n - 1; j++)
                {
                        if (array[j + 1] < array[j])
                        {
                                int temp = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = temp;
                        }
                }
        }
}

void generar_array(int *array, int n)
{
        for (size_t i = 0; i < n; i++)
        {
                int random_number = rand() % (MAX_RANDOM + 1);
                array[i] = random_number;
        }
}

void imprimir_array(int *array, int n)
{
        printf("[");

        for (size_t i = 0; i < n; i++)
                printf(" %d ", array[i]);

        printf("]\n");
}