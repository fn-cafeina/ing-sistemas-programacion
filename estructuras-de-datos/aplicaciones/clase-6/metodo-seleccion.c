// Crea un programa en C que lea 15 calificaciones de estudiantes y las ordene de mayor a
// menor usando el método de selección. El programa debe mostrar las calificaciones
// ordenadas y señalar cuál fue la mayor y la menor.

#include <stdio.h>
#include <stdlib.h>

#define CANTIDAD_CALIFICACIONES 15

void verificar_puntero(void *);
void selection_sort_desc(float *, size_t);
void imprimir_array(const float *, size_t);

int main()
{
        float *calificaciones = NULL;

        calificaciones = malloc(CANTIDAD_CALIFICACIONES * sizeof(float));
        verificar_puntero(calificaciones);

        printf("Ingrese %d calificaciones:\n", CANTIDAD_CALIFICACIONES);
        for (size_t i = 0; i < CANTIDAD_CALIFICACIONES; i++)
        {
                printf("#%zu: ", i + 1);
                if (scanf("%f", &calificaciones[i]) != 1)
                {
                        fprintf(stderr, "Entrada inválida.\n");
                        free(calificaciones);
                        return EXIT_FAILURE;
                }
        }

        selection_sort_desc(calificaciones, CANTIDAD_CALIFICACIONES);

        printf("\n=== Calificaciones ordenadas de mayor a menor ===\n");
        imprimir_array(calificaciones, CANTIDAD_CALIFICACIONES);

        printf("\nMayor calificación: %.2f\n", calificaciones[0]);
        printf("Menor calificación: %.2f\n", calificaciones[CANTIDAD_CALIFICACIONES - 1]);

        free(calificaciones);
        return 0;
}

void selection_sort_desc(float *array, size_t n)
{
        for (size_t i = 0; i < n - 1; i++)
        {
                size_t max_idx = i;

                for (size_t j = i + 1; j < n; j++)
                {
                        if (array[j] > array[max_idx])
                        {
                                max_idx = j;
                        }
                }

                if (max_idx != i)
                {
                        float temp = array[i];
                        array[i] = array[max_idx];
                        array[max_idx] = temp;
                }
        }
}

void imprimir_array(const float *array, size_t n)
{
        for (size_t i = 0; i < n; i++)
        {
                printf("%.2f ", array[i]);
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
