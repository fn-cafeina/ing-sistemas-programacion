#include <stdio.h>

int main()
{
        int termino = 2, suma = 0, i;

        for (i = 1; i <= 625; i++)
        {
                if (i % 2 == 0)
                {
                        printf("%d\n", termino);
                        termino += 3;
                        suma += termino;
                }
                else
                {
                        printf("%d\n", termino);
                        termino += 5;
                        suma += termino;
                }
        }

        printf("\nLa suma de los primeros 10 terminos es: %d\n", suma);

        return 0;
}