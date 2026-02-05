/*
        Un profesor de programación necesita ordenar las calificaciones de sus estudiantes
        de menor a mayor para analizarlas más fácilmente. Para ello,
        te pide que implementes un programa en el lenguaje de tu preferencia que,
        utilizando el método de burbuja, ordene un arreglo de números enteros (las calificaciones)
        y muestre el arreglo antes y después de ser ordenado.
*/

#include <stdio.h>
#include <stdlib.h>

void bubble_sort(int *, int);
void imprimir_array(const int *, int);

int main()
{
        int cantidad_calificaciones = 0;

        printf("Ingrese la cantidad de calificaciones: ");
        scanf("%d", &cantidad_calificaciones);

        int *calificaciones = malloc(cantidad_calificaciones * sizeof(int));
        if (!calificaciones)
        {
                fprintf(stderr, "Error: No se pudo asignar memoria.");
                exit(EXIT_FAILURE);
        }

        for (size_t i = 0; i < cantidad_calificaciones; i++)
        {
                printf("Ingrese la calificaciones #%zu: ", i + 1);
                scanf("%d", &calificaciones[i]);
        }

        printf("\n=== Array antes de ordenar ===\n");
        imprimir_array(calificaciones, cantidad_calificaciones);

        printf("\n=== Array despues de ordenar ===\n");
        bubble_sort(calificaciones, cantidad_calificaciones);
        imprimir_array(calificaciones, cantidad_calificaciones);

        printf("\n");

        free(calificaciones);

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

void imprimir_array(const int *array, int n)
{
        printf("[");

        for (size_t i = 0; i < n; i++)
        {
                printf(" %d ", array[i]);
        }

        printf("]");
}