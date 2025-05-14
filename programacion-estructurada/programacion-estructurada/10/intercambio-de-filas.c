// Realice un programa en C que intercambie las M filas de un
// arreglo bidimensional. Los elementos de la primera fila se
// intercambian con los de la última fila, los de la segunda con
// los de la penúltima y así sucesivamente.

#include <stdio.h>
#include <stdlib.h>

void imprimirMatriz(int **, int, int);

int main()
{
        int tamanyioFilas, tamanyioColumnas;

        printf("Ingrese la cantidad de filas: ");
        scanf("%d", &tamanyioFilas);

        printf("Ingrese la cantidad de columnas: ");
        scanf("%d", &tamanyioColumnas);

        int **arreglo;
        arreglo = (int **)malloc((size_t)tamanyioFilas * sizeof(int *));

        for (int i = 0; i < tamanyioFilas; i++)
                arreglo[i] = (int *)malloc((size_t)tamanyioColumnas * sizeof(int));

        printf("\n");

        for (int i = 0; i < tamanyioFilas; i++)
        {
                for (int j = 0; j < tamanyioColumnas; j++)
                {
                        printf("Ingrese el valor de la posición [%d][%d]: ", i, j);
                        scanf("%d", &arreglo[i][j]);
                }
        }

        printf("\nMatriz original\n");
        imprimirMatriz(arreglo, tamanyioFilas, tamanyioColumnas);

        return 0;
}

void imprimirMatriz(int **arreglo, int tamanyioFilas, int tamanyioColumnas)
{
        for (int i = 0; i < tamanyioFilas; i++)
        {
                for (int j = 0; j < tamanyioColumnas; j++)
                        printf("%d  ", arreglo[i][j]);

                printf("\n");
        }
}