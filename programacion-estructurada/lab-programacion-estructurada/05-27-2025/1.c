#include <stdio.h>

int main()
{
        int a[3][5];
        int i, j;

        printf("Introduzca 15 numeros enteros (5 x fila)\n");

        for (i = 0; i < 3; i++)
        {
                printf("\nFila[%d]: ", i);
                for (j = 0; j < 5; j++)
                {
                        scanf("%d", &a[i][j]);
                }
        }

        printf("\n***Visualizacion del Array***\n");
        for (i = 0; i < 3; i++)
        {
                printf("\nnFila [%d]: ", i);
                for (j = 0; j < 5; j++)
                {
                        printf("%d ", a[i][j]);
                }
                printf("\n");
        }
}