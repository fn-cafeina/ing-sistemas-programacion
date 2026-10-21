/*
        Crea un programa que ordene una lista de precios de productos usando el método de
        burbuja mejorado, de manera que el algoritmo se detenga antes de terminar todas las
        pasadas si detecta que el arreglo ya está ordenado.
*/

#include <stdio.h>
#include <stdbool.h>

void bubble_sort_mejorado(float *precios, int n);
void imprimir_precios(float *precios, int n);

int main()
{
        float precios[] = {19.99, 5.49, 12.75, 3.99, 25.00, 8.30};
        int n = sizeof(precios) / sizeof(precios[0]);

        printf("Lista de precios original:\n");
        imprimir_precios(precios, n);

        bubble_sort_mejorado(precios, n);

        printf("Lista de precios ordenada:\n");
        imprimir_precios(precios, n);

        return 0;
}

void bubble_sort_mejorado(float *precios, int n)
{
        bool hubo_intercambios;

        for (int i = 0; i < n - 1; i++)
        {
                hubo_intercambios = false;

                for (int j = 0; j < n - 1 - i; j++)
                {
                        if (precios[j] > precios[j + 1])
                        {
                                float temp = precios[j];
                                precios[j] = precios[j + 1];
                                precios[j + 1] = temp;
                                hubo_intercambios = true;
                        }
                }

                if (!hubo_intercambios)
                {
                        break;
                }
        }
}

void imprimir_precios(float *precios, int n)
{
        for (int i = 0; i < n; i++)
        {
                printf("$%.2f ", precios[i]);
        }
        printf("\n");
}
