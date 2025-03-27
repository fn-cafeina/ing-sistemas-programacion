// Realice un programa en C del siguiente enunciado: El valor del descuento que se
// le aplica a cada estudiante de la UCC depende de la ciudad de procedencia.
// Tome en cuenta la siguiente tabla, que permita calcular el descuento que se realiza
// a un estudiante e imprimir cuál es la cantidad de dinero que deja de percibir el
// administrador de la Universidad en concepto de descuento.
//
// Clave Ciudad     Descuento
// 1     León       2%
// 2     Chinandega 10%
// 3     Managua    15%
// 4     Estelí     18%
// 5     Jinotega   20%
//
// El valor de la mensualidad es de: C$ 250,67.

#include <stdio.h>
#include <stdlib.h>

enum ciudad
{
        leon = 1,
        chinandega,
        managua,
        esteli,
        jinotega
};

int main()
{
        enum ciudad clave;
        float mensualidad = 250.67, descuento;

        printf("Clave Ciudad     Descuento\n");
        printf("1     León       2%c\n", '%');
        printf("2     Chinandega 10%c\n", '%');
        printf("3     Managua    15%c\n", '%');
        printf("4     Estelí     18%c\n", '%');
        printf("5     Jinotega   20%c\n\n", '%');

        printf("Ingrese la clave de su ciudad: ");
        scanf("%d", &clave);

        switch (clave)
        {
        case leon:
                descuento = mensualidad * 0.02;
                break;
        case chinandega:
                descuento = mensualidad * 0.10;
                break;
        case managua:
                descuento = mensualidad * 0.15;
                break;
        case esteli:
                descuento = mensualidad * 0.18;
                break;
        case jinotega:
                descuento = mensualidad * 0.20;
                break;
        default:
                printf("\nCiudad incorrecta.\n");
                exit(0);
                break;
        }

        printf("\nEl dinero que deja de percibir el administrador: %.2fC$\n", descuento);

        return 0;
}