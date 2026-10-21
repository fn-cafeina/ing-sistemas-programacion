// Escribir una función en C que cuente el número de ocurrencias de cada vocal
// (tanto si es mayúscula como minúscula) en una cadena de caracteres y los
// muestre por pantalla.

#include <stdio.h>
#include <ctype.h>
#include <string.h>

int vocales(char[]);

int main()
{
        char cadena[100];
        int buffer = sizeof(cadena);

        printf("Ingrese una cadena (max: %d): ", buffer);
        fgets(cadena, buffer, stdin);

        cadena[strlen(cadena) - 1] = '\0';

        printf("\nEn la cadena \"%s\" hay %d vocales.\n", cadena, vocales(cadena));

        return 0;
}

int vocales(char cadena[])
{
        int cantidadVocales = 0;
        int temp;
        int i;

        for (i = 0; cadena[i]; i++)
        {
                temp = tolower(cadena[i]);

                if (temp == 'a' ||
                    temp == 'e' ||
                    temp == 'i' ||
                    temp == 'o' ||
                    temp == 'u')
                        cantidadVocales++;
        }

        return cantidadVocales;
}