// Un alumno desea saber cual será su calificación final en la materia de Algoritmos.
// Dicha calificación se compone de los siguientes porcentajes:
//
// 55% del promedio de sus tres calificaciones parciales.
// 30% de la calificación del examen final.
// 15% de la calificación de un trabajo final.

#include <stdio.h>

int main()
{
        int nota1, nota2, nota3;
        float notaFinal;

        printf("Ingrese la primera nota: (0 - 10) ");
        scanf("%d", &nota1);

        printf("Ingrese la segunda nota: (0 - 10) ");
        scanf("%d", &nota2);

        printf("Ingrese la tercera nota: (0 - 10) ");
        scanf("%d", &nota3);

        notaFinal = (nota1 * 0.55) + (nota2 * 0.3) + (nota3 * 0.15);

        printf("La nota final es: %.2f \n", notaFinal);

        return 0;
}