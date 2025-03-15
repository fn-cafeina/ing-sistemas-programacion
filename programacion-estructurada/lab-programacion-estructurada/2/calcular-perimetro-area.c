// Calcular el perímetro y área de un rectángulo dada su base y su altura.

#include <stdio.h>

int main()
{
        float base, altura, perimetro, area;

        printf("Ingrese la base del rectangulo: ");
        scanf("%f", &base);

        printf("Ingrese la altura del rectangulo: ");
        scanf("%f", &altura);

        perimetro = 2 * (base + altura);
        area = base * altura;

        printf("El area del rectangulo es: %.2f y su perimetro es: %.2f \n", area, perimetro);

        return 0;
}