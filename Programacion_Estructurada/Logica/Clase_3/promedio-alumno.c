// Realice un programa en C que, al recibir como dato el promedio de un alumno en
// la clase de Programación Estructurada escriba aprobado si su promedio es mayor o
// igual a 60 y reprobado en caso contrario.

#include <stdio.h>

int main()
{
        float promedio;

        printf("Ingrese el promedio del estudiante: ");
        scanf("%f", &promedio);

        if (promedio >= 60)
                printf("Aprobado.\n");

        if (promedio < 60)
                printf("Reprobado.\n");

        return 0;
}