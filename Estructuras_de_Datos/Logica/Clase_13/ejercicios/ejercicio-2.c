/*
        Imagina que acabas de abrir una nueva cuenta de ahorros que te ofrece el 4% de interés al año.
        Estos ahorros debido a intereses, que no se cobran hasta finales de año,
        se te añaden al balance final de tu cuenta de ahorros.
        Escribir un programa que comience leyendo la cantidad de dinero depositada en la cuenta de ahorros,
        introducida por el usuario.
        Después el programa debe calcular y mostrar por pantalla la cantidad de ahorros tras el primer,
        segundo y tercer años. Redondear cada cantidad a dos decimales.
*/

#include <stdio.h>

int main()
{
        double deposito, saldo1, saldo2, saldo3;
        double interes = 0.04;

        printf("Ingrese la cantidad depositada en la cuenta: ");
        scanf("%lf", &deposito);

        saldo1 = deposito * (1 + interes);
        saldo2 = saldo1 * (1 + interes);
        saldo3 = saldo2 * (1 + interes);

        printf("Saldo tras el primer año: %.2f\n", saldo1);
        printf("Saldo tras el segundo año: %.2f\n", saldo2);
        printf("Saldo tras el tercer año: %.2f\n", saldo3);

        return 0;
}
