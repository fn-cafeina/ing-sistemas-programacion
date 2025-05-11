// Escribir una función que imprima por pantalla una pirámide como la de la figura:

#include <stdio.h>

void imprimirPiramide(int);

int main()
{
        int n;

        printf("Introduzca la altura de la piramide: ");
        scanf("%d", &n);

        imprimirPiramide(n);

        return 0;
}

void imprimirPiramide(int n)
{
        int i, j, espacio;

        i = 1;
        while (i <= n)
        {
                espacio = n - i;
                while (espacio > 0)
                {
                        printf("  ");
                        espacio--;
                }

                j = 1;
                while (j <= 2 * i - 1)
                {
                        printf("* ");
                        j++;
                }

                printf("\n");
                i++;
        }
}