//  En una fábrica de computadoras se plantea ofrecer a los clientes
//  un descuento que dependerá del número de computadoras que compre.
//  Si las computadoras son menos de 5 se les dará 10% de descuento sobre el
//  total de compra si el número de computadoras es mayor o igual al cinco pero
//  menos de 10 se le otorga un 20% y si son 10 o más se le dará un 40% de descuento
//  el precio de computadora es de 11,000.

#include <stdio.h>

int main()
{
        int cantidadComputadoras;

        printf("Ingrese la cantidad de computadoras: ");
        scanf("%d", &cantidadComputadoras);

        float precioComputadora = 11000;
        float pago, pagoConDescuento;

        pago = cantidadComputadoras * precioComputadora;

        if (cantidadComputadoras < 10)
        {
                if (cantidadComputadoras < 5)
                        pagoConDescuento = pago - (pago * 0.1);
                else
                        pagoConDescuento = pago - (pago * 0.2);
        }
        else
                pagoConDescuento = pago - (pago * 0.4);

        printf("El pago total sera de: %.2f\n", pagoConDescuento);

        return 0;
}