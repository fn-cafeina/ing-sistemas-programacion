// Ejemplo que imprime los numeros pares e impares con for, while y do while.

#include <stdio.h>
#include <stdlib.h>

int main()
{

        if (system("cls"))
                system("clear");

        int n;

        printf("Ingrese un número: ");
        scanf("%d", &n);

        if (n == 0)
        {
                printf("Valor no valido.\n");
                exit(0);
        }

        printf("Pares:\n");

        for (int i = 0; i <= n; i += 2)
                printf(" %d ", i);

        printf("\n\nImpares:\n");

        for (int i = 1; i <= n; i += 2)
                printf(" %d ", i);

        printf("\n");

        return 0;
}