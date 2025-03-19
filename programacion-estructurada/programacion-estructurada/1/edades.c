// Realizar un programa que compare 2 edades, la edad de Juan(edad 1) y la edad de
// José(edad 2). Si edad1>edad2, que imprima en pantalla “Juan es mayor”, si no, que
// presente el mensaje “Jose es el mayor”. Correrlo para valores diferentes de edad1 y
// edad2. Haga uso del operador ternario.

#include <stdio.h>

int main()
{
        int edad1, edad2;
        char *resultado;

        printf("Ingrese la edad de Juan: ");
        scanf("%d", &edad1);

        printf("Ingrese la edad de José: ");
        scanf("%d", &edad2);

        resultado = edad1 > edad2 ? "Juan es mayor \n" : "José es el mayor \n";

        printf(resultado);

        return 0;
}