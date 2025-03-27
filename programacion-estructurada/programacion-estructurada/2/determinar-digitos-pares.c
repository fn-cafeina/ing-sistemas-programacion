// Realice un programa en C que, al recibir como dato un número entero de cuatro
// dígitos, determine si todos los dígitos del número son pares.
// Por ejemplo, si el número fuera 5688, no cumpliría la condición ya que el dígito más
// significativo —5— sería impar; si, por el contrario, el número fuera 6244, sí cumpliría,
// ya que todos los dígitos son pares.

#include <stdio.h>

int main()
{
        int n, n1, n2, n3, n4;

        printf("Ingrese un numero entero de 4 digitos: ");
        scanf("%d", &n);

        n4 = n % 10;
        n /= 10;
        n3 = n % 10;
        n /= 10;
        n2 = n % 10;
        n /= 10;
        n1 = n % 10;
        n /= 10;

        if (
            n1 % 2 == 0 &&
            n2 % 2 == 0 &&
            n3 % 2 == 0 &&
            n4 % 2 == 0)
                printf("Todos los numeros son pares.\n");
        else
                printf("No todos los numeros son pares.\n");

        return 0;
}