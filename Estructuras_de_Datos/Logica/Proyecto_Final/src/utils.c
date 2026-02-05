#include "utils.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void limpiar_pantalla(void)
{
#ifdef _WIN32
        system("cls");
#else
        system("clear");
#endif
}

void pausar(void)
{
        printf("\nPresione Enter para continuar...");

        int c = getchar();

        /**
         * Lógica de limpieza de búfer:
         * Si el primer caracter leído (c) no es un 'Enter' (ni EOF),
         * significa que el búfer de entrada (stdin) tenía caracteres residuales
         * (p.ej., de un 'scanf' anterior o un 'fgets' que no leyó todo).
         * Consumimos esos caracteres extra hasta encontrar el '\n'
         * para evitar el "doble enter" en la siguiente lectura.
         */
        if (c != '\n' && c != EOF)
        {
                while ((c = getchar()) != '\n' && c != EOF)
                        ;
        }
}

int leer_opcion(int min, int max)
{
        int opcion;
        char buffer[100];
        int es_valido = 0;

        while (!es_valido)
        {
                printf("Seleccione una opcion (%d-%d): ", min, max);
                if (fgets(buffer, sizeof(buffer), stdin) != NULL)
                {
                        // Validamos que se lea 1 solo ítem y esté en el rango
                        if (sscanf(buffer, "%d", &opcion) == 1 && opcion >= min && opcion <= max)
                        {
                                es_valido = 1;
                        }
                        else
                        {
                                printf("Error: Opcion no valida. Intente de nuevo.\n");
                        }
                }
        }
        return opcion;
}

void get_string(char *buffer, int len)
{
        fgets(buffer, len, stdin);
        // Eliminar el salto de línea final
        buffer[strcspn(buffer, "\n")] = 0;
}