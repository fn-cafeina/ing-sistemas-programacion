// Crea un programa en C que:
// 1. Pida al usuario cuántos números (N) desea ingresar.
// 2. Reserve memoria dinámica para almacenar esos N números enteros.
// 3. Permita al usuario ingresar cada número.
// 4. Ordene los números en orden ascendente utilizando el algoritmo de burbuja (bubble
// sort).
// 5. Muestre en pantalla la lista de números antes y después de ordenarlos.
// 6. Libere la memoria utilizada al finalizar.

#include <stdio.h>
#include <stdlib.h>

void imprimirArray(int *, int);
void bubbleSort(int *, int);

int main()
{
        int n = 0;

        printf("¿Cuantos números desea ingresas?\nR = ");
        scanf("%d", &n);

        int *array = (int *)malloc(n * sizeof(int));

        if (array == NULL)
        {
                printf("Error al asignar memoria.\n");
                exit(0);
        }

        for (int i = 0; i < n; i++)
        {
                printf("Ingrese un entero en la posición [%d]: ", i);
                scanf("%d", &array[i]);
        }

        printf("-- Array antes de ordenar --\n");
        imprimirArray(array, n);

        printf("\n");

        bubbleSort(array, n);

        printf("-- Array despues de ordenar --\n");
        imprimirArray(array, n);

        printf("\n");

        free(array);

        return 0;
}

void imprimirArray(int *array, int n)
{
        printf("[");

        for (int i = 0; i < n; i++)
        {
                printf(" %d ", array[i]);
        }

        printf("]\n");
}

void bubbleSort(int *array, int n)
{
        int temp;

        for (int i = 1; i < n; i++)
        {
                for (int j = 0; j < n - 1; j++)
                {
                        if (array[j] < array[j + 1])
                        {
                                temp = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = temp;
                        }
                }
        }
}