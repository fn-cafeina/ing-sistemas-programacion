/*
        Elaborar un programa usando la búsqueda secuencial para encontrar la letra dentro de una
        cadena de caracteres. Ejemplo. Cadena: Computación, Buscar la letra: u
*/

#include <stdio.h>
#include <string.h>

int main()
{
        char cadena[] = "Computación";
        char letra_buscada = 'u';
        int posicion = -1;
        int longitud = strlen(cadena);

        printf("Cadena: %s\n", cadena);
        printf("Buscando la letra: '%c'\n\n", letra_buscada);

        for (int i = 0; i < longitud; i++)
        {
                if (cadena[i] == letra_buscada)
                {
                        posicion = i;
                        break;
                }
        }

        if (posicion != -1)
        {
                printf("Letra '%c' encontrada en la posición: %d\n", letra_buscada, posicion);
        }
        else
        {
                printf("Letra '%c' no encontrada en la cadena.\n", letra_buscada);
        }

        return 0;
}