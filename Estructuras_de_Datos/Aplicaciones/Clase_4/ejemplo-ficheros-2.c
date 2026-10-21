#include <stdio.h>
#include <string.h>

#define MAXLINEA 100

int main()
{
        char n_arch[] = {"KYR7-01.dat"}; /* nombre archivo de datos */
        char mensaje[] = {"Esta es una linea de prueba.\n"};
        char linea[MAXLINEA]; /* para lectura */
        FILE *p_arch;         /* puntero al archivo */
        int i = {0};
        printf("\n\nAcceso a archivos.\n");

        /* reescribe o crea el archivo, agrega una línea */
        if ((p_arch = fopen(n_arch, "w")) == NULL)
        {
                printf("no se puede abrir archivo %s", n_arch);
                return 1; /* error, no pudo abrir el archivo */
        }
        else
        {
                fputs(mensaje, p_arch); /* graba línea en archivo */
                fclose(p_arch);
                printf("Graba línea en archivo.\n");
        }

        /* lectura del archivo, una l¡nea */
        p_arch = fopen(n_arch, "r");
        fgets(linea, MAXLINEA, p_arch);
        fclose(p_arch);
        printf("Ley línea: %s", linea);

        /* agrega una línea al archivo */
        p_arch = fopen(n_arch, "a");
        strcpy(linea, "Esta es una l¡nea agregada al archivo.\n");
        fputs(linea, p_arch);
        fclose(p_arch);
        printf("Agrega línea al archivo.\n");

        /* lee líneas del archivo hasta terminar */
        printf("Lectura de varias l¡neas:\n");
        p_arch = fopen(n_arch, "r");
        while (fgets(linea, MAXLINEA, p_arch) != NULL)
        {
                printf("L¡nea %i: %s", ++i, linea);
        }
        fclose(p_arch);
        printf("Fin de pruebas de acceso a archivos.\n");
        return 0;
}