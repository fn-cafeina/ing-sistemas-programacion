// Realice un programa en C que declare y lea un arreglo de N
// elementos, imprimir la suma de los números pares y el producto
// de los números impares del arreglo.

#include <stdio.h>

int main()
{
        int N, i, suma = 0, producto = 1;

        printf("Ingrese N: ");
        scanf("%d", &N);

        int arr[N];

        for (i = 0; i < N; i++)
        {
                printf("Ingrese arr[%d]: ", i);
                scanf("%d", &arr[i]);
        }

        for (i = 0; i < N; i++)
        {
                (arr[i] % 2 == 0) ? (suma += arr[i]) : (producto *= arr[i]);
        }

        printf("Suma pares: %d\nProducto impares: %d\n", suma, producto);

        return 0;
}