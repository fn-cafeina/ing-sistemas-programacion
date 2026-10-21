// Ingresar por teclado un entero que represente la cantidad de elementos que debe crearse
// para un arreglo.
// Crear el arreglo en forma dinámica, cargar e imprimir sus datos. Hacer todo en el main.

#include <stdio.h>
#include <stdlib.h>

int main()
{
        int *pe;
        int *pe_invertido;
        int tam;
        int f;

        printf("Cuantos elementos tendra el arreglo: ");
        scanf("%i", &tam);

        pe = (int *)malloc(tam * sizeof(int));
        if (pe == NULL)
        {
                printf("Error: No se pudo asignar memoria.\n");
                return 1;
        }

        for (f = 0; f < tam; f++)
        {
                printf("Ingrese elemento %d: ", f + 1);
                scanf("%i", &pe[f]);
        }

        pe_invertido = (int *)malloc(tam * sizeof(int));
        if (pe_invertido == NULL)
        {
                printf("Error: No se pudo asignar memoria para el arreglo invertido.\n");
                free(pe);
                return 1;
        }

        for (f = 0; f < tam; f++)
        {
                pe_invertido[f] = pe[tam - 1 - f];
        }

        printf("\nContenido del arreglo original:\n");
        for (f = 0; f < tam; f++)
        {
                printf("%i ", pe[f]);
        }
        printf("\n");

        printf("Contenido del arreglo invertido:\n");
        for (f = 0; f < tam; f++)
        {
                printf("%i ", pe_invertido[f]);
        }
        printf("\n");

        free(pe);
        free(pe_invertido);

        return 0;
}

// Actividad 1: Realizar una modificación al programa para que cree otro arreglo de forma
// dinámica con el mismo tamaño, y que almacene en este nuevo puntero todos los datos de
// “*pe” invertidos.