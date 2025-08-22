#include <stdio.h>

int main()
{
        int *punt, i;

        int x[5] = {1, 2, 3, 4, 5};

        punt = x;

        *punt = 9;

        printf("El array 'x' despues de la modificacion es: {%d, %d, %d, %d, %d}\n\n",
               x[0], x[1], x[2], x[3], x[4]);

        printf("Salida del bucle for:\n");
        for (i = 0; i < 5; i++)
        {
                printf("%d,", x[i]);
        }
        printf("\n");

        return 0;
}

// Este código imprime: 9,2,3,4,5,