// Dados dos números, mostrar la suma, resta, división y multiplicación de ambos.

#include <stdio.h>

int main()
{
        int n1, n2, suma, resta, multiplicacion;
        float division;

        printf("Ingrese 2 números: \n");
        scanf("%d %d", &n1, &n2);

        suma = n1 + n2;
        resta = n1 - n2;
        multiplicacion = n1 * n2;
        division = n1 / n2;

        printf("La suma de ambos números es: %d \n", suma);
        printf("La resta de ambos números es: %d \n", resta);
        printf("La multiplicación de ambos números es: %d \n", multiplicacion);
        printf("La división de ambos números es: %f \n", division);

        return 0;
}