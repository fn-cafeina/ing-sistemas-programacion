// Leer 50 calificaciones de un grupo de alumnos calcule y escriba el porcentaje de reprobados.
// Tomando en cuenta que la calificación mínima aprobatoria es de 70.

#include <stdio.h>

int main()
{
        int calificacion, i = 0, reprobados = 0;
        float porcentaje;

        do
        {
                printf("Ingrese la calificación del alumno %d: ", i + 1);
                scanf("%d", &calificacion);

                if (calificacion < 70)
                        reprobados++;

                i++;
        } while (i < 50);

        porcentaje = (float)((reprobados * 100.0) / 50.0);

        printf("Porcentaje de reprobados: %.2f%%\n", porcentaje);

        return 0;
}
