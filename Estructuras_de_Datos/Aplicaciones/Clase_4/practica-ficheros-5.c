#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define CIERTO 1
#define FALSO 0

typedef struct
{
        int dia;
        int mes;
        int anno;
} fecha;

typedef struct
{
        char nombre[80];
        char calle[80];
        char ciudad[80];
        int cuen_no;
        char cuen_tipo;
        float anteriorsaldo;
        float nuevosaldo;
        float pago;
        fecha ultimopago;
} registro;

registro leerpantalla(registro cliente);
void escribirarchivo(registro cliente);

FILE *fpt;

int main()
{
        int indicador = CIERTO;
        registro cliente;

        fpt = fopen("registro.dat", "w");
        if (fpt == NULL)
        {
                printf("Error al abrir el archivo.\n");
                exit(1);
        }

        printf("SISTEMA DE CUENTA DE CLIENTES - INICIALIZACION\n\n");

        while (indicador == CIERTO)
        {
                cliente = leerpantalla(cliente);

                if (strcmp(cliente.nombre, "FIN") == 0)
                {
                        indicador = FALSO;
                }
                else
                {
                        escribirarchivo(cliente);
                }
        }

        fclose(fpt);

        printf("\n--- DATOS REGISTRADOS ---\n");
        fpt = fopen("registro.dat", "r");
        if (fpt == NULL)
        {
                printf("Error al abrir el archivo para lectura.\n");
                exit(1);
        }

        while (fread(&cliente, sizeof(registro), 1, fpt) == 1)
        {
                printf("\nNombre: %s", cliente.nombre);
                printf("Calle: %s", cliente.calle);
                printf("Ciudad: %s", cliente.ciudad);
                printf("Número de cuenta: %d\n", cliente.cuen_no);
                printf("Tipo de cuenta: %c\n", cliente.cuen_tipo);
                printf("Saldo anterior: %.2f\n", cliente.anteriorsaldo);
                printf("Nuevo saldo: %.2f\n", cliente.nuevosaldo);
                printf("Pago: %.2f\n", cliente.pago);
                printf("Último pago: %d/%d/%d\n",
                       cliente.ultimopago.dia,
                       cliente.ultimopago.mes,
                       cliente.ultimopago.anno);
                printf("------------------------------------\n");
        }

        fclose(fpt);
        return 0;
}

registro leerpantalla(registro cliente)
{
        printf("\n--- NUEVO REGISTRO ---\n");
        printf("Ingrese 'FIN' en nombre para terminar\n");

        printf("Nombre: ");
        fgets(cliente.nombre, 80, stdin);
        cliente.nombre[strcspn(cliente.nombre, "\n")] = '\0';

        if (strcmp(cliente.nombre, "FIN") == 0)
        {
                return cliente;
        }

        printf("Calle: ");
        fgets(cliente.calle, 80, stdin);
        cliente.calle[strcspn(cliente.calle, "\n")] = '\0';

        printf("Ciudad: ");
        fgets(cliente.ciudad, 80, stdin);
        cliente.ciudad[strcspn(cliente.ciudad, "\n")] = '\0';

        printf("Número de cuenta: ");
        scanf("%d", &cliente.cuen_no);
        getchar();

        printf("Tipo de cuenta (A/B/C): ");
        scanf("%c", &cliente.cuen_tipo);
        getchar();

        printf("Saldo anterior: ");
        scanf("%f", &cliente.anteriorsaldo);
        getchar();

        printf("Nuevo saldo: ");
        scanf("%f", &cliente.nuevosaldo);
        getchar();

        printf("Pago: ");
        scanf("%f", &cliente.pago);
        getchar();

        printf("Fecha último pago (dd mm aaaa): ");
        scanf("%d %d %d", &cliente.ultimopago.dia,
              &cliente.ultimopago.mes,
              &cliente.ultimopago.anno);
        getchar();

        return cliente;
}

void escribirarchivo(registro cliente)
{
        fwrite(&cliente, sizeof(registro), 1, fpt);
        printf("Registro guardado exitosamente.\n");
}