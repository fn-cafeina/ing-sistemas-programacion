// Realice un programa en C que pregunte el nombre, año de nacimiento, el año actual
// e imprima el siguiente resultado:
// Hola nombre, en el año 2022 cumples n años.

#include <stdio.h>

int main()
{
        char nombre[99];
        int anyoActual, anyoNacimiento;

        printf("Ingrese su nombre: ");
        scanf("%s", &nombre);

        printf("Ingrese su año de nacimiento: ");
        scanf("%d", &anyoNacimiento);

        printf("Ingrese el año actual: ");
        scanf("%d", &anyoActual);

        printf("Hola %s, en el año %d cumples %d años. \n", nombre, anyoActual, anyoActual - anyoNacimiento);

        return 0;
}