#include <stdio.h>
int main()
{
        char nombre[10] = "datos.dat", linea[81];
        FILE *fichero;
        // leemos del fichero
        fichero = fopen(nombre, "r");
        printf("Fichero: %s -> ", nombre);
        if (fichero)
                printf("existe (ABIERTO)\n");
        else
        {
                printf("Error (NO ABIERTO)\n");
                return 1;
        }
        printf("La primera linea del fichero: %s\n\n", nombre);
        fgets(linea, 81, fichero);
        printf("%s\n", linea);
        if (!fclose(fichero))
                printf("\nFichero cerrado\n");
        else
        {
                printf("\nError: fichero NO CERRADO\n");
                return 1;
        }
        return 0;
}