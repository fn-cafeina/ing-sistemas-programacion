// En una llantera se ha establecido una promoción de las llantas
// marca ponchada dicha promoción consiste en lo siguiente
// Si se compran menos de 5 llantas el precio es de 300 cada una,
// de 250 si se compran de 5 a 10 y 200 si compran más 10
// Obtener la cantidad de dinero que una persona tiene que pagar

#include <stdio.h>

int main()
{
        int cantidadLlantas, pago;

        printf("Ingrese la cantidad de llantas: ");
        scanf("%d", &cantidadLlantas);

        if (cantidadLlantas <= 10)
        {
                if (cantidadLlantas < 5)
                        pago = cantidadLlantas * 300;
                else
                        pago = cantidadLlantas * 250;
        }
        else
                pago = cantidadLlantas * 200;

        printf("El precio a pagar por las llantas es de: %d\n", pago);

        return 0;
}