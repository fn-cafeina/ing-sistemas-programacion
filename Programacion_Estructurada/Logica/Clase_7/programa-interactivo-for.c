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

        for (int i = 2; i <= n / 2; i++)
        {
                if (n % i == 0)
                        return 0;
        }

        return 1;
}

int esFibonacci(int n)
{
        int act = 0, sig = 1, op;

        for (;;)
        {
                if (act == n)
                        return 1;
                if (act > n)
                        return 0;
                op = act + sig;
                act = sig;
                sig = op;
        }
}

int main()
{
        int numero;

        for (;;)
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
        }

        printf("Programa finalizado.\n");

        return 0;
}
