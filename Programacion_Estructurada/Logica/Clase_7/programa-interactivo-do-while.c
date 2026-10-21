// Escribir un programa interactivo que lea un valor entero positivo y determine lo
// siguiente:
// • Si el entero es un número primo.
// • Si el entero es un número de Fibonacci.
// Escribir el programa de forma que se ejecute de forma repetida, hasta que se introduzca
// como valor de entrada un cero.

#include <stdio.h>

int esPrimo(int n)
{
        if (n <= 1)
                return 0;

        int i = 2;

        do
        {
                if (n % i == 0)
                        return 0;
                i++;
        } while (i <= n / 2);

        return 1;
}

int esFibonacci(int n)
{
        int act = 0, sig = 1, op;

        if (n == 0 || n == 1)
                return 1;

        do
        {
                op = act + sig;
                act = sig;
                sig = op;

                if (sig == n)
                        return 1;
        } while (sig < n);

        return 0;
}

int main()
{
        int numero;

        do
        {
                printf("Introduce un número entero positivo (0 para salir): ");
                scanf("%d", &numero);

                if (numero == 0)
                        break;

                if (esPrimo(numero))
                        printf("%d es un número primo.\n", numero);
                else
                        printf("%d no es un número primo.\n", numero);

                if (esFibonacci(numero))
                        printf("%d es un número de Fibonacci.\n", numero);
                else
                        printf("%d no es un número de Fibonacci.\n", numero);

                printf("\n");

        } while (numero != 0);

        printf("Programa finalizado.\n");

        return 0;
}