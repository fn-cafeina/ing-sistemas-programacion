#include "cafeina.h"

#include <stdio.h>
#include <stdlib.h>

int sumar(int a, int b)
{
        return a + b;
}

int restar(int a, int b)
{
        return a - b;
}

int multiplicar(int a, int b)
{
        return a * b;
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

void limpiarBuffer(void)
{
        while (getchar() != '\n')
                ;
}

void limpiarConsola(void)
{
        system("clear");
}