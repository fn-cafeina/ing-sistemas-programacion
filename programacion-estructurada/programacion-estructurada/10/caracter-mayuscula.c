// Escribir un programa que, al recibir como dato una cadena de
// caracteres, convierta el primer carácter de cada palabra si ésta
// fuera una letra, de minúscula a mayúscula.

#include <stdio.h>
#include <ctype.h>
#include <string.h>

#define MAX 100

int main()
{
        char cadena[MAX];
        int i;
        int nuevaPalabra = 1;

        printf("Ingrese una cadena: ");
        fgets(cadena, MAX, stdin);

        for (i = 0; cadena[i] != '\0'; i++)
        {
                if (nuevaPalabra && isalpha(cadena[i]))
                {
                        cadena[i] = (char)toupper((unsigned char)cadena[i]);
                        nuevaPalabra = 0;
                }
                else if (isspace(cadena[i]))
                        nuevaPalabra = 1;
        }

        printf("Cadena convertida: %s", cadena);
        return 0;
}