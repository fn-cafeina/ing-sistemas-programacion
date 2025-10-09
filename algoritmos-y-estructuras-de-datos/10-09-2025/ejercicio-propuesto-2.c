/*
        Modificar el programa 1.2 de la parte teórica que implementa búsqueda Secuencial de un elemento
        determinado, dentro de un array de N elementos, usando punteros.
*/

#include <stdio.h>
#include <string.h>

int main()
{
        char cadena[] = "Computación";
        char letra_buscada = 'u';
        char *posicion = NULL;
        char *ptr = cadena;

        printf("Cadena: %s\n", cadena);
        printf("Buscando la letra: '%c'\n\n", letra_buscada);

        while (*ptr != '\0')
        {
                if (*ptr == letra_buscada)
                {
                        posicion = ptr;
                        break;
                }
                ptr++;
        }

        if (posicion != NULL)
        {
                printf("Letra '%c' encontrada en la posición: %ld\n", letra_buscada, posicion - cadena);
        }
        else
        {
                printf("Letra '%c' no encontrada en la cadena.\n", letra_buscada);
        }

        return 0;
}