#include <stdio.h>
#include <stdlib.h>

int main()
{
        int matriz[3][3], sumac, f, c, mayor = 0, numc;

        for (f = 0; f < 3; f++)
        {
                for (c = 0; c < 3; c++)
                {
                        printf("Elemento[%d][%d]: ", f + 1, c + 1);
                        scanf("%d", &matriz[f][c]);
                }
        }

        printf("\n*** DATOS DE LA MATRIZ INTRODUCIDA ***\n");
        for (f = 0; f < 3; f++)
        {
                for (c = 0; c < 3; c++)
                {
                        printf("%d ", matriz[f][c]);
                }
                printf("\n");
        }

        for (c = 0; c < 3; c++)
        {
                sumac = 0;
                for (f = 0; f < 3; f++)
                {
                        sumac += matriz[f][c];
                }
                printf("\nSUMA COLUMNA[%d]: %d\n", c + 1, sumac);

                if (sumac > mayor)
                {
                        mayor = sumac;
                        numc = c;
                }
        }

        printf("\nLa columna con mayor suma es: %d y su valor es: %d\n", numc + 1, mayor);
}