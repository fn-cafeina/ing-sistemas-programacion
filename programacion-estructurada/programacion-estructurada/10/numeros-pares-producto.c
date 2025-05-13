// Realice un programa en C que declare y lea un arreglo de N
// elementos, imprimir la suma de los números pares y el producto
// de los números impares del arreglo.

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

        printf("\n");

        for (int i = 0; i < tamanyioArreglo; i++)
        {
                printf("Ingrese un número en la posición %d: ", i);
                scanf("%d", &arr[i]);
        }

        int sumaPares = 0, productoImpares = 1;

        for (int i = 0; i < tamanyioArreglo; i++)
        {
                if (arr[i] % 2 == 0)
                        sumaPares += arr[i];
                else
                        productoImpares *= arr[i];
        }

        printf("\nLa suma de los números pares es: %d\n", sumaPares);
        printf("El producto de los números impares es: %d\n", productoImpares != 1 ? productoImpares : 0);

        free(arr);

        return 0;
}