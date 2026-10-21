#include <stdio.h>

int main()
{
        int numero, producto = 1, i = 1;

        printf("Ingrese un número natural: ");
        scanf("%d", &numero);

        do
        {
                producto *= i;
                i++;
        } while (i <= numero);

        printf("El producto de %d es: %d\n", numero, producto);

        return 0;
}