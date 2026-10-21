// Escribir un programa que pregunte al usuario su nombre, y luego lo salude.

#include <stdio.h>

int main()
{
        char nombre[99];

        printf("Ingrese su nombre: ");
        scanf("%s", &nombre);

        printf("Hola %s \n", nombre);

        return 0;
}