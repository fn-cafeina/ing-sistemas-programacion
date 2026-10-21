#include <stdio.h>
int main()
{
        FILE *fichero;
        char nombre[10] = "datos3.dat";
        unsigned int i, x1, x2, x3, x4;
        // Insertar datos en el fichero
        fichero = fopen(nombre, "w");
        printf("Fichero: %s (para escritura) -> ", nombre);
        if (fichero)
                printf("creado (ABIERTO)\n");
        else
        {
                printf("Error (NO ABIERTO)\n");
                return 1;
        }
        printf("Escribiendo datos con la funcion \'fprintf\'\n");
        for (i = 1; i <= 10; i++)
                fprintf(fichero, "%d\t%d\t%d\t%d\n", i, i * i, i * i * i, i * i * i * i);
        fclose(fichero);
        // Leer datos
        fichero = fopen(nombre, "r");
        printf("Fichero: %s (para lectura) -> ", nombre);
        if (fichero)
                printf("existe (ABIERTO)\n");
        else
        {
                printf("Error (NO ABIERTO)\n");
                return 1;
        }
        printf("Datos leidos del fichero: %s\n", nombre);
        printf("Esto es un ejemplo de usar la funcion \'fscanf\'\n");
        printf("x\tx\tx\tx\n\n");
        for (i = 1; i <= 10; i++)
        {
                fscanf(fichero, "%d\t%d\t%d\t%d\n", &x1, &x2, &x3, &x4);
                printf("%d\t%d\t%d\t%d\n", x1, x2, x3, x4);
        }
        if (!fclose(fichero))
                printf("Fichero cerrado\n");
        else
        {
                printf("Error: fichero NO CERRADO\n");
                return 1;
        }
        return 0;
}