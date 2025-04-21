// Dados N valores, diseñe un programa que haga el siguiente proceso:
// • Si el valor es menor que cero calcular su cubo.
// • Si el valor está entre 0 y 100 calcular su cuadrado.
// • Si el valor está entre 101 y 1000 calcular su raíz cuadrada.

#include <stdio.h>
#include <stdlib.h>
#include <math.h>

void limpiarBuffer()
{
        while (getchar() != '\n')
                ;
}

int main()
{
        if (system("cls"))
                system("clear");

        int num, i;
        float valor;
        int esValido;

        printf("Ingrese la cantidad de valores a procesar: ");
        esValido = scanf("%d", &num);

        if (esValido == 1)
        {
                if (num <= 0)
                {
                        printf("\nLa cantidad de valores debe ser mayor que cero.\n");
                        return 1;
                }
        }
        else
        {
                printf("\nIngrese un tipo de dato valido.\n");
                return 1;
        }

        for (i = 1; i <= num; i++)
        {
                printf("\nIngrese el valor numero %d: ", i);
                esValido = scanf("%f", &valor);

                if (esValido == 1)
                {
                        if (valor < 0)
                                printf("\n%.2f al cubo es: %.2f\n", valor, powf(valor, 3));
                        else if (valor >= 0 && valor <= 100)
                                printf("\n%.2f al cuadrado es: %.2f\n", valor, powf(valor, 2));
                        else if (valor > 100 && valor <= 1000)
                                printf("\nLa raiz cuadrada de %.2f es: %.2f\n", valor, sqrtf(valor));
                        else
                                printf("\nValor fuera de rango, saltando a la siguiente iteración\n");
                }
                else
                {
                        printf("\nIngrese un tipo de dato valido, saltando a la siguiente iteración.\n");
                        limpiarBuffer();
                        continue;
                }
        }

        return 0;
}