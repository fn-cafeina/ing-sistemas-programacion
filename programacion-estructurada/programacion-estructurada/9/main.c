#include <stdio.h>
#include "cafeina.h"

int main()
{
        int a, b;

        printf("Ingrese un número: ");
        scanf("%d", &a);

        printf("Ingrese otro número: ");
        scanf("%d", &b);

        printf("\nLa suma de %d y %d es: %d\n", a, b, sumar(a, b));
        printf("\nLa resta de %d y %d es: %d\n", a, b, restar(a, b));

        return 0;
}