#include <stdio.h>

int main()
{
        int vector[10] = {10, 20, 30, 40, 50, 60, 70, 80, 90, 100};

        int *ptr = vector;

        double suma = 0.0;
        int i;

        for (i = 0; i < 10; ++i)
        {
                suma += *(ptr + i);
        }

        double media = suma / 10.0;

        printf("La media aritmetica del vector es: %.2f\n", media);

        return 0;
}