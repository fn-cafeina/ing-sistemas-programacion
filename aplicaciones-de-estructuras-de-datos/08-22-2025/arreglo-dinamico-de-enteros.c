#include <stdio.h>
#include <stdlib.h>

int main()
{
        int n = 0;

        printf("\n¿Cuando números quiere almacenar?\nR = ");
        scanf("%d", &n);

        int *numerosMalloc = (int *)malloc(n * sizeof(int));

        if (numerosMalloc == NULL)
        {
                perror("Error: No se pudo asignar memoria\n");
                return 1;
        }

        for (size_t i = 0; i < n; i++)
        {
                printf("Ingrese un número en la posición #%d del arreglo: ", i);
                scanf("%d", &numerosMalloc[i]);
        }

        printf("\n");

        for (size_t i = 0; i < n; i++)
                printf("numeros[%d] = %d\n", i, numerosMalloc[i]);

        free(numerosMalloc);

        printf("\n¿Cuando números quiere almacenar?\nR = ");
        scanf("%d", &n);

        int *numerosCalloc = calloc(n, sizeof(int));

        if (numerosCalloc == NULL)
        {
                perror("Error: No se pudo asignar memoria\n");
                return 1;
        }

        for (size_t i = 0; i < n; i++)
        {
                printf("Ingrese un número en la posición #%d del arreglo: ", i);
                scanf("%d", &numerosCalloc[i]);
        }

        printf("\n");

        for (size_t i = 0; i < n; i++)
                printf("numeros[%d] = %d\n", i, numerosCalloc[i]);

        free(numerosCalloc);

        return 0;
}

// Diferencia que note entre malloc y calloc:
// - El uso de calloc en mi opinion es mucho mas sencillo debido a su sintaxis compacta.
// - Calloc inicializa cada espacio del array en 0, a diferencia de malloc, el cual los iniciliza con números basura.