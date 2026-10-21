// El siguiente programa debe pedir las temperaturas en diferentes días, el programa debe
// pedir la cantidad de días y la cantidad de horas que se registrara las temperaturas, se debe
// asignar memoria tanto para los días como para las temperaturas, completar el siguiente
// programa para que pida todas las temperaturas y luego muestre el promedio de temperatura
// por día.

#include <stdio.h>
#include <stdlib.h>

int main()
{
        float **temperaturas = NULL;
        int tamano_filas, tamano_columnas;

        printf("Ingrese la cantidad de dias en que se registraran temperaturas: ");
        scanf("%d", &tamano_filas);

        printf("Ingrese cada cuantas horas se registraran temperaturas al dia: ");
        scanf("%d", &tamano_columnas);

        tamano_columnas = 24 / tamano_columnas;

        temperaturas = (float **)malloc(tamano_filas * sizeof(float *));
        if (temperaturas == NULL)
        {
                printf("Error: No se pudo asignar memoria para las filas.\n");
                return 1;
        }

        for (int i = 0; i < tamano_filas; i++)
        {
                temperaturas[i] = (float *)malloc(tamano_columnas * sizeof(float));
                if (temperaturas[i] == NULL)
                {
                        printf("Error: No se pudo asignar memoria para la fila %d.\n", i);
                        for (int j = 0; j < i; j++)
                        {
                                free(temperaturas[j]);
                        }
                        free(temperaturas);
                        return 1;
                }
        }

        for (int i = 0; i < tamano_filas; i++)
        {
                printf("\n--- Dia %d ---\n", i + 1);
                for (int j = 0; j < tamano_columnas; j++)
                {
                        printf("Ingrese la temperatura de la medicion %d: ", j + 1);
                        scanf("%f", &temperaturas[i][j]);
                }
        }

        printf("\n--- Promedio de temperatura por dia ---\n");
        for (int i = 0; i < tamano_filas; i++)
        {
                float suma_dia = 0.0;
                for (int j = 0; j < tamano_columnas; j++)
                {
                        suma_dia += temperaturas[i][j];
                }
                float promedio_dia = suma_dia / tamano_columnas;
                printf("Dia %d: %.2f\n", i + 1, promedio_dia);
        }

        for (int i = 0; i < tamano_filas; i++)
        {
                free(temperaturas[i]);
        }

        free(temperaturas);

        return 0;
}