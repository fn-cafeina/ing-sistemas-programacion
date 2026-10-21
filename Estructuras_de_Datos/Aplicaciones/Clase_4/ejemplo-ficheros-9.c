#include <stdio.h>
int main()
{
        FILE *fichero;
        char nombre[11] = "datos5.dat";
        unsigned int dinero[10] = {23, 12, 45, 345, 512, 345, 654, 287, 567,
                                   124};
        unsigned int leer[10], i;
        fichero = fopen(nombre, "w+");
        printf("Fichero: %s -> ", nombre);
        if (fichero)
                printf("creado (ABIERTO)\n");
        else
        {
                printf("Error (NO ABIERTO)\n");
                return 1;
        }
        printf("Escribiendo cantidades:\n\n");
        for (i = 0; i < 10; i++)
                printf("%d\t", dinero[i]);
        fwrite(dinero, sizeof(unsigned int), 10, fichero);
        printf("\nLeyendo los datos del fichero \"%s\":\n", nombre);
        rewind(fichero);
        fread(leer, sizeof(unsigned int), 10, fichero);
        for (i = 0; i < 10; i++)
                printf("%d\t", leer[i]);
        if (!fclose(fichero))
                printf("\nFichero cerrado\n");
        else
        {
                printf("\nError: fichero NO CERRADO\n");
                return 1;
        }
        return 0;
}