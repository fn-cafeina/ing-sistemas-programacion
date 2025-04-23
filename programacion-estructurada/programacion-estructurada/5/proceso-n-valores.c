// Dados N valores, diseñe un programa que haga el siguiente proceso:
// • Si el valor es menor que cero calcular su cubo.
// • Si el valor está entre 0 y 100 calcular su cuadrado.
// • Si el valor está entre 101 y 1000 calcular su raíz cuadrada.

#include <stdio.h>
#include <math.h>

int main()
{
        int n, i;
        float valor;

        printf("Ingrese la cantidad de valores: ");
        scanf("%d", &n);

        for (i = 1; i <= n; i++)
        {
                printf("\nIngrese el valor #%d: ", i);
                scanf("%f", &valor);

                if (valor < 0)
                        printf("- %.2f al cubo es: %.2f.\n", valor, pow(valor, 3));
                else if (valor >= 0 && valor <= 100)
                        printf("- %.2f al cuadrado es: %.2f.\n", valor, pow(valor, 2));
                else
                        printf("- La raiz cuadrada de %.2f es: %.2f.\n", valor, sqrtf(valor));
        }

        return 0;
}