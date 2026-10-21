// Elaborar un programa que utiliza la función fopen para crear un archivo de texto llamada
// SALIDA.TXT, que almacene desde la consola todo el texto que se digite y finalice con la orden
// CTRL + Z.

#include <stdio.h>
#include <stdlib.h>

#define MAX_LINEA 100

int main()
{
        FILE *fd;

        fd = fopen("salida.txt", "w");

        if (!fd)
        {
                printf("Error: No se pudo abrir el archivo.");
                exit(0);
        }

        char caracteres[MAX_LINEA];

        while (fgets(caracteres, MAX_LINEA, stdin) != NULL)
                fprintf(fd, "%s", caracteres);

        fclose(fd);

        return 0;
}