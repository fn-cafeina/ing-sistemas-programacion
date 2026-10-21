/*
        Crear un algoritmo que ordene un conjunto de datos mediante el método de burbuja
        mejorado, de forma que el proceso de ordenamiento se detenga automáticamente si en una
        pasada completa no se realizan intercambios.
*/

#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

void bubble_sort_mejorado(int *array, int n);
void imprimir_array(int *array, int n);

int main()
{
        int datos[] = {5, 3, 8, 4, 2, 7, 1, 6};
        int n = sizeof(datos) / sizeof(datos[0]);

        printf("Arreglo original:\n");
        imprimir_array(datos, n);

        bubble_sort_mejorado(datos, n);

        printf("Arreglo ordenado:\n");
        imprimir_array(datos, n);

        return 0;
}

void bubble_sort_mejorado(int *array, int n)
{
        bool hubo_intercambios;

        for (size_t i = 0; i < n - 1; i++)
        {
                hubo_intercambios = false;

                for (size_t j = 0; j < n - 1 - i; j++)
                {
                        if (array[j] > array[j + 1])
                        {
                                int temp = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = temp;
                                hubo_intercambios = true;
                        }
                }

                if (!hubo_intercambios)
                {
                        break;
                }
        }
}

void imprimir_array(int *array, int n)
{
        for (int i = 0; i < n; i++)
        {
                printf("%d ", array[i]);
        }
        printf("\n");
}
