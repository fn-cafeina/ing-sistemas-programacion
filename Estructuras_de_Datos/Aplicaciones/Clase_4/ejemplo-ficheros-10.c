#include <stdio.h>
#include <stdlib.h>
int main(int argc, char *argv[])
{
        FILE *pf;
        char car;
        if (argc != 2)
        {
                printf("Olvido introducir nombre de archive \n");
                exit(-1);
        }
        /* Apertura del Fichero*/
        if ((pf = fopen(argv[1], "w")) == NULL)
        {
                perror(" No se puede abrir fichero");
                exit(-1);
        }
        printf("Introduzca datos Finaliza con ctr Z");
        do
        {
                car = getchar();
                fputc(car, pf);
        } while (car != EOF);
        if (ferror(pf))
                perror("Error de escritura ");
        fclose(pf);
        return 0;
}