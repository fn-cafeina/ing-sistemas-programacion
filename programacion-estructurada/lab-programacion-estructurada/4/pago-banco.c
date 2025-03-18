// Suponga que un individuo desea invertir su capital en un banco y deses saber
// cuánto dinero ganará después de un mes si el banco paga a razón de 2% mensual.

#include <stdio.h>

int main()
{
        float capitalInvertido, pago;

        printf("Ingrese el capital invertido: ");
        scanf("%f", &capitalInvertido);

        pago = capitalInvertido + (capitalInvertido * 0.02);

        printf("El pago es de: %.2f \n", pago);

        return 0;
}