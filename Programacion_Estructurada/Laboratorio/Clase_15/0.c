#include <stdio.h>
#define DIM 30

int main()
{
        int i, numero;
        char cadena[DIM];
        char caracter;

        printf("QUE CARACTER DESEA BUSCAR: ");
        scanf(" %c", &caracter);

        printf("\n\nINTRODUZCA LA CADENA DE CARACTERES: ");
        scanf("%s", cadena);

        numero = 0;

        for (i = 0; cadena[i] != '\0'; i++)
        {
                if (cadena[i] == caracter)
                {
                        numero++;
                }
        }

        printf("\n\nEL CARACTER '%c' APARECE %d VECES EN LA CADENA: %s\n", caracter, numero, cadena);
}