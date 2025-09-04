#include <stdio.h>
#include <stdlib.h>

void imprimirArray(int *, int);
void bubbleSort(int *, int);

int main()
{
        int n = 0;

        printf("Ingrese la cantidad de estudiantes: ");
        scanf("%d", &n);

        int *array = (int *)malloc(n * sizeof(int));

        if (array == NULL)
        {
                printf("Error al asignar memoria.\n");
                exit(0);
        }

        for (int i = 0; i < n; i++)
        {
                printf("Ingrese la calificación del estudiante #%d: ", i);
                scanf("%d", &array[i]);
        }

        printf("-- Array antes de ordenar --\n");
        imprimirArray(array, n);

        printf("\n");

        bubbleSort(array, n);

        printf("-- Array despues de ordenar --\n");
        imprimirArray(array, n);

        printf("\n");

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
                        if (array[j] > array[j + 1])
                        {
                                temp = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = temp;
                        }
                }
        }
}