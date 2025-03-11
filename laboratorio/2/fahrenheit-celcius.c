#include <stdio.h>

int main()
{
        float gFahrenheit, gCelcius;

        printf("Ingrese los grados Fahrenheit: ");
        scanf("%f", &gFahrenheit);

        gCelcius = (gFahrenheit - 32) * 5 / 9;

        printf("La conversion de Fahrenheit a Celcius es: %.2f \n", gCelcius);

        return 0;
}