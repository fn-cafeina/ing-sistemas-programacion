#include <stdio.h>

int main()
{
        int numero, producto = 1, i;

        printf("Ingrese un número natural: ");
        scanf("%d", &numero);

        for (i = 1; i <= numero; i++)
        {
                producto *= i;
        }

        printf("El producto de %d es: %d\n", numero, producto);

        return 0;
}