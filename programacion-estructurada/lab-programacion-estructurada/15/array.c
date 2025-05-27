#include <stdio.h>
#include <stdlib.h>

int main()
{
        float numeros[100];
        int i;

        srand(1);

        for (i = 0; i < 100; i++)
        {
                numeros[i] = ((float)rand() / (float)RAND_MAX) * 100.0;
        }

        printf("\nImprimiendo los valores almacenados en orden:\n");

        for (i = 0; i < 100; i++)
        {
                printf("Numero [%d]: %.2f\n", i, numeros[i]);
        }

        return 0;
}