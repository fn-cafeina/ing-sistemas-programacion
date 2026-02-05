#include <stdio.h>

int main()
{
        int kw;
        float pkw, tp;

        printf("Ingrese la cantidad de KW consumidos: ");
        scanf("%d", &kw);

        printf("Ingrese el precio del KW: ");
        scanf("%f", &pkw);

        tp = kw <= 150 ? (pkw * kw) - ((pkw * kw) * 0.2) : pkw * kw;

        printf("El total a pagar es de: %.2f C$ \n", tp);

        return 0;
}