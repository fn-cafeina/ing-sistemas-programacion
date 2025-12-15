// Ejemplo que imprime los numeros pares e impares con for, while y do while.

#include <stdio.h>
#include <stdlib.h>

int main()
{

        if (system("cls"))
                system("clear");

        int n, i = 0;

        printf("Ingrese un número: ");
        scanf("%d", &n);

        if (n == 0)
        {
                printf("Valor no valido.\n");
                exit(0);
        }

        printf("Pares:\n");

        do
        {
                printf(" %d ", i);

                i += 2;
        } while (i <= n);

        i = 1;

        printf("\n\nImpares:\n");

        do
        {
                printf(" %d ", i);

                i += 2;
        } while (i <= n);

        printf("\n");

        return 0;
}