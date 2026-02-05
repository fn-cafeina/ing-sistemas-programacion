// Realizar un programa de Facturación de Clientes en C.
// Los clientes tienen un nombre, número de unidades solicitadas,
// precio de cada unidad y el estado en que se encuentra:
// moroso, atrasado, solvente. Dicho programa deberá mostrar los siguientes listados:
//      • Clientes en estado moroso, solvente, atrasado.
//      • Clientes en estado atrasado con facturas mayores de una determinada cantidad.

#include <stdio.h>

struct Cliente
{
        char nombre[50];
        int estado;
        int nUnidadesSolicitadas;
        float precioUnidad;
        float factura;
};

void mostrarInfoCliente(struct Cliente *cliente);
void listarClientesPorEstado(struct Cliente clientes[], int cantidadClientes, int estadoBuscado);
void listarAtrasadosConFacturaMayor(struct Cliente clientes[], int cantidadClientes, float cantidadEspecifica);

int main()
{
        int cantidadClientes;

        printf("Ingrese la cantidad de clientes: ");
        scanf("%d", &cantidadClientes);

        struct Cliente clientes[cantidadClientes];

        float cantidadEspecifica;
        printf("Ingrese una cantidad especifica para clientes atrasados con factura mayor a: ");
        scanf("%f", &cantidadEspecifica);

        for (int i = 0; i < cantidadClientes; i++)
        {
                printf("\n--- Registro del cliente #%d ---\n", i + 1);

                printf("Nombre: ");
                scanf("%s", clientes[i].nombre);

                printf("Cantidad de unidades solicitadas: ");
                scanf("%d", &clientes[i].nUnidadesSolicitadas);

                printf("Precio de las unidades: ");
                scanf("%f", &clientes[i].precioUnidad);

                printf("Estado en el que se encuentra:\n0 - Moroso\n1 - Atrasado\n2 - Solvente\nR = ");
                scanf("%d", &clientes[i].estado);

                clientes[i].factura = clientes[i].precioUnidad * clientes[i].nUnidadesSolicitadas;
        }

        printf("\n\n--- Listado de clientes morosos ---\n");
        listarClientesPorEstado(clientes, cantidadClientes, 0);

        printf("\n\n--- Listado de clientes atrasados ---\n");
        listarClientesPorEstado(clientes, cantidadClientes, 1);

        printf("\n\n--- Listado de clientes solventes ---\n");
        listarClientesPorEstado(clientes, cantidadClientes, 2);

        printf("\n\n--- Listado de clientes atrasados con facturas mayores a %.2f ---\n", cantidadEspecifica);
        listarAtrasadosConFacturaMayor(clientes, cantidadClientes, cantidadEspecifica);

        return 0;
}

void mostrarInfoCliente(struct Cliente *cliente)
{
        printf("Nombre: %s\n", cliente->nombre);
        printf("Unidades Solicitadas: %d\n", cliente->nUnidadesSolicitadas);
        printf("Precio por Unidad: %.2f\n", cliente->precioUnidad);
        printf("Total Factura: %.2f\n", cliente->factura);
        printf("Estado: ");

        switch (cliente->estado)
        {
        case 0:
                printf("Moroso\n");
                break;
        case 1:
                printf("Atrasado\n");
                break;
        case 2:
                printf("Solvente\n");
                break;
        default:
                printf("Desconocido (Estado Invalido)\n");
                break;
        }
        printf("--------------------\n");
}

void listarClientesPorEstado(struct Cliente clientes[], int cantidadClientes, int estadoBuscado)
{
        int clientesEncontrados = 0;

        for (int i = 0; i < cantidadClientes; i++)
        {
                if (clientes[i].estado == estadoBuscado)
                {
                        mostrarInfoCliente(&clientes[i]);
                        clientesEncontrados++;
                }
        }

        if (clientesEncontrados == 0)
                printf("No se encontraron clientes con este estado.\n");
}

void listarAtrasadosConFacturaMayor(struct Cliente clientes[], int cantidadClientes, float cantidadEspecifica)
{
        int clientesEncontrados = 0;
        for (int i = 0; i < cantidadClientes; i++)
        {
                if (clientes[i].estado == 1 && clientes[i].factura > cantidadEspecifica)
                {
                        mostrarInfoCliente(&clientes[i]);
                        clientesEncontrados++;
                }
        }

        if (clientesEncontrados == 0)
                printf("No se encontraron clientes atrasados con facturas mayores a %.2f.\n", cantidadEspecifica);
}