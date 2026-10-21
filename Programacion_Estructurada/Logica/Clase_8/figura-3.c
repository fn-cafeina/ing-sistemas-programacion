#include <stdio.h>

int main()
{
        int n, i, j, espacio;

        printf("Ingrese un número: ");
        scanf("%d", &n);

        i = 1;
        while (i <= n)
        {
                espacio = n - i;
                while (espacio > 0)
                {
                        printf("  ");
                        espacio--;
                }

                j = 1;
                while (j <= 2 * i - 1)
                {
                        printf("* ");
                        j++;
                }

                printf("\n");
                i++;
        }

        i = n - 1;
        while (i >= 1)
        {
                espacio = n - i;
                while (espacio > 0)
                {
                        printf("  ");
                        espacio--;
                }

                j = 1;
                while (j <= 2 * i - 1)
                {
                        printf("* ");
                        j++;
                }

                printf("\n");
                i--;
        }

        return 0;
}
