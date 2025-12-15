/*
        Desarrollar un programa que ordene una lista de calificaciones usando el método de
        inserción, insertando cada elemento en la posición adecuada dentro de la parte ya ordenada
        del arreglo.
*/

#include <stdio.h>
#include <stdlib.h>

void insertion_sort(int *, int);
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
        insertion_sort(calificaciones, cantidad_calificaciones);
        imprimir_array(calificaciones, cantidad_calificaciones);

        printf("\n");

        free(calificaciones);

        return 0;
}

void insertion_sort(int *array, int n)
{
        for (size_t i = 1; i < n; i++)
        {
                int clave = array[i];
                int j = i;

                while (j > 0 && array[j - 1] > clave)
                {
                        array[j] = array[j - 1];
                        j--;
                }

                array[j] = clave;
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