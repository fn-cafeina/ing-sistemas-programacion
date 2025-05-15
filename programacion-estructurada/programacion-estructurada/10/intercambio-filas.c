// Realice un programa en C que intercambie las M filas de un
// arreglo bidimensional. Los elementos de la primera fila se
// intercambian con los de la última fila, los de la segunda con
// los de la penúltima y así sucesivamente.

#include <stdio.h>

#define MAX_FILAS 100
#define MAX_COLS 100

int main()
{
        int matriz[MAX_FILAS][MAX_COLS];
        int filas, cols, i, j, temp;

        printf("Numero de filas: ");
        scanf("%d", &filas);

        printf("Numero de columnas: ");
        scanf("%d", &cols);

        printf("\nIngrese los elementos:\n");
        for (i = 0; i < filas; i++)
        {
                for (j = 0; j < cols; j++)
                {
                        printf("[%d][%d]: ", i, j);
                        scanf("%d", &matriz[i][j]);
                }
        }

        printf("\nMatriz original:\n");
        for (i = 0; i < filas; i++)
        {
                for (j = 0; j < cols; j++)
                {
                        printf("[%d][%d]=%d\t", i, j, matriz[i][j]);
                }
                printf("\n");
        }

        for (i = 0; i < filas / 2; i++)
        {
                for (j = 0; j < cols; j++)
                {
                        temp = matriz[i][j];
                        matriz[i][j] = matriz[filas - 1 - i][j];
                        matriz[filas - 1 - i][j] = temp;
                }
        }

        printf("\nMatriz invertida:\n");
        for (i = 0; i < filas; i++)
        {
                for (j = 0; j < cols; j++)
                {
                        printf("[%d][%d]=%d\t", i, j, matriz[i][j]);
                }
                printf("\n");
        }

        return 0;
}