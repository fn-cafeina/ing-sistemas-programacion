// Que tome dos números y diga si ambos son pares o impares.

#include <stdio.h>
#include <stdlib.h>

int main()
{
        system("clear");

        int n1, n2;

        printf("Ingrese 2 numeros enteros:\n");
        scanf("%d%d", &n1, &n2);

        if (n1 % 2 == 0 && n2 % 2 == 0)
                printf("Ambos numeros son pares.\n");
        else if (n1 % 2 != 0 && n2 % 2 != 0)
                printf("Ambos numeros son impares.\n");
        else
        {
                if (n1 % 2 == 0)
                        printf("Solo %d es par.\n", n1);

                if (n2 % 2 == 0)
                        printf("Solo %d es par.\n", n2);
        }

        return 0;
}