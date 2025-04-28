#include <stdio.h>

int main()
{
        int i, n, impares;

        printf("Ingrese un número: ");
        scanf("%d", &n);

        for (i = 1; i <= n; i += 2)
        {
                impares++;
        }

        printf("La cantidad de impares hasta %d es: %d\n", n, impares);

        return 0;
}