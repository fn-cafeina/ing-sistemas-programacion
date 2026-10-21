#include <stdio.h>
int main()
{
        FILE *fichero;
        char nombre[10] = "datos2.dat";
        unsigned int i;
        fichero = fopen(nombre, "w");
        printf("Fichero: %s (para escritura) -> ", nombre);
        if (fichero)
                printf("creado (ABIERTO)\n");
        else
        {
                printf("Error (NO ABIERTO)\n");
                return 1;
        }
        fprintf(fichero, "Esto es un ejemplo de usar la funcion \'fprintf\'\n");
        fprintf(fichero, "\t 2\t 3\t 4\n");
        fprintf(fichero, "x\tx\tx\tx\n\n");
        for (i = 1; i <= 10; i++)
                fprintf(fichero, "%d\t%d\t%d\t%d\n", i, i * i, i * i * i, i * i * i * i);
        fprintf(stdout, "Datos guardados en el fichero: %s\n", nombre);
        if (!fclose(fichero))
                printf("Fichero cerrado\n");
        else
        {
                printf("Error: fichero NO CERRADO\n");
                return 1;
        }
        return 0;
}