#include <stdio.h>

int main()
{
        int n1, n2, n3;
        float media;

        printf("Ingrese el primero numero: ");
        scanf("%d", &n1);

        printf("Ingrese el segundo numero: ");
        scanf("%d", &n2);

        printf("Ingrese el tercer numero: ");
        scanf("%d", &n3);

        media = (n1 + n2 + n3) / 3;

        printf("La media de los 3 numeros es: %.2f \n", media);

        return 0;
}