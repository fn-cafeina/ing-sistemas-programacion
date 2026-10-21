#include <stdio.h>
#include <stdlib.h>

int main()
{
        int matriz[2][3], suma = 0, f, c;

        for (f = 0; f < 2; f++)
        {
                for (c = 0; c < 3; c++)
                {
                        printf("Elemento [%d][%d]: ", f, c);
                        scanf("%d", &matriz[f][c]);
                        suma = suma + matriz[f][c];
                }
        }
        printf("\nLa suma de la matriz es: %d\n", suma);
}