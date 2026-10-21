#include <stdio.h>

float grados(float);

int main()
{
        float gradosC;

        printf("Ingrese la cantidad de centigrados para convertirlos a fahrenheit: ");
        scanf("%f", &gradosC);

        printf("%.2f centigrados convertidos a fahrenheit es: %.2f\n", gradosC, grados(gradosC));

        return 0;
}

float grados(float c)
{
        return (c * 9 / 5) + 32;
}