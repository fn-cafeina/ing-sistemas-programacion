#include <stdio.h>

int main()
{
        float des, precio, total;

        printf("Ingrese la cantidad que gasto: ");
        scanf("%f", &precio);

        des = precio * 0.3;

        total = precio - des;

        printf("El total a pagar: %f \n", total);

        return 0;
}