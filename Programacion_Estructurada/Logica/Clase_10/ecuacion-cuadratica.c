// Crear un programa que calcule las 2 soluciones de una ecuación cuadrática del tipo ax2+bx+c.

#include <stdio.h>
#include <stdlib.h>
#include <math.h>

void ecuacionCuadratica(double, double, double);

int main()
{
        system("clear");

        double a, b, c;

        printf("--- Solucionador de ecuaciones cuadráticas ---\n\n");

        printf("Ingrese el coeficiente a: ");
        scanf("%lf", &a);

        printf("Ingrese el coeficiente b: ");
        scanf("%lf", &b);

        printf("Ingrese el coeficiente c: ");
        scanf("%lf", &c);

        ecuacionCuadratica(a, b, c);

        return 0;
}

void ecuacionCuadratica(double a, double b, double c)
{
        double discriminante = pow(b, 2) - 4 * a * c;

        printf("\nEcuación cuadratica: %.2fx² + %.2fx + %.2f = 0\n", a, b, c);
        printf("Discriminante: %.2f\n", discriminante);

        if (discriminante > 0)
        {
                double x1 = (-b + sqrt(discriminante)) / (2 * a);
                double x2 = (-b - sqrt(discriminante)) / (2 * a);

                printf("\nTipo de solución: Dos raíces reales distintas.\n");
                printf("x1: %.2f\n", x1);
                printf("x2: %.2f\n", x2);
        }
        else if (discriminante == 0)
        {
                double x = -b / (2 * a);

                printf("\nTipo de solución: Una raíz real.\n");
                printf("x: %.2f\n", x);
        }
        else
        {
                double parteReal = -b / (2 * a);
                double parteImaginaria = sqrt(-discriminante) / (2 * a);

                printf("\nTipo de solución: Raíces complejas conjugadas.\n");
                printf("x1: %.2f + %.2fi\n", parteReal, parteImaginaria);
                printf("x2: %.2f - %.2fi\n", parteReal, parteImaginaria);
        }
}