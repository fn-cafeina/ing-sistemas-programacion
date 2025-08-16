#include <stdio.h>

int main()
{
        int i, suma = 0;

        for (i = 100; i >= 0; i -= 2)
        {
                printf("%d ", i);
                suma += i;
        }

        printf("\nLa suma de dicha sucesion es: %d\n", suma);

        return 0;
}