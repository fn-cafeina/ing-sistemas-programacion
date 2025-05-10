// Crear un programa que calcule las 2 soluciones de una ecuación cuadrática del tipo ax2+bx+c.

#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int esFactorizable(int, int, int);
int esCuadradoPerfecto(int);
void factorizar(int, int, int);

int main()
{
        system("clear");

        int a, b, c;

        printf("Calcular trinomio de la forma (ax² + bx + c)\n");
        printf("Ingresar unicamente valores positivos.\n\n");

        printf("a = ");
        scanf("%d", &a);

        printf("b = ");
        scanf("%d", &b);

        printf("c = ");
        scanf("%d", &c);

        if (esFactorizable(a, b, c))
                factorizar(a, b, c);
}

int esFactorizable(int a, int b, int c)
{
        int discriminante;

        discriminante = (int)pow(b, 2) - 4 * a * c;

        if (esCuadradoPerfecto(discriminante))
                return 1;
        else
                return 0;
}

int esCuadradoPerfecto(int n)
{
        if (n < 1)
                return 0;

        int i;

        for (i = 0; i <= n; i++)
        {
                if (i * i == n)
                        return 1;

                if (i * i > n)
                        break;
        }

        return 0;
}

void factorizar(int a, int b, int c)
{
        system("clear");
        printf("\nResolveremos %dx² + %dx + %d por factorización.\n", a, b, c);
}