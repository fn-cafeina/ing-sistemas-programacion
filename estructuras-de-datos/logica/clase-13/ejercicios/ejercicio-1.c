/*
        Una juguetería tiene mucho éxito en dos de sus productos: payasos y muñecas.
        Suele hacer venta por correo y la empresa de logística les cobra por peso de cada paquete,
        así que deben calcular el peso de los payasos y muñecas que saldrán en cada paquete a demanda.
        Cada payaso pesa 112 g y cada muñeca 75 g.
        Escribir un programa que lea el número de payasos y muñecas vendidos en el último pedido
        y calcule el peso total del paquete que será enviado.
*/

#include <stdio.h>

int main()
{
        int payasos, munecas;
        int peso_total;

        printf("Ingrese el número de payasos vendidos: ");
        scanf("%d", &payasos);

        printf("Ingrese el número de muñecas vendidas: ");
        scanf("%d", &munecas);

        // Cada payaso = 112 g, cada muñeca = 75 g
        peso_total = (payasos * 112) + (munecas * 75);

        printf("El peso total del paquete es %d gramos.\n", peso_total);

        return 0;
}
