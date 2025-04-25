// Realice un programa en C que calcule el promedio de 10 notas para un grupo de N alumnos.

#include <stdio.h>

int main()
{
        int alumnos;

        printf("Ingrese la cantidad de alumnos a evaluar: ");
        scanf("%d", &alumnos);

        int nota, ac;
        int i = 1, j;

        while (i <= alumnos)
        {
                ac = 0;

                printf("\nEvaluación del alumno #%d\n", i);

                j = 1;
                while (j <= 10)
                {
                        printf("\nIngrese la nota #%d: ", j);
                        scanf("%d", &nota);

                        ac += nota;

                        j++;
                }

                printf("\nEl promedio del estudiante #%d es de: %.2f\n", i, (float)ac / 10);

                i++;
        }

        return 0;
}