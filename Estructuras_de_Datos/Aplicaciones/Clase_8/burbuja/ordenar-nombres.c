/*
        Diseña un programa que ordene los nombres de los estudiantes de un curso en orden
        alfabético aplicando el método de burbuja, comparando e intercambiando elementos
        adyacentes hasta lograr el orden correcto.
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

#define MAX_ESTUDIANTES 6

void bubble_sort(char **array, size_t n);
void imprimir_array(char **array, size_t n);

int main()
{
        char *nombres[MAX_ESTUDIANTES] = {
            "Carlos", "Ana", "Luis", "Beatriz", "Jorge", "Diana"};

        printf("=== Nombres antes de ordenar ===\n");
        imprimir_array(nombres, MAX_ESTUDIANTES);

        bubble_sort(nombres, MAX_ESTUDIANTES);

        printf("\n=== Nombres después de ordenar ===\n");
        imprimir_array(nombres, MAX_ESTUDIANTES);

        return 0;
}

void bubble_sort(char **array, size_t n)
{
        bool hubo_intercambios;

        for (size_t i = 0; i < n - 1; i++)
        {
                hubo_intercambios = false;

                for (size_t j = 0; j < n - 1 - i; j++)
                {
                        if (strcmp(array[j], array[j + 1]) > 0)
                        {
                                char *temp = array[j];
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

void imprimir_array(char **array, size_t n)
{
        for (size_t i = 0; i < n; i++)
        {
                printf("- %s\n", array[i]);
        }
}
