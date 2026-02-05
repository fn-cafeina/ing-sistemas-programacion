#include <stdio.h>

int main()
{
        int numero, producto = 1, i = 1;

        printf("Ingrese un número natural: ");
        scanf("%d", &numero);

        while (i <= numero)
        {
                producto *= i;
                i++;
        }

        printf("El producto de %d es: %d\n", numero, producto);

        return 0;
}