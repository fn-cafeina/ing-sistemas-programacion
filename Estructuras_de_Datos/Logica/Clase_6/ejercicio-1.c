// Escribir un programa que pida al usuario una palabra y la muestre por pantalla 10 veces,
// y se almacene en un archivo de texto .txt

#include <stdio.h>
#include <string.h>

#define MAX_TAM 25
#define REPETICIONES 10

int main()
{
        char palabra[MAX_TAM + 1];

        printf("Ingresa una palabra: ");
        fgets(palabra, sizeof(palabra), stdin);

        size_t len = strlen(palabra);
        if (len > 0 && palabra[len - 1] == '\n')
                palabra[len - 1] = '\0';

        FILE *fp = fopen("texto.txt", "w");
        if (!fp)
        {
                perror("Error al abrir archivo");
                return 1;
        }

        for (int i = 0; i < REPETICIONES; i++)
                fprintf(fp, "%s\n", palabra);

        fclose(fp);

        fp = fopen("texto.txt", "r");
        if (!fp)
        {
                perror("Error al abrir archivo");
                return 1;
        }

        char buffer[100];
        while (fgets(buffer, sizeof(buffer), fp))
                printf("%s", buffer);

        fclose(fp);
        return 0;
}
