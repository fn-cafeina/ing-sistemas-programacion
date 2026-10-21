#include <stdio.h>

float area_rectangulo(float b, float a);

float entrada(void);

void main(void)
{
        float b, h, area;

        printf("\n Base del rectangulo: ");

        b = entrada();

        printf("\n Altura del rectangulo: ");

        h = entrada();

        area = area_rectangulo(b, h);

        printf("\n Area del rectangulo: %.2f\n", area);
}

float entrada(void)
{

        float m;

        do

        {

                scanf("%f", &m);

        } while (m <= 0.0);

        return m;
}

float area_rectangulo(float b, float a)
{
        return (b * a);
}