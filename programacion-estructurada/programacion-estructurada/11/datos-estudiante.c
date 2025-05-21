// Haga un programa en C que lea en una estructura o en una variable de tipo struct:
// el nombre, número de carnet, año de nacimiento y el sexo de un estudiante,
// y que imprima los datos miembros de la estructura y la edad a partir del año de nacimiento.

#include <stdio.h>
#include <ctype.h>

#define ANYOACTUAL 2025

struct estudiante
{
        char nombre[50];
        char carnet[20];
        int anyoNacimiento;
        char sexo;
};

int main()
{
        struct estudiante estudiante1;

        printf("Ingrese su nombre: ");
        scanf("%s", estudiante1.nombre);
        printf("Ingrese número de carnet: ");
        scanf("%s", estudiante1.carnet);
        printf("Ingrese su año de nacimiento: ");
        scanf("%d", &estudiante1.anyoNacimiento);
        printf("Ingrese su sexo (M o F): ");
        scanf(" %c", &estudiante1.sexo);

        printf("\nNombre del estudiante: %s\n", estudiante1.nombre);
        printf("Carnet del estudiante: %s\n", estudiante1.carnet);
        printf("Edad del estudiante: %d\n", ANYOACTUAL - estudiante1.anyoNacimiento);
        printf("Sexo del estudiante: %s\n", tolower(estudiante1.sexo) == 'm' ? "Masculino" : "Femenino");

        return 0;
}