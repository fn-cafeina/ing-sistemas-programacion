#include <stdio.h>
#include <stdlib.h>
int main(int argc, char *argv[])
{
        FILE *pf;
        char car;
        if (argc != 2)
        {
                printf("Olvido introducir nombre de archivo \n");
                exit(-1);
        }
        /* Apertura del Fichero*/
        if ((pf = fopen(argv[1], "r")) == NULL)
        {
                perror(" No se puede abrir fichero");
                exit(-1);
        }
        car = fgetc(pf);
        while (car != EOF)
        {
                printf("%c", car); // o putchar(car); muestra en pantalla
                car = fgetc(pf);
        }
        if (ferror(pf))
                perror("Error de lectura");
        fclose(pf);
        return 0;
}