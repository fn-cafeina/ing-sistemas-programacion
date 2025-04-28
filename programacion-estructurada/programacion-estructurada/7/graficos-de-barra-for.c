#include <stdio.h>

int main()
{
        int i, j, n, cent = 0;

        for (; cent == 0;)
        {
                printf("\nIngrese un número: ");
                scanf("%d", &n);

                printf("%d). ");

                for (i = 1; i <= n; i++)
                {
                        printf("*");
                }

                printf("\n");

                printf("\n0 - Continuar\n1 - Salir\n");
                scanf("%d", &cent);
        }

        return 0;
}