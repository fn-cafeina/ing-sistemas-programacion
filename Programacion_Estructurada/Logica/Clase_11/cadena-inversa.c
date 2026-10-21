// Realice un programa en C que, al recibir como dato una cadena
// de caracteres, escriba esa línea en forma inversa.

#include <stdio.h>
#include <string.h>

#define MAX 100

int main()
{
        char cadena[MAX];
        size_t longitud;

        printf("Ingrese una cadena: ");
        fgets(cadena, MAX, stdin);

        longitud = strlen(cadena);

        if (longitud > 0 && cadena[longitud - 1] == '\n')
                cadena[--longitud] = '\0';

        printf("\nCadena invertida: ");
        for (size_t i = longitud; i > 0; i--)
        {
                printf("%c", cadena[i - 1]);
        }

        printf("\n");

        return 0;
}