// Escribir un programa interactivo en C que acepte el nombre de un país como entrada y escriba
// su correspondiente capital. Diseñar el programa de modo que se ejecute repetidamente, hasta
// que se introduzca la palabra Fin.

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_LEN 64

void leer_linea(char *buf, size_t n)
{
        if (fgets(buf, (int)n, stdin))
        {
                size_t L = strlen(buf);
                if (L && buf[L - 1] == '\n')
                        buf[L - 1] = '\0';
        }
        else
        {
                if (n)
                        buf[0] = '\0';
        }
}

int main(void)
{
        int n;
        printf("¿Cuantos pares (pais, capital) desea ingresar? ");
        if (scanf("%d", &n) != 1 || n <= 0)
        {
                fprintf(stderr, "Cantidad invalida.\n");
                return 1;
        }

        int c;
        while ((c = getchar()) != '\n' && c != EOF)
        {
        }

        char **paises = (char **)malloc(n * sizeof(char *));
        char **capitales = (char **)malloc(n * sizeof(char *));
        if (!paises || !capitales)
        {
                fprintf(stderr, "Error de memoria.\n");
                free(paises);
                free(capitales);
                return 1;
        }
        for (int i = 0; i < n; i++)
        {
                paises[i] = (char *)malloc(MAX_LEN);
                capitales[i] = (char *)malloc(MAX_LEN);
                if (!paises[i] || !capitales[i])
                {
                        fprintf(stderr, "Error de memoria.\n");
                        for (int k = 0; k <= i; k++)
                        {
                                free(paises[k]);
                                free(capitales[k]);
                        }
                        free(paises);
                        free(capitales);
                        return 1;
                }
        }

        printf("\n>> Ingrese los %d paises y sus capitales\n", n);
        for (int i = 0; i < n; i++)
        {
                printf("Pais [%d]: ", i + 1);
                leer_linea(paises[i], MAX_LEN);
                printf("Capital [%d]: ", i + 1);
                leer_linea(capitales[i], MAX_LEN);
        }

        char consulta[MAX_LEN];
        printf("\n=== Consulta (escriba 'Fin' para terminar) ===\n");
        while (1)
        {
                printf("Pais: ");
                leer_linea(consulta, sizeof(consulta));
                if (strcmp(consulta, "Fin") == 0)
                        break;

                int pos = -1;
                for (int i = 0; i < n; i++)
                {
                        if (strcmp(consulta, paises[i]) == 0)
                        {
                                pos = i;
                                break;
                        }
                }
                if (pos >= 0)
                {
                        printf("Capital: %s\n", capitales[pos]);
                }
                else
                {
                        printf("No se encontro el pais '%s'.\n", consulta);
                }
        }

        for (int i = 0; i < n; i++)
        {
                free(paises[i]);
                free(capitales[i]);
        }
        free(paises);
        free(capitales);
        return 0;
}
