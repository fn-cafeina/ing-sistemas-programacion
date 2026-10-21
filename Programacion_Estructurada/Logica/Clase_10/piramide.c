// Escribir una función que imprima por pantalla una pirámide como la de la figura:

#include <stdio.h>

void Piramide(int altura);

int main()
{
        int n;

        printf("Introduzca la altura de la piramide: ");
        scanf("%d", &n);

        Piramide(n);

        return 0;
}

void Piramide(int altura)
{
        int i, j, espacio;

        i = 1;
        while (i <= altura)
        {
                espacio = altura - i;
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