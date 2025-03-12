#include <stdio.h>

int main()
{
        int edad;
        char nombre[99];

        printf("Escriba su nombre: ");
        scanf("%s", &nombre);

        printf("Escriba su edad: ");
        scanf("%d", &edad);

        printf("Su nombre es: %s \n", nombre);
        printf("Su edad es: %d \n", edad);

        return 0;
}