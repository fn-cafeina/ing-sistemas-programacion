// Elaborar programa que genere los 1000 primeros números primos y lo guarde en un fichero de texto
// llamado primo.txt. Cada número se escribirá en una línea.

#include <stdio.h>
#include <stdlib.h>

#define MAX_PRIMOS 1000

int main()
{
        FILE *f = fopen("primo.txt", "w");

        if (f == NULL)
        {
                printf("Error al abrir el archivo.\n");
                exit(1);
        }

        int contador = 0;
        int numero = 2;

        while (contador < MAX_PRIMOS)
        {
                int es_primo = 1;

                for (int j = 2; j * j <= numero; j++)
                {
                        if (numero % j == 0)
                        {
                                es_primo = 0;
                                break;
                        }
                }

                if (es_primo)
                {
                        fprintf(f, "%d\n", numero);
                        contador++;
                }

                numero++;
        }

        fclose(f);

        return 0;
}