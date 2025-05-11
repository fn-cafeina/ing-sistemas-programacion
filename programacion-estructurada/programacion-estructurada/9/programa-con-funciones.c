#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_LEN 100

int main()
{
        printf("Bienvenido al programa en C!\n");

        int numero;
        printf("Introduce un número: ");
        scanf("%d", &numero);
        getchar();
        printf("El número introducido es: %d\n", numero);

        printf("Introduce un carácter: ");
        int c = getchar();
        printf("El carácter introducido es: %c\n", c);

        getchar();

        char cadena[MAX_LEN];
        printf("Introduce una cadena: ");
        fgets(cadena, MAX_LEN, stdin);
        printf("La cadena introducida es: %s\n", cadena);

        int *ptr = (int *)malloc(sizeof(int));
        if (ptr == NULL)
        {
                printf("Error al reservar memoria\n");
                return 1;
        }
        *ptr = 42;
        printf("Valor en la memoria reservada: %d\n", *ptr);

        free(ptr);

        srand(42);
        int numAleatorio = rand() % 100;
        printf("Número aleatorio generado: %d\n", numAleatorio);

        char strNum[] = "123";
        int numConvertido = atoi(strNum);

        if (numConvertido == 0 && strcmp(strNum, "0") != 0)
        {
                printf("Error en la conversión de la cadena '%s' a un número.\n", strNum);
                return 1;
        }

        printf("El número convertido de la cadena '%s' es: %d\n", strNum, numConvertido);

        if (numConvertido == 123)
        {
                printf("El número es 123, pero no cerramos el programa.\n");
        }

        char destino[MAX_LEN];
        strcpy(destino, "Texto copiado");
        printf("Texto copiado: %s\n", destino);

        char saludo[MAX_LEN] = "Hola, ";
        strcat(saludo, "mundo!");
        printf("Cadena concatenada: %s\n", saludo);

        char cadena1[] = "Hola";
        char cadena2[] = "Mundo";
        int resultadoComparacion = strcmp(cadena1, cadena2);
        printf("Resultado de la comparación entre '%s' y '%s': %d\n", cadena1, cadena2, resultadoComparacion);

        size_t longitud = strlen(saludo);
        printf("Longitud de la cadena '%s' es: %zu\n", saludo, longitud);

        char texto[] = "uno,dos,tres";
        char *token = strtok(texto, ",");
        printf("Tokens de la cadena: \n");
        while (token != NULL)
        {
                printf("%s\n", token);
                token = strtok(NULL, ",");
        }

        return 0;
}
