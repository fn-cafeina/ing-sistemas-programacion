// Elabore un programa que calcule la raíz cuadrada de un número
// ingresado por teclado.

#include <stdio.h>
#include <math.h>

int main()
{
        float n, raiz;

        printf("Ingrese un número: ");
        scanf("%f", &n);

        raiz = sqrtf(n);

        printf("La raíz cuadrada de dicho número es: %.f \n", raiz);

        return 0;
}