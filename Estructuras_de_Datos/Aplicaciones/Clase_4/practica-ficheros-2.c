// Elaborar un programa que lea archivo creado en el enunciado anterior llamado SALIDA.TXT, y
// muestre como resultado el número de líneas del archivo.

#include <stdio.h>

#define MAX_LINEA 100

int main()
{
        FILE *fd = fopen("salida.txt", "r");

        if (!fd)
        {
                printf("Error: No se pudo abrir el archivo.");
                exit(0);
        }

        char caracteres[MAX_LINEA];

        int i = 0;

        while (fgets(caracteres, MAX_LINEA, fd) != NULL)
                printf("Linea %d: %s", ++i, caracteres);

        fclose(fd);

        return 0;
}