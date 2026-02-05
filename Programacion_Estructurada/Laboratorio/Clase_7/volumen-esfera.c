// Realice un programa en C que calcule el volumen de una esfera,
// que viene dado por la siguiente formula:

#include <stdio.h>
#include <math.h>

int main()
{
        float r;

        printf("Ingrese el radio: ");
        scanf("%f", &r);

        printf("El volumen de dicha esfera es: %.2f \n", 4 / 3 * 3.1415 * powf(r, 3));

        return 0;
}