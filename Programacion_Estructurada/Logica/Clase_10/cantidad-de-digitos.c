// Escribir un programa en C que defina una función que tome un valor entero y
// devuelva el número de dígitos que tiene dicha cantidad.

#include <stdio.h>

int digitos(int);

int main()
{
        int n;

        printf("Ingrese un número: ");
        scanf("%d", &n);

        printf("\nEl número: %d tiene %d digitos.\n", n, digitos(n));

        return 0;
}

int digitos(int n)
{
        int cantidadDeDigitos = 0;

        for (; n; n /= 10)
        {
                cantidadDeDigitos++;
        }

        return cantidadDeDigitos;
}