// Elaborar un programa que encuentre la suma de los primeros N términos de la sucesión de
// FIBONACCI. Esta se genera empezando por los números 0 y 1 y calculando cada nuevo
// miembro como la suma de los dos miembros precedentes de la sucesión, así:
// 0 1 1 2 3 5 8 13...

#include <stdio.h>
#include <stdlib.h>

int main()
{
        if (system("cls"))
                system("clear");

        int num;
        int act = 0, sig = 1;
        int op, sum = 0;

        printf("Ingrese un numero entero positivo: ");
        scanf("%d", &num);

        if (num >= 2)
                sum += 1;

        int i = 0;

        while (i < num - 2)
        {
                op = act + sig;

                sum += op;

                act = sig;
                sig = op;

                i++;
        }

        printf("La suma de %d terminos de la sucesión de fibonacci es: %d\n", num, sum);

        return 0;
}

// act = 0;
// sig = 1;
// op;
//
// op = act(0) + sig(1);
// act = sig(1);
// sig = op(1);
//
// op = act(1) + sig(1);
// act = sig(1);
// sig = op(2);
//
// op = act(1) + sig(2);
// act = sig(2);
// sig = op(3);
//
// op = act(2) + sig(3);
// act = sig(3);
// sig = op(5);
//
// op = act(3) + sig(5);
// act = sig(5);
// sig = op(8);