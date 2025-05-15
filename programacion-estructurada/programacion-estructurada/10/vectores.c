// Escriba un programa que lee dos vectores A y B de 20 elementos
// cada uno y multiplica el primer elemento de A por el último de
// B y así sucesivamente hasta llegar al último elemento de A por
// el primero elemento de B. El resultado de la multiplicación se
// almacena en un vector C.

#include <stdio.h>
#define N 5

int main()
{
        int A[N], B[N], C[N], i;

        printf("Ingrese los %d elementos de A:\n", N);
        for (i = 0; i < N; i++)
        {
                printf("A[%d]: ", i);
                scanf("%d", &A[i]);
        }

        printf("\nIngrese los %d elementos de B:\n", N);
        for (i = 0; i < N; i++)
        {
                printf("B[%d]: ", i);
                scanf("%d", &B[i]);
        }

        for (i = 0; i < N; i++)
        {
                C[i] = A[i] * B[N - 1 - i];
        }

        printf("\nVector C (Resultado de A[i] * B[%d-1-i]):\n", N);
        for (i = 0; i < N; i++)
        {
                printf("C[%d] = %d\n", i, C[i]);
        }

        return 0;
}