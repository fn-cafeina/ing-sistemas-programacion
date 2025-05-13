// Realice un programa en C que lea en un arreglo las edades de N
// personas y que calcule e imprima la edad moda. La moda es la
// edad que más veces aparece (si dos o más edades aparecen muchas
// veces con la máxima frecuencia, asumiremos que cualquiera de
// ellas es la moda).

#include <stdio.h>
#include <stdlib.h>

int main()
{
        int tamanyioArreglo;

        printf("Ingrese la cantidad de personas: ");
        scanf("%d", &tamanyioArreglo);

        int *edades = (int *)malloc((size_t)tamanyioArreglo * sizeof(int));

        if (edades == NULL)
        {
                printf("Error al reservar la memoria.\n");
                return 1;
        }

        printf("\n");

        for (int i = 1; i <= tamanyioArreglo; i++)
        {
                printf("Ingrese la edad de la persona #%d: ", i);
                scanf("%d", &edades[i - 1]);
        }

        int *edadesFrecuencia = (int *)malloc((size_t)tamanyioArreglo * sizeof(int));
        if (edadesFrecuencia == NULL)
        {
                printf("Error al reservar la memoria.\n");
                return 1;
        }

        for (int i = 0; i < tamanyioArreglo; i++)
        {
                int contador = 0;
                for (int j = 0; j < tamanyioArreglo; j++)
                {
                        if (edades[i] == edades[j])
                                contador++;
                }

                edadesFrecuencia[i] = contador;
        }

        int mayor = edadesFrecuencia[0], posMayor = 0;

        for (int i = 0; i < tamanyioArreglo; i++)
        {
                if (edadesFrecuencia[i] > mayor)
                {
                        mayor = edadesFrecuencia[i];
                        posMayor = i;
                }
        }

        printf("\nLa edad de moda es: %d\n", edades[posMayor]);

        return 0;
}