// Validar la edad para ingresar a un club:
// Un club permite la entrada a personas
// mayores de 18 años o a personas menores de 16 años acompañadas por un adulto.

#include <stdio.h>
#include <ctype.h>
#include <string.h>

int main()
{
        int edad;
        char opcion[3];

        printf("Ingrese su edad para entrar al club: ");
        scanf("%d", &edad);

        if (edad >= 18)
                printf("Usted puede entrar al club.\n");
        else
        {
                printf("Viene acompañado de un adulto?\nR = ");
                scanf("%s", &opcion);

                if (strcmp(opcion, "Si") == 0 || strcmp(opcion, "si") == 0)
                        printf("\nUsted puede entrar al club.\n");
                else
                        printf("\nUsted no puede entrar al club.\n");
        }

        return 0;
}