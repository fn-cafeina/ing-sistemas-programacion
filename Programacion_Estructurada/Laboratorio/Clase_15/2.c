#include <stdio.h>
#define MAXF 10 //
#define MAXC 10 //

int main()
{
        float a[MAXF][MAXC];
        float sumafil;
        int fil, col, f, c;

        do
        {
                printf("NUMERO DE FILAS: ");
                scanf("%d", &fil);
        } while (fil < 1 || fil > MAXF);

        do
        {
                printf("NUMERO DE COLUMNAS: ");
                scanf("%d", &col);
        } while (col < 1 || col > MAXC);

        printf("\n\nIntroduzca los datos de la matriz\n");

        for (f = 0; f < fil; f++)
        {
                for (c = 0; c < col; c++)
                {
                        printf("M[%d][%d]: ", f, c);
                        scanf("%f", &a[f][c]);
                }
        }

        for (f = 0; f < fil; f++)
        {
                sumafil = 0;
                for (c = 0; c < col; c++)
                {
                        sumafil += a[f][c];
                }
                printf("\nLa suma de la fila [%d] es %.2f", f, sumafil);
        }
}