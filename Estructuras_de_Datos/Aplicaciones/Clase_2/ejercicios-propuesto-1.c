// Realice un programa que almacene 10 números enteros en un arreglo dinámico y luego muestre
// por pantalla el menor y mayor de la lista de números leídos.

#include <stdio.h>
#include <stdlib.h>

int main(void)
{
        int *a = (int *)malloc(10 * sizeof(int));
        if (!a)
        {
                fprintf(stderr, "Error: no se pudo asignar memoria.\n");
                return 1;
        }

        printf("Ingrese 10 numeros enteros:\n");
        for (int i = 0; i < 10; i++)
        {
                printf("a[%d] = ", i);
                if (scanf("%d", &a[i]) != 1)
                {
                        fprintf(stderr, "Entrada invalida.\n");
                        free(a);
                        return 1;
                }
        }

        int min = a[0], max = a[0];
        for (int i = 1; i < 10; i++)
        {
                if (a[i] < min)
                        min = a[i];
                if (a[i] > max)
                        max = a[i];
        }

        printf("\nMenor = %d\nMayor = %d\n", min, max);

        free(a);
        return 0;
}
