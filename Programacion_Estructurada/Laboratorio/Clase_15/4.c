#include <stdio.h>
#include <stdlib.h>

int main()
{
        int matriz[3][2], mayor, f, c, posif, posic;

        for (f = 0; f < 3; f++)
        {
                for (c = 0; c < 2; c++)
                {
                        printf("Elemento[%d][%d]: ", f, c);
                        scanf("%d", &matriz[f][c]);
                }
        }

        mayor = matriz[0][0];
        posif = 0;
        posic = 0;

        for (f = 0; f < 3; f++)
        {
                for (c = 0; c < 2; c++)
                {
                        if (matriz[f][c] > mayor)
                        {
                                mayor = matriz[f][c];
                                posif = f;
                                posic = c;
                        }
                }
        }

        printf("\n%d ES EL ELEMENTO MAYOR Y SE ENCUENTRA EN LA POSICIÓN [%d,%d]\n", mayor, posif, posic);
}