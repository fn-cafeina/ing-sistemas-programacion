/*
        Implementa un algoritmo que organice las edades de un grupo de personas utilizando el
        método de inserción, colocando cada nueva edad en su posición correspondiente dentro de
        la lista ya ordenada.
*/

#include <stdio.h>
#include <stdlib.h>

void insertion_sort(int *, int);
void imprimir_array(const int *, int);

int main()
{
        int cantidad_personas = 0;

        printf("Ingrese la cantidad de personas: ");
        scanf("%d", &cantidad_personas);

        int *edades = malloc(cantidad_personas * sizeof(int));
        if (!edades)
        {
                fprintf(stderr, "Error: No se pudo asignar memoria.");
                exit(EXIT_FAILURE);
        }

        for (size_t i = 0; i < cantidad_personas; i++)
        {
                printf("Ingrese la edad de la persona #%zu: ", i + 1);
                scanf("%d", &edades[i]);
        }

        printf("\n=== Edades antes de ordenar ===\n");
        imprimir_array(edades, cantidad_personas);

        printf("\n=== Edades despues de ordenar ===\n");
        insertion_sort(edades, cantidad_personas);
        imprimir_array(edades, cantidad_personas);

        printf("\n");

        free(edades);

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
        for (size_t i = 0; i < n; i++)
        {
                printf("- Edad #%zu: %d\n", i + 1, array[i]);
        }
}