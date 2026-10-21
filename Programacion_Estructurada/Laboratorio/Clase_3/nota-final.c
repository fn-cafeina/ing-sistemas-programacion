// Un alumno desea saber cual será su calificación final en la materia de Algoritmos.
// Dicha calificación se compone de los siguientes porcentajes:
//
// 55% del promedio de sus tres calificaciones parciales.
// 30% de la calificación del examen final.
// 15% de la calificación de un trabajo final.

#include <stdio.h>

int main()
{
        int nota1, nota2, nota3, examenF, trabajoF;
        float promedioC, notaF;

        printf("Ingrese las 3 primeras notas parciales (0 - 10): \n");
        scanf("%d %d %d", &nota1, &nota2, &nota3);

        printf("Ingrese la calificacion del examen final (0 - 10): ");
        scanf("%d", &examenF);

        printf("Ingrese la calificacion del trabajo final (0 - 10): ");
        scanf("%d", &trabajoF);

        promedioC = ((nota1 + nota2 + nota3) / 3);

        notaF = (promedioC * 0.55) + (examenF * 0.3) + (trabajoF * 0.15);

        printf("La nota final es: %.2f \n", notaF);

        return 0;
}