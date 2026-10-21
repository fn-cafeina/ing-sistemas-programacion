// Desarrolle un programa que permita ingresar 8 nombres de personas en un arreglo. El programa
// debe ordenar los nombres de acuerdo con la longitud de cada nombre (de más corto a más largo)
// utilizando el método de selección. Finalmente, muestre la lista original y la lista ordenada.

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_NOMBRE 50
#define CANTIDAD_NOMBRES 8

void imprimirNombres(char **, int);
void liberarMemoria(char **, int);
void ordenarSeleccion(char **, int);

int main()
{
        char **nombres = NULL;
        char buffer[MAX_NOMBRE];

        nombres = (char **)malloc(CANTIDAD_NOMBRES * sizeof(char *));
        if (nombres == NULL)
        {
                printf("Error: No se pudo asignar memoria para el arreglo de nombres.\n");
                return 1;
        }

        printf("Ingrese %d nombres de personas:\n", CANTIDAD_NOMBRES);
        for (int i = 0; i < CANTIDAD_NOMBRES; i++)
        {
                printf("Nombre %d: ", i + 1);
                fgets(buffer, MAX_NOMBRE, stdin);
                buffer[strcspn(buffer, "\n")] = 0;

                nombres[i] = (char *)malloc(strlen(buffer) + 1);
                if (nombres[i] == NULL)
                {
                        printf("Error: No se pudo asignar memoria para el nombre %d.\n", i + 1);
                        liberarMemoria(nombres, i);
                        return 1;
                }
                strcpy(nombres[i], buffer);
        }

        printf("\n--- Lista de nombres sin ordenar ---\n");
        imprimirNombres(nombres, CANTIDAD_NOMBRES);

        ordenarSeleccion(nombres, CANTIDAD_NOMBRES);

        printf("\n--- Lista de nombres ordenada por longitud ---\n");
        imprimirNombres(nombres, CANTIDAD_NOMBRES);

        liberarMemoria(nombres, CANTIDAD_NOMBRES);

        return 0;
}

void imprimirNombres(char **nombres, int cantidad)
{
        for (int i = 0; i < cantidad; i++)
        {
                printf("%d. %s\n", i + 1, nombres[i]);
        }
}

void liberarMemoria(char **nombres, int cantidad)
{
        for (int i = 0; i < cantidad; i++)
        {
                free(nombres[i]);
        }
        free(nombres);
}

void ordenarSeleccion(char **nombres, int cantidad)
{
        int i, j, min_idx;
        char *temp;

        for (i = 0; i < cantidad - 1; i++)
        {
                min_idx = i;
                for (j = i + 1; j < cantidad; j++)
                {
                        if (strlen(nombres[j]) < strlen(nombres[min_idx]))
                        {
                                min_idx = j;
                        }
                }

                if (min_idx != i)
                {
                        temp = nombres[i];
                        nombres[i] = nombres[min_idx];
                        nombres[min_idx] = temp;
                }
        }
}