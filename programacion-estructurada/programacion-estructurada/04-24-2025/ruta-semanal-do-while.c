// Todos los lunes, miércoles y viernes, una persona corre la misma ruta y cronometra los
// tiempos obtenidos. Determinar el tiempo promedio que la persona tarda en recorrer la
// ruta en una semana cualquiera.

#include <stdio.h>

int main()
{
        int totalMinutos;

        int i;

        do
        {

                printf("Ingrese la cantidad de tiempo que recorrio el dia %s (Minutos): ", i == 0 ? "Lunes" : i == 1 ? "Miércoles"
                                                                                                                     : "Viernes");
                int tiempoMinutos;
                scanf("%d", &tiempoMinutos);

                totalMinutos += tiempoMinutos;

                i++;

        } while (i < 3);

        printf("\nEn recorrer la ruta tarda en promedio: %.2f minutos\n", (float)totalMinutos / 3);

        return 0;
}