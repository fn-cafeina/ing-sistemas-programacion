// Desarrolle un programa en C que lea un arreglo de 20 números enteros generados aleatoriamente
// entre 1 y 100. El programa debe ordenar el arreglo de forma ascendente utilizando el método de
// burbuja mejorada (Bubble Sort optimizado), el cual debe detenerse cuando en una pasada completa
// no se realice ningún intercambio. Finalmente, muestre en pantalla el arreglo antes y después de
// aplicar el algoritmo de ordenamiento.

#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define TAMANO_ARRAY 20

void imprimirArray(int *, int);
void bubbleSortMejorado(int *, int);

int main()
{
        int numeros[TAMANO_ARRAY];

        srand(time(NULL));

        for (int i = 0; i < TAMANO_ARRAY; i++)
        {
                numeros[i] = rand() % 100 + 1;
        }

        printf("--- Array antes de ordenar ---\n");
        imprimirArray(numeros, TAMANO_ARRAY);

        bubbleSortMejorado(numeros, TAMANO_ARRAY);

        printf("\n--- Array ordenado ---\n");
        imprimirArray(numeros, TAMANO_ARRAY);

        return 0;
}

void imprimirArray(int *array, int tamano)
{
        for (int i = 0; i < tamano; i++)
        {
                printf("%d ", array[i]);
        }

        printf("\n");
}

void bubbleSortMejorado(int *array, int tamano)
{
        int i, j, temp;
        int intercambios;

        for (i = 0; i < tamano - 1; i++)
        {
                intercambios = 0;
                for (j = 0; j < tamano - 1 - i; j++)
                {
                        if (array[j] > array[j + 1])
                        {
                                temp = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = temp;
                                intercambios = 1;
                        }
                }

                if (intercambios == 0)
                {
                        break;
                }
        }
}