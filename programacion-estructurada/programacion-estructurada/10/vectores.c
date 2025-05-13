// Escriba un programa que lee dos vectores A y B de 20 elementos
// cada uno y multiplica el primer elemento de A por el último de
// B y así sucesivamente hasta llegar al último elemento de A por
// el primero elemento de B. El resultado de la multiplicación se
// almacena en un vector C.

#include <stdio.h>

#define TAMANYIO_ARRAY 20

int main()
{
        int a[TAMANYIO_ARRAY], b[TAMANYIO_ARRAY], c [[maybe_unused]][TAMANYIO_ARRAY];

        for (int i = 0; i < TAMANYIO_ARRAY; i++)
        {
                printf("Vector A, posición %d: ", i);
                scanf("%d", &a[i]);
                printf("Vector B, posición %d: ", i);
                scanf("%d", &b[i]);
        }

        int backW = TAMANYIO_ARRAY - 1;

        for (int i = 0; i < TAMANYIO_ARRAY; i++)
        {
                c[i] = a[i] * b[backW];
                backW--;
        }

        printf("\n");

        backW = TAMANYIO_ARRAY - 1;

        for (int i = 0; i < TAMANYIO_ARRAY; i++)
        {
                printf("a[%d](%d) * b[%d](%d) = %d\n", i, a[i], backW, b[backW], c[i]);
                backW--;
        }

        return 0;
}