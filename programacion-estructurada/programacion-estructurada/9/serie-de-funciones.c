// Realice un programa que imprima la suma de la siguiente serie implementando
// funciones.

#include <stdio.h>
#include <math.h>

void sumaSerie(int, int);
int fact(int);

int main()
{
        int x, n;

        printf("Ingrese el valor de x: ");
        scanf("%d", &x);

        printf("Ingrese el valor de n: ");
        scanf("%d", &n);

        printf("\nResultado de la serie:\n");
        sumaSerie(x, n);

        return 0;
}

void sumaSerie(int x, int n)
{
        double resultado = 1;
        int i;

        for (i = 1; i <= n; i++)
        {
                resultado += pow(x, i) / fact(i);
                printf("%.2lf\n", resultado);
        }
}

int fact(int n)
{

        if (n == 1 || n == 0)
                return 1;

        int factorial = 1;
        int i;

        for (i = 1; i <= n; i++)
        {
                factorial *= i;
        }

        return factorial;
}