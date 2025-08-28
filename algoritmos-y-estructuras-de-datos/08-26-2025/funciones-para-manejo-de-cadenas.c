/*
    Archivo: medina_jasmir_ej2.c
    Ejercicio 2: Funciones para Manejo de Cadenas
*/

#include <stdio.h>
#include <stdlib.h>

// Calcula la longitud de una cadena sin usar strlen()
int longitud_cad(char *cadena)
{
        if (cadena == NULL)
        { // Validación de puntero NULL
                return -1;
        }
        int longitud = 0;
        while (*(cadena + longitud) != '\0')
        {
                // * desreferencia el valor al que apunta "cadena"
                longitud++;
        }
        return longitud;
}

// Copia una cadena sin usar strcpy()
void copia_cadena(char *destino, char *origen)
{
        if (destino == NULL || origen == NULL)
        { // Validamos punteros NULL
                return;
        }
        while (*origen != '\0')
        {
                *destino = *origen; // Copiamos carácter por carácter
                origen++;
                destino++;
        }
        *destino = '\0'; // Finalizamos la cadena
}

int main()
{
        char origen[100];
        char destino[100];

        printf("Ingrese una cadena (max 99 caracteres): ");
        if (fgets(origen, sizeof(origen), stdin) == NULL)
        {
                printf("Error al leer la cadena.\n");
                return 1;
        }

        // Eliminar salto de línea si fgets lo agregó
        int len = longitud_cad(origen);
        if (len > 0 && origen[len - 1] == '\n')
        {
                origen[len - 1] = '\0';
        }

        copia_cadena(destino, origen);

        printf("Cadena original: %s\n", origen);
        printf("Longitud calculada: %d\n", longitud_cad(origen));
        printf("Cadena copiada: %s\n", destino);

        return 0;
}

/*
    Nota Técnica:
    Un error común con punteros en cadenas es no dejar espacio suficiente en el destino.
    Esto puede provocar desbordamiento de memoria (buffer overflow).
    Para evitarlo, se debe declarar el destino con un tamaño suficiente
    y controlar el número de caracteres copiados.
*/
