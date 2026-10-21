// Realice un programa que introduzca un entero, si es par, que lo divida entre 2, si es impar,
// que le sume 500. En ambos casos imprima el resultado. (Use el operador ternario).

#include <stdio.h>

int main()
{
        int n, r;

        printf("Ingrese un número entero: ");
        scanf("%d", &n);

        r = n % 2 == 0 ? n / 2 : n + 500;

        printf("El número resultante es: %d \n", r);

        return 0;
}