// Programa en C que lee dos números enteros e imprime el mayor de los dos
// números leídos.

#include <stdio.h>

int main()
{
        int n1, n2;

        printf("Numero 1: ");
        scanf("%d", &n1);

        printf("Numero 2: ");
        scanf("%d", &n2);

        if (n1 == n2)
                printf("%d y %d son iguales.\n", n1, n2);
        else
        {
                if (n1 > n2)
                        printf("Entre %d y %d el Mayor es: %d\n", n1, n2, n1);
                else
                {
                        printf("Entre %d y %d el Mayor es: %d\n", n1, n2, n2);
                }
        }

        return 0;
}