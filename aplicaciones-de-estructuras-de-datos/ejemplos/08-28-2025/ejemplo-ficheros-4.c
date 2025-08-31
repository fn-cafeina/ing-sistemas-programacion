#include <stdio.h>
#include <stdlib.h>
int main(void)
{
        FILE *fp;
        char s[80];
        int t;
        if ((fp = fopen("test", "w")) == NULL)
        {
                printf("No se puede abrir el archivo.\n");
                exit(1);
        }
        printf("Ingresar una cadena y un numero: ");
        fscanf(stdin, "%s%d", s, &t); /* read from keyboard */
        fprintf(fp, "%s %d", s, t);   /* write to file */
        fclose(fp);
        if ((fp = fopen("test", "r")) == NULL)
        {
                printf("No se puede abrir el archivo.\n");
                exit(1);
        }
        printf("Contenido del fichero:");
        fscanf(fp, "%s%d", s, &t);        /* read from file */
        fprintf(stdout, "%s %d\n", s, t); /* print on screen */
        return 0;
}