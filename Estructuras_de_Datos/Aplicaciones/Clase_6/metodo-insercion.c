// Un supermercado almacena los precios de 12 productos en un arreglo. Escribe un
// programa que ordene los precios de menor a mayor utilizando el método de inserción. Al
// final, muestra la lista ordenada y calcula el promedio de los precios.

#include <stdio.h>
#include <stdlib.h>

#define CANTIDAD_PRECIOS 12

void verificar_puntero(void *);
void insertion_sort(float *, size_t);
void imprimir_array(const float *, size_t);
float calcular_promedio(const float *, size_t);

int main()
{
        float *precios = NULL;

        precios = malloc(CANTIDAD_PRECIOS * sizeof(float));
        verificar_puntero(precios);

        printf("Ingrese los precios de %d productos:\n", CANTIDAD_PRECIOS);
        for (size_t i = 0; i < CANTIDAD_PRECIOS; i++)
        {
                printf("#%zu: $", i + 1);
                if (scanf("%f", &precios[i]) != 1)
                {
                        fprintf(stderr, "Entrada inválida.\n");
                        free(precios);
                        return EXIT_FAILURE;
                }
        }

        insertion_sort(precios, CANTIDAD_PRECIOS);

        printf("\n=== Precios ordenados de menor a mayor ===\n");
        imprimir_array(precios, CANTIDAD_PRECIOS);

        float promedio = calcular_promedio(precios, CANTIDAD_PRECIOS);
        printf("\nPromedio de precios: $%.2f\n", promedio);

        free(precios);
        return 0;
}

void insertion_sort(float *array, size_t n)
{
        for (size_t i = 1; i < n; i++)
        {
                float clave = array[i];
                size_t j = i;

                while (j > 0 && array[j - 1] > clave)
                {
                        array[j] = array[j - 1];
                        j--;
                }

                array[j] = clave;
        }
}

void imprimir_array(const float *array, size_t n)
{
        for (size_t i = 0; i < n; i++)
        {
                printf("$%.2f ", array[i]);
        }
        printf("\n");
}

float calcular_promedio(const float *array, size_t n)
{
        float suma = 0.0f;

        for (size_t i = 0; i < n; i++)
        {
                suma += array[i];
        }

        return suma / n;
}

void verificar_puntero(void *ptr)
{
        if (!ptr)
        {
                fprintf(stderr, "Error: no se pudo asignar memoria.\n");
                exit(EXIT_FAILURE);
        }
}
