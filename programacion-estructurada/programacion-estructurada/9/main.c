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
        printf("La resta de %d y %d es: %d\n", a, b, restar(a, b));
        printf("La multiplicación de %d y %d es: %d\n", a, b, multiplicar(a, b));

        printf("\nEl número %d %s de fibonacci.\n", a, esFibonacci(a) ? "es" : "no es");
        printf("El número %d %s de fibonacci.\n", b, esFibonacci(b) ? "es" : "no es");

        return 0;
}