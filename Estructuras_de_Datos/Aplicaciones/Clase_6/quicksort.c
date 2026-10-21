// Realiza un programa en C que permita al usuario ingresar 20 números aleatorios
// generados por el sistema. Luego, ordénalos con el método Quicksort de forma ascendente
// y muestra los resultados en pantalla. Además, el programa debe indicar cuántas llamadas
// recursivas se hicieron.

#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define CANTIDAD_NUMEROS 20
#define LIMITE_ALEATORIO 100

void verificar_puntero(void *);
void imprimir_array(const int *, size_t);
void quicksort(int *, int, int, int *);
int particion(int *, int, int);

int main()
{
        int *numeros = NULL;
        int llamadas = 0;

        srand((unsigned)time(NULL));

        numeros = malloc(CANTIDAD_NUMEROS * sizeof(int));
        verificar_puntero(numeros);

        printf("=== Generando %d números aleatorios ===\n", CANTIDAD_NUMEROS);
        for (size_t i = 0; i < CANTIDAD_NUMEROS; i++)
        {
                numeros[i] = rand() % LIMITE_ALEATORIO;
        }

        printf("\n=== Números generados ===\n");
        imprimir_array(numeros, CANTIDAD_NUMEROS);

        quicksort(numeros, 0, CANTIDAD_NUMEROS - 1, &llamadas);

        printf("\n=== Números ordenados (ascendente) ===\n");
        imprimir_array(numeros, CANTIDAD_NUMEROS);

        printf("\nCantidad de llamadas recursivas: %d\n", llamadas);

        free(numeros);
        return 0;
}

void quicksort(int *array, int inicio, int fin, int *contador)
{
        (*contador)++;

        if (inicio < fin)
        {
                int pivote = particion(array, inicio, fin);

                quicksort(array, inicio, pivote - 1, contador);
                quicksort(array, pivote + 1, fin, contador);
        }
}

int particion(int *array, int inicio, int fin)
{
        int pivote = array[fin];
        int i = inicio - 1;

        for (int j = inicio; j < fin; j++)
        {
                if (array[j] <= pivote)
                {
                        i++;

                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                }
        }

        int temp = array[i + 1];
        array[i + 1] = array[fin];
        array[fin] = temp;

        return i + 1;
}

void imprimir_array(const int *array, size_t n)
{
        for (size_t i = 0; i < n; i++)
        {
                printf("%d ", array[i]);
        }
        printf("\n");
}

void verificar_puntero(void *ptr)
{
        if (!ptr)
        {
                fprintf(stderr, "Error: no se pudo asignar memoria.\n");
                exit(EXIT_FAILURE);
        }
}
