// Crea un programa que vaya leyendo las frases que el usuario teclea y las guarde en un fichero de
// texto llamado “registroDeUsuario.txt”. Terminará cuando la frase introducida sea "fin" (esa frase no
// deberá guardarse en el fichero).

#include <stdio.h>
#include <string.h>

#define MAX_FRASE 60

int main()
{
        FILE *ptFichero;
        char *fin = "fin";
        char frase[MAX_FRASE];

        // Verificación de que el fichero se haya creado correctamente
        if ((ptFichero = fopen("registroDeUsuario.txt", "wt")) == NULL)
        {
                printf("No se puede abrir fichero.\n");
                return 1;
        }

        printf("Programa para escribir frases, cuando quiera salir, escriba la palabra fin.\n\n");

        do
        {
                printf("Escriba una frase (o fin): ");

                fgets(frase, MAX_FRASE, stdin);

                frase[strcspn(frase, "\n")] = '\0';

                // Verifique que la entrada ha sido “fin” en caso de ser fin salga del ciclo
                // envíe la frase al archivo registro-de-usuario.txt
                if (strcmp(frase, fin) == 0)
                {
                        break;
                }

                fprintf(ptFichero, "%s\n", frase);
        } while (1);

        fclose(ptFichero);

        return 0;
}