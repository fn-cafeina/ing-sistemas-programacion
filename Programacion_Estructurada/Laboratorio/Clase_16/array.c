#include <stdio.h>
#include <stdlib.h>

int main()
{
        int tamanyioArray = 5;
        float arr[tamanyioArray];

        for (int i = 0; i < tamanyioArray; i++)
        {
                printf("Ingrese un número en la posición [%d]: ", i);
                scanf("%f", &arr[i]);
        }

        for (int i = 0; i < tamanyioArray; i++)
        {
                printf("El número en la posición [%d] es %.2f\n", i, arr[i]);
        }

        return 0;
}