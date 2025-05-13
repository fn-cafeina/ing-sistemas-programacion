// Realice un programa en C que lea un arreglo de N datos y asigne
// a sus elementos los valores 1, 4, 9, 16........etc ( 1², 2²,
// 3²...).

#include <stdio.h>
#include <stdlib.h>

int main()
{
        int tamanyioArreglo;

        printf("Ingrese el tamaño del arreglo: ");
        scanf("%d", &tamanyioArreglo);

        int *arr = (int *)malloc((size_t)tamanyioArreglo * sizeof(int));

        if (arr == NULL)
        {
                printf("Error al reservar la memoria.\n");
                return 1;
        }

        for (int i = 1; i <= tamanyioArreglo; i++)
        {
                arr[i] = i * i;
        }

        for (int i = 1; i <= tamanyioArreglo; i++)
        {
                printf("arr[%d] = %d\n", i, arr[i]);
        }

        return 0;
}