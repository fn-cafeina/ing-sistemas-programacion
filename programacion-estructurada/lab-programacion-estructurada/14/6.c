#include <stdio.h>
#include <stdlib.h>

#define MAXF 10
#define MAXC 10

int main()
{
        int matriz[MAXF][MAXC], f, c, nfil, ncol;

        printf("Introduzca el número de filas: ");
        scanf("%d", &nfil);
        printf("Introduzca el número de columnas: ");
        scanf("%d", &ncol);

        for (f = 0; f < nfil; f++)
        {
                for (c = 0; c < ncol; c++)
                {
                        if (f == c)
                                matriz[f][c] = 1;
                        else
                                matriz[f][c] = 0;
                }
        }

        printf("\n*** DATOS DE LA MATRIZ INTRODUCIDA ***\n");
        for (f = 0; f < nfil; f++)
        {
                for (c = 0; c < ncol; c++)
                {
                        printf(" %d", matriz[f][c]);
                }
                printf("\n");
        }
}