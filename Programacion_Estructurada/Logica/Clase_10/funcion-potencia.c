// Diseñe un programa con una función llamada potencia, que dada una cifra
// entera positiva, sea elevada a una potencia introducida por el usuario, la función
// recibirá 2 parámetros enteros y retornara el resultado de la operación. (Ejemplo: 5^2=25).

#include <stdio.h>

int potencia(int, int);

int main()
{
        int n, pot;

        printf("Ingrese un número: ");
        scanf("%d", &n);

        printf("Ingrese la potencia: ");
        scanf("%d", &pot);

        printf("\nLa potencia de %d es: %d\n", n, potencia(n, pot));

        return 0;
}

int potencia(int a, int b)
{
        if (!(a || b))
                return 0;

        int potencia = 1;
        int i = 1;

        while (i <= b)
        {
                potencia *= a;

                i++;
        }

        return potencia;
}