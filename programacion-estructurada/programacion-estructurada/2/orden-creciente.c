// Realice un programa en C que, al recibir como datos de entrada tres valores enteros
// diferentes entre sí, determine si los mismos están en orden creciente.

#include <stdio.h>

int main()
{
        int val1, val2, val3;

        printf("Ingrese 3 valores enteros: \n");
        scanf("%d %d %d", &val1, &val2, &val3);

        if (val2 > val1 & val3 > val2)
                printf("Los valores estan en orden creciente.\n");
        else
                printf("Los valores no estan en orden creciente.\n");

        return 0;
}