// Se tiene la siguiente información por cada uno de los N estudiantes de la universidad:
// Edad
// Sexo(1: masculino; 2: femenino)
// Carrera (1: Ingeniería; 2: otra carrera)
// Hacer un algoritmo que obtenga:
// • Promedio de edad de los estudiantes de Ingeniería.
// • Porcentaje de hombres en la universidad.
// • Porcentaje de mujeres que estudian Ingeniería.

#include <stdio.h>

int main()
{
        int n, edad, sexo, carrera, i = 1;
        int totalHombres = 0, totalMujeres = 0, totalIngenieria = 0;
        int totalHombresIngenieria = 0, totalMujeresIngenieria = 0;
        int totalEdadIngenieria = 0;

        printf("Ingrese la cantidad de estudiantes: ");
        scanf("%d", &n);

        do
        {
                printf("\nEstudiante #%d\n", i);

                printf("Edad: ");
                scanf("%d", &edad);

                printf("Sexo (1: masculino; 2: femenino): ");
                scanf("%d", &sexo);

                printf("Carrera (1: Ingeniería; 2: otra carrera): ");
                scanf("%d", &carrera);

                if (sexo == 1)
                        totalHombres++;
                else if (sexo == 2)
                        totalMujeres++;

                if (carrera == 1)
                {
                        totalIngenieria++;
                        totalEdadIngenieria += edad;

                        if (sexo == 1)
                                totalHombresIngenieria++;
                        else if (sexo == 2)
                                totalMujeresIngenieria++;
                }

                i++;
        } while (i <= n);

        if (totalHombres + totalMujeres > 0)
        {
                printf("\nPorcentaje de hombres en la universidad: %.2f%%\n",
                       (totalHombres * 100.0) / (totalHombres + totalMujeres));
        }

        if (totalIngenieria > 0)
        {
                printf("Promedio de edad de los estudiantes de Ingeniería: %.2f\n",
                       (float)totalEdadIngenieria / totalIngenieria);

                if (totalMujeres > 0)
                        printf("Porcentaje de mujeres que estudian Ingeniería: %.2f%%\n",
                               (totalMujeresIngenieria * 100.0) / totalMujeres);
        }

        return 0;
}
