// Escribe 4 programas en C utilizando el método burbuja, el ejercicio puede ser de su elección.

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define CANTIDAD_NOMBRES 10
#define MAX_NOMBRE 25

void bubble_sort(char **, size_t);
void verificar_puntero(void *);
void imprimir_array(char **, size_t);

int main()
{
        char **nombres = NULL;
        char buffer[MAX_NOMBRE];

        nombres = malloc(CANTIDAD_NOMBRES * sizeof(char *));

        verificar_puntero(nombres);

        printf("=== Ingrese 10 nombres ===\n");
        for (size_t i = 0; i < CANTIDAD_NOMBRES; i++)
        {
                printf("Nombre #%zu: ", i + 1);
                fgets(buffer, MAX_NOMBRE, stdin);

                buffer[strcspn(buffer, "\n")] = 0;
                if (buffer[0] == '\0')
                {
                        printf("Entrada vacía, intente de nuevo.\n");
                        i--;
                        continue;
                }

                nombres[i] = malloc(strlen(buffer) + 1);
                verificar_puntero(nombres[i]);
                strcpy(nombres[i], buffer);
        }

        printf("\n=== Nombres antes de ordenar alfabaticamente ===\n");
        imprimir_array(nombres, CANTIDAD_NOMBRES);
        printf("\n=== Nombres despues de ordenar alfabaticamente ===\n");
        bubble_sort(nombres, CANTIDAD_NOMBRES);
        imprimir_array(nombres, CANTIDAD_NOMBRES);

        for (size_t i = 0; i < CANTIDAD_NOMBRES; i++)
        {
                free(nombres[i]);
        }

        free(nombres);

        return 0;
}

void bubble_sort(char **array, size_t n)
{
        for (size_t i = 0; i < n - 1; i++)
        {
                for (size_t j = 0; j < n - 1 - i; j++)
                {
                        if (strcmp(array[j], array[j + 1]) > 0)
                        {
                                char *temp = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = temp;
                        }
                }
        }
}

void verificar_puntero(void *ptr)
{
        if (!ptr)
        {
                fprintf(stderr, "Error: puntero nulo. No se pudo asignar memoria.\n");
                exit(EXIT_FAILURE);
        }
}

void imprimir_array(char **array, size_t n)
{
        for (size_t i = 0; i < n; i++)
        {
                printf("- %zu %s\n", i + 1, array[i]);
        }
}