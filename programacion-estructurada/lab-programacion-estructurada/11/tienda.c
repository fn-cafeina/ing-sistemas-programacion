// Suponga que tiene usted una tienda y desea registrar las ventas en su computadora.
// Diseñe un algoritmo que lea por cada cliente, el monto total de su compra.
// Al final del día que escriba ia cantidad total de ventas y el numero de clientes atendidos.

#include <stdio.h>

int main()
{
        float montoCompra;
        float totalVentas = 0;
        int cantidadClientes = 0;
        char respuesta;

        printf("Bienvenido al sistema de registro de ventas\n");

        do
        {
                printf("\nIngrese el monto total de la compra del cliente: ");
                scanf("%f", &montoCompra);

                totalVentas += montoCompra;
                cantidadClientes++;

                printf("\n¿Atendió a otro cliente hoy? (s, n): ");

                scanf(" %c", &respuesta);
        } while (respuesta == 's' || respuesta == 'S');

        printf("Cantidad total de ventas: %.2f\n", totalVentas);
        printf("Número de clientes atendidos: %d\n", cantidadClientes);

        return 0;
}