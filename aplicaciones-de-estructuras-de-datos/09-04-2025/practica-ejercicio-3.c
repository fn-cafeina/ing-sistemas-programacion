// Cree un programa que almacene en un arreglo dinámico una lista de 10 nombres de estudiantes
// ingresados por teclado. Posteriormente, ordene los nombres en orden alfabético ascendente
// utilizando el método de burbuja y muestre en pantalla la lista antes y después de la ordenación.

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_NOMBRE 50
#define CANTIDAD_NOMBRES 10

void imprimirNombres(char **, int);
void liberarMemoria(char **, int);
void ordenarBurbuja(char **, int);

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

        printf("Ingrese 10 nombres de estudiantes:\n");
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

        ordenarBurbuja(nombres, CANTIDAD_NOMBRES);

        printf("\n--- Lista de nombres ordenada alfabéticamente ---\n");
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

void ordenarBurbuja(char **nombres, int cantidad)
{
        for (int i = 0; i < cantidad - 1; i++)
        {
                for (int j = 0; j < cantidad - 1 - i; j++)
                {
                        if (strcmp(nombres[j], nombres[j + 1]) > 0)
                        {
                                char *temp = nombres[j];
                                nombres[j] = nombres[j + 1];
                                nombres[j + 1] = temp;
                        }
                }
        }
}