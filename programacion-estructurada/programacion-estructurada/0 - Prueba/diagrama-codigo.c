#include <stdio.h>
#include <math.h>

int main()
{
        float area, lado1, lado2, lado3, cat1, cat2, hip;

        printf("Ingrese los 3 lados del triangulo:\n");
        scanf("%f%f%f", &lado1, &lado2, &lado3);

        if (lado1 > lado2)
        {
                cat1 = lado2;

                if (lado1 > lado3)
                {
                        hip = lado1;
                        cat2 = lado3;
                }
                else
                {
                        hip = lado3;
                        cat2 = lado1;
                }
        }
        else
        {
                cat1 = lado1;

                if (lado2 > lado3)
                {
                        hip = lado2;
                        cat2 = lado3;
                }
                else
                {
                        hip = lado3;
                        cat2 = lado2;
                }
        }

        if (pow(hip, 2) == pow(cat1, 2) + pow(cat2, 2))
        {
                area = (cat1 * cat2) / 2;
                printf("El area es: %.2f\n", area);
        }
        else
                printf("No es un triangulo rectangulo.\n");

        return 0;
}