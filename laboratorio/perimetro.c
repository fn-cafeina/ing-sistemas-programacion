#include <stdio.h>

#define PI 3.1416

int main()
{
        float perim, radio;
        int dos = 2;

        printf("Calcula el parametro de una circunferencia. \n");
        printf("Indique el tamaño de radio de la circunferencia: ");

        scanf("%f", & radio);

        perim = dos * PI * radio;

        printf("Constante pi = %f, valor de dos = %d, radio = %f \n", PI, dos, radio);
        printf("El resultado perimetro es: %f \n", perim);

        return 0;
}