// Un jefe de casilla desea determinar cuántas personas
// de cada una de las secciones que componen su zona asisten el día de la votaciones.
// Las secciones son: norte, sur y centro también desea determinar
// cuál es la sección con mayor número de votantes.

#include <stdio.h>

int main()
{
        int norte, sur, centro;
        char repetir;

        do
        {
                printf("Ingrese la cantidad de votantes en la sección Norte: ");
                scanf("%d", &norte);

                printf("Ingrese la cantidad de votantes en la sección Sur: ");
                scanf("%d", &sur);

                printf("Ingrese la cantidad de votantes en la sección Centro: ");
                scanf("%d", &centro);

                if (norte > sur && norte > centro)
                        printf("La sección con más votantes es: Norte (%d votantes)\n", norte);
                else if (sur > norte && sur > centro)
                        printf("La sección con más votantes es: Sur (%d votantes)\n", sur);
                else if (centro > norte && centro > sur)
                        printf("La sección con más votantes es: Centro (%d votantes)\n", centro);
                else
                        printf("Hay un empate entre dos o más secciones.\n");

                printf("¿Desea ingresar otra zona? (s/n): ");
                scanf(" %c", &repetir);

        } while (repetir == 's' || repetir == 'S');

        return 0;
}
