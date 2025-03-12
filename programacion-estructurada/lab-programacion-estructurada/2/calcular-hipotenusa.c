#include <stdio.h>
#include <math.h>

int main()
{
        float cateto1, cateto2, hipo;

        printf("Ingrese el primer cateto: ");
        scanf("%f", &cateto1);

        printf("Ingrese el segundo cateto: ");
        scanf("%f", &cateto2);

        hipo = sqrtf(powf(cateto1, 2) + powf(cateto2, 2));

        printf("La hipotenusa es: %.2f \n", hipo);

        return 0;
}