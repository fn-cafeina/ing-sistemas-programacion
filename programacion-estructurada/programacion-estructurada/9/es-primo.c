// Diseñe un Programa en C que contenga una función llamada primo que reciba
// como parámetro un numero entero positivo. Retorne 1 si en número es primo de
// lo contrario retorne 0. Nota: Los números primos sólo son divisibles por el
// mismo y por la unidad.

#include <stdio.h>

int esPrimo(int);

int main()
{
        int n;

        printf("Ingrese un número para verificar si es primo: ");
        scanf("%d", &n);

        printf("\nEl número %d %s primo.\n", n, esPrimo(n) ? "es" : "no es");

        return 0;
}

int esPrimo(int n)
{
        if (n <= 1)
                return 0;

        int i;

        for (i = 2; i <= n / 2; i++)
        {
                if (n % i == 0)
                        return 0;
        }

        return 1;
}