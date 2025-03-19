// Diseñar un programa utilizando el operador ternario, que compare dos valores x, y. Si x < y,
// entonces que realice la operación z = x + 5, si no, z = y – 3.
// Correrlo inicialmente para x = 3, y = 7 y luego para x = 10, y = 2.
// En cada caso, imprimir el valor de z.

#include <stdio.h>

int main()
{
        int x, y, z;

        x = 3;
        y = 7;

        z = x < y ? x + 5 : y - 3;

        printf("Cuando el valor de X es: %d y Y es de: %d, z sera: %d \n", x, y, z);

        x = 10;
        y = 2;

        z = x < y ? x + 5 : y - 3;

        printf("Cuando el valor de X es: %d y Y es de: %d, z sera: %d \n", x, y, z);

        return 0;
}