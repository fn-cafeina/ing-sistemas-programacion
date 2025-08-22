#include <stdio.h>
#include <ctype.h>
#include <stdbool.h>

int main()
{
        char cadena[] = "este es un ejemplo. con varias frases. para probar la funcion.";
        char *ptr = cadena;
        bool capitalizar_siguiente = true;

        printf("Cadena original: \n%s\n", cadena);

        while (*ptr != '\0')
        {
                if (capitalizar_siguiente && isalpha(*ptr))
                {
                        *ptr = toupper(*ptr);
                        capitalizar_siguiente = false;
                }

                if (*ptr == '.')
                {
                        capitalizar_siguiente = true;
                }

                ptr++;
        }

        printf("\nCadena modificada: \n%s\n", cadena);

        return 0;
}