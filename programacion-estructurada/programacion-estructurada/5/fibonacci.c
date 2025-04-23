// Elaborar un programa que encuentre la suma de los primeros N términos de la sucesión de
// FIBONACCI. Esta se genera empezando por los números 0 y 1 y calculando cada nuevo
// miembro como la suma de los dos miembros precedentes de la sucesión, así:
// 0 1 1 2 3 5 8 13...

#include <stdio.h>
#include <stdlib.h>

int main()
{
        int n, i, act = 0, sig = 1, op = 0, sum = 0;

        printf("Ingrese un número: ");
        scanf("%d", &n);

        if (n < 1)
        {
                printf("Ingrese un número positivo.\n");
                exit(0);
        }

        for (i = 0; i < n; i++)
        {
                sum += act;
                op = act + sig;
                act = sig;
                sig = op;
        }

        printf("La suma de los primeros %d términos de la sucesión de Fibonacci es: %d\n", n, sum);

        return 0;
}
