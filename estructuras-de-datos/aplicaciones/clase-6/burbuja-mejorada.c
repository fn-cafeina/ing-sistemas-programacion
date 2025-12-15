// Desarrolla un programa en C que lea una lista de n números enteros (donde n lo ingresa el usuario).
// Ordena la lista con el método de burbuja mejorado,
// de tal manera que si en una pasada no se realizan intercambios,
// el algoritmo se detenga antes de completar todas las vueltas.
// Muestra la lista ordenada y la cantidad de pasadas realizadas.

#include <stdio.h>
#include <stdlib.h>

void verificar_puntero(void *);
void bubble_sort_mejorado(int *, size_t, size_t *);
void imprimir_array(const int *, size_t);

int main()
{
        int *numeros = NULL;
        size_t cantidad = 0;
        size_t pasadas = 0;

        printf("Ingrese la cantidad de números a ordenar: ");
        if (scanf("%zu", &cantidad) != 1 || cantidad == 0)
        {
                fprintf(stderr, "Entrada inválida.\n");
                return EXIT_FAILURE;
        }

        numeros = malloc(cantidad * sizeof(int));
        verificar_puntero(numeros);

        printf("Ingrese %zu números:\n", cantidad);
        for (size_t i = 0; i < cantidad; i++)
        {
                printf("#%zu: ", i + 1);
                if (scanf("%d", &numeros[i]) != 1)
                {
                        fprintf(stderr, "Entrada inválida.\n");
                        free(numeros);
                        return EXIT_FAILURE;
                }
        }

        bubble_sort_mejorado(numeros, cantidad, &pasadas);

        printf("\n=== Lista ordenada ===\n");
        imprimir_array(numeros, cantidad);
        printf("Cantidad de pasadas realizadas: %zu\n", pasadas);

        free(numeros);
        return 0;
}

void bubble_sort_mejorado(int *array, size_t n, size_t *pasadas)
{
        int hubo_intercambio;

        for (size_t i = 0; i < n - 1; i++)
        {
                hubo_intercambio = 0;

                for (size_t j = 0; j < n - 1 - i; j++)
                {
                        if (array[j] > array[j + 1])
                        {
                                int temp = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = temp;
                                hubo_intercambio = 1;
                        }
                }

                (*pasadas)++;

                if (!hubo_intercambio)
                {
                        break;
                }
        }
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
