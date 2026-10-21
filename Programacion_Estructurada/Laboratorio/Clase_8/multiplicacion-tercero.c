// Que tome tres números y diga si la multiplicación de los dos primeros es igual al tercero.

#include <stdio.h>
#include <stdlib.h>

int main()
{
        if (system("cls"))
                system("clear");

        int n1, n2, n3;

        printf("Ingrese 3 numeros:\n");
        scanf("%d%d%d", &n1, &n2, &n3);

        if (n1 * n2 == n3)
                printf("La multiplicacion de los 2 primeros es igual al tercero.\n");
        else
                printf("La multiplicacion de los 2 primeros no es igual al tercero.\n");

        return 0;
}