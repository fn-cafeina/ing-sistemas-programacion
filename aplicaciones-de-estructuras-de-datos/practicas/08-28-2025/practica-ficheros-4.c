// Diseñe programa que lea el fichero primos.txt generado por el programa anterior y muestre por
// pantalla su contenido

#include <stdio.h>
#include <stdlib.h>

int main()
{

        FILE *f;

        if ((f = fopen("primo.txt", "r")) == NULL)
        {
                printf("Error: No se pudo abrir el archivo.\n");
                exit(0);
        }

        int numero;

        printf("-- Contenido del archivo --\n");

        int contador = 1;
        while (fscanf(f, "%d", &numero) != EOF)
        {
                printf("%d: %d\n", contador, numero);
                contador++;
        }

        fclose(f);

        return 0;
}