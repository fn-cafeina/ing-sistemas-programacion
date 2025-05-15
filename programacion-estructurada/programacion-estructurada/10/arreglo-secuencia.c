// Realice un programa en C que lea un arreglo de N datos y asigne
// a sus elementos los valores 1, 4, 9, 16........etc ( 12, 22,
// 32...).

#include <stdio.h>

int main()
{
        int N, i;

        printf("Ingrese el tamaño del arreglo (N): ");
        scanf("%d", &N);

        int arr[N];

        for (i = 0; i < N; i++)
        {
                arr[i] = (i + 1) * (i + 1);
        }

        printf("Arreglo generado: ");
        for (i = 0; i < N; i++)
        {
                printf("%d ", arr[i]);
        }

        printf("\n");

        return 0;
}