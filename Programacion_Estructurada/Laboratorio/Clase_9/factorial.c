// Sacar el factorial de un numero.

#include <stdio.h>

int main()
{
        int n, factorial = 1;

        printf("Ingrese un número, para calcular el factorial: ");
        scanf("%d", &n);

        for (int i = 1; i <= n; i++)
                factorial *= i;

        printf("El factorial de: %d es: %d\n", n, factorial);

        return 0;
}