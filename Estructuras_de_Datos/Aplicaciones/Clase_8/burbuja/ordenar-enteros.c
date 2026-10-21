/*
        Implementar un algoritmo que ordene un arreglo de números enteros de menor a mayor
        utilizando el método de burbuja, intercambiando pares de elementos adyacentes cuando se
        encuentran en el orden incorrecto.
*/

#include <stdio.h>
#include <stdlib.h>

void bubble_sort(int *, int);
void imprimir_array(int[], int);

int main()
{
        int enteros[] = {3, 5, 2, 8, 7, 1, 4, 0};
        int tamano_array = sizeof(enteros) / sizeof(enteros[0]);

        printf("=== Array antes de ordenar ===\n");
        imprimir_array(enteros, tamano_array);

        printf("\n=== Array despues de ordenar ===\n");
        bubble_sort(enteros, tamano_array);
        imprimir_array(enteros, tamano_array);

        return 0;
}

void bubble_sort(int *array, int n)
{
        for (size_t i = 0; i < n - 1; i++)
        {
                for (size_t j = 0; j < n - 1 - i; j++)
                {
                        if (array[j] > array[j + 1])
                        {
                                int temp = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = temp;
                        }
                }
        }
}

void imprimir_array(int array[], int n)
{
        printf("[");

        for (size_t i = 0; i < n; i++)
        {
                printf(" %d ", array[i]);
        }

        printf("]\n");
}