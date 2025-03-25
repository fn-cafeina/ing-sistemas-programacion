// Realice un programa en C que dé como resultado los intereses producidos y el capital
// total acumulado en una cantidad X invertida a un interés r durante t días.

#include <stdio.h>

int main()
{
        float c, r, t, i;

        printf("Ingrese el capital: ");
        scanf("%f", &c);

        printf("Ingrese el interes: ");
        scanf("%f", &r);

        printf("Ingrese el tiempo: ");
        scanf("%f", &t);

        i = (c * r * t) / (360 * 100);

        printf("El resultado es: %.2f \n", i);

        return 0;
}