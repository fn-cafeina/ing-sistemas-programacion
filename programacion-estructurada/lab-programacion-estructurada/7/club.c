// Validar la edad para ingresar a un club:
// Un club permite la entrada a personas
// mayores de 18 años o a personas menores de 16 años acompañadas por un adulto.

#include <stdio.h>

int main()
{
        int edad;

        printf("Ingrese su edad para entrar al club: ");
        scanf("%d", &edad);

        if (edad >= 18)
                printf("Usted puede entrar al club.\n");
        else
        {
                printf("Usted no puede entrar al club.\n");
        }

        return 0;
}