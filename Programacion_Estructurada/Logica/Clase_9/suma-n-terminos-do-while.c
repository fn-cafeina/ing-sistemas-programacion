#include <stdio.h>

int main()
{
        int termino = 2, suma = 0, i = 1;

        do
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

                i++;
        } while (i <= 10);

        printf("\nLa suma de los primeros 10 terminos es: %d\n", suma);

        return 0;
}