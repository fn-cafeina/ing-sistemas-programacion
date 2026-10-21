// Realice un programa en C que lea en un arreglo las edades de N
// personas y que calcule e imprima la edad moda. La moda es la
// edad que más veces aparece (si dos o más edades aparecen muchas
// veces con la máxima frecuencia, asumiremos que cualquiera de
// ellas es la moda).

#include <stdio.h>

int main()
{
        int n, i, j, maxFreq = 0, moda = 0;

        printf("Ingrese n: ");
        scanf("%d", &n);

        int edades[n], frecuencias[n];

        for (i = 0; i < n; i++)
        {
                printf("Edad %d: ", i + 1);
                scanf("%d", &edades[i]);
                frecuencias[i] = 0;

                if (i == 0)
                        moda = edades[i];
        }

        for (i = 0; i < n; i++)
        {
                for (j = 0; j < n; j++)
                {
                        if (edades[i] == edades[j])
                                frecuencias[i]++;
                }

                if (frecuencias[i] > maxFreq)
                {
                        maxFreq = frecuencias[i];
                        moda = edades[i];
                }
        }

        printf("La moda es: %d\n", moda);

        return 0;
}