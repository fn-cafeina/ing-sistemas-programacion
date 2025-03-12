#include <stdio.h>

int main()
{
        float dolar, euro = 0.95, resultado;

        printf("Ingrese los dolares a convertir: ");

        scanf("%f", &dolar);

        resultado = dolar * euro;

        printf("La conversión es: %f \n", resultado);

        return 0;
}