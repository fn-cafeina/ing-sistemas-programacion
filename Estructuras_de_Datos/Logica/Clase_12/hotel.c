/*
        En un hotel se tiene almacenada información sobre las habitaciones y huéspedes del mismo.
        Diseñe un programa que permita crear una lista circular clasificada para almacenar la
        información, en la cual cada elemento conste de los siguientes campos: NumHab (número de
        habitación), Nombre (nombre del cliente), FechaArr (fecha de arribo del cliente: fecha actual
        del sistema), Precio (precio de la habitación) y un puntero a un elemento del mismo tipo.

        La información de la lista estará ordenada teniendo en cuenta el número de la habitación.
        Modifique la función de inserción vista en clases para tal fin.

        El programa incluirá las siguientes operaciones:
        a) Registrar un huésped.
        b) Borrar un huésped de la lista.
        c) Buscar un huésped en la lista.
        d) Visualizar un informe de los huéspedes registrados en la lista (formato tabular).
        e) Facturación: dado el nombre de un huésped y la fecha actual, regrese cuanto debe pagar
        dicho huésped (asuma que la diferencia entre las fechas la da el número de días de
        alojamientos).
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

#define MAX_BUFF 50

struct dato
{
        int num_hab;
        char nombre_cliente[MAX_BUFF];
        char fecha_arribo[MAX_BUFF];
        float precio;
};

struct nodo
{
        struct dato info;
        struct nodo *siguiente;
        struct nodo *anterior;
};

struct nodo *lista = NULL;

void registrar_huesped();
void borrar_huesped();
void buscar_huesped();
void visualizar_informe();
void facturacion();

int esta_vacia();
void obtener_fecha_actual(char *buffer);
void limpiar_buffer_entrada();
struct nodo *buscar_por_num_hab(int num_hab);
struct nodo *buscar_por_nombre(const char *nombre);
int calcular_dias(const char *fecha_inicio_str, const char *fecha_fin_str);
void liberar_memoria();
void imprimir_menu();

int main()
{
        int opcion;

        do
        {
                imprimir_menu();

                if (scanf("%d", &opcion) != 1)
                {
                        printf("Entrada invalida. Por favor, ingrese un numero.\n");
                        limpiar_buffer_entrada();
                        opcion = -1;
                        continue;
                }
                limpiar_buffer_entrada();

                switch (opcion)
                {
                case 1:
                        registrar_huesped();
                        break;
                case 2:
                        borrar_huesped();
                        break;
                case 3:
                        buscar_huesped();
                        break;
                case 4:
                        visualizar_informe();
                        break;
                case 5:
                        facturacion();
                        break;
                case 0:
                        printf("Saliendo del programa...\n");
                        liberar_memoria();
                        break;
                default:
                        printf("Opcion no valida. Intente de nuevo.\n");
                        break;
                }
                printf("\nPresione Enter para continuar...");
                getchar();

        } while (opcion != 0);

        return 0;
}

void imprimir_menu()
{
        system("clear || cls");
        printf("--- MENU HOTEL ---\n");
        printf("Lista Circular Ordenada (Doble Enlace)\n");
        printf("--------------------------------------\n");
        printf("1. Registrar Huesped\n");
        printf("2. Borrar Huesped\n");
        printf("3. Buscar Huesped (por No. Habitación)\n");
        printf("4. Visualizar Informe de Huespedes\n");
        printf("5. Facturacion\n");
        printf("0. Salir\n");
        printf("--------------------------------------\n");
        printf("Seleccione una opcion: ");
}

int esta_vacia()
{
        return lista == NULL;
}

void limpiar_buffer_entrada()
{
        int c;
        while ((c = getchar()) != '\n' && c != EOF)
        {
        }
}

void obtener_fecha_actual(char *buffer)
{
        time_t t = time(NULL);
        struct tm *tm = localtime(&t);
        strftime(buffer, MAX_BUFF, "%d/%m/%Y", tm);
}

void registrar_huesped()
{
        struct nodo *nuevo = (struct nodo *)malloc(sizeof(struct nodo));
        if (nuevo == NULL)
        {
                printf("Error: No se pudo asignar memoria.\n");
                return;
        }

        printf("--- Registrar Nuevo Huesped ---\n");
        printf("Ingrese Numero de Habitacion: ");
        scanf("%d", &nuevo->info.num_hab);
        limpiar_buffer_entrada();

        if (buscar_por_num_hab(nuevo->info.num_hab) != NULL)
        {
                printf("Error: La habitacion %d ya esta registrada.\n", nuevo->info.num_hab);
                free(nuevo);
                return;
        }

        printf("Ingrese Nombre del Cliente: ");
        fgets(nuevo->info.nombre_cliente, MAX_BUFF, stdin);
        nuevo->info.nombre_cliente[strcspn(nuevo->info.nombre_cliente, "\n")] = 0;

        printf("Ingrese Precio por noche: ");
        scanf("%f", &nuevo->info.precio);
        limpiar_buffer_entrada();

        obtener_fecha_actual(nuevo->info.fecha_arribo);
        printf("Fecha de Arribo (automatico): %s\n", nuevo->info.fecha_arribo);

        nuevo->siguiente = NULL;
        nuevo->anterior = NULL;

        if (esta_vacia())
        {
                lista = nuevo;
                nuevo->siguiente = nuevo;
                nuevo->anterior = nuevo;
                printf("Huesped registrado. Lista inicializada.\n");
                return;
        }

        if (nuevo->info.num_hab < lista->info.num_hab)
        {
                struct nodo *ultimo = lista->anterior;

                nuevo->siguiente = lista;
                nuevo->anterior = ultimo;
                lista->anterior = nuevo;
                ultimo->siguiente = nuevo;
                lista = nuevo;
                printf("Huesped registrado al inicio de la lista.\n");
                return;
        }

        struct nodo *recorrido = lista;

        while (recorrido->siguiente != lista && recorrido->siguiente->info.num_hab < nuevo->info.num_hab)
        {
                recorrido = recorrido->siguiente;
        }

        nuevo->siguiente = recorrido->siguiente;
        nuevo->anterior = recorrido;
        recorrido->siguiente->anterior = nuevo;
        recorrido->siguiente = nuevo;

        printf("Huesped registrado en la lista.\n");
}

struct nodo *buscar_por_num_hab(int num_hab)
{
        if (esta_vacia())
        {
                return NULL;
        }

        struct nodo *recorrido = lista;
        do
        {
                if (recorrido->info.num_hab == num_hab)
                {
                        return recorrido;
                }
                recorrido = recorrido->siguiente;
        } while (recorrido != lista);

        return NULL;
}

void borrar_huesped()
{
        int num_hab_borrar;
        printf("--- Borrar Huesped ---\n");
        if (esta_vacia())
        {
                printf("La lista esta vacia. No hay nada que borrar.\n");
                return;
        }

        printf("Ingrese el Numero de Habitacion a borrar: ");
        scanf("%d", &num_hab_borrar);
        limpiar_buffer_entrada();

        struct nodo *a_borrar = buscar_por_num_hab(num_hab_borrar);

        if (a_borrar == NULL)
        {
                printf("No se encontro un huesped en la habitacion %d.\n", num_hab_borrar);
                return;
        }

        if (a_borrar->siguiente == a_borrar)
        {
                lista = NULL;
        }
        else
        {
                a_borrar->anterior->siguiente = a_borrar->siguiente;
                a_borrar->siguiente->anterior = a_borrar->anterior;

                if (a_borrar == lista)
                {
                        lista = lista->siguiente;
                }
        }

        printf("Huesped '%s' (Hab %d) borrado exitosamente.\n", a_borrar->info.nombre_cliente, a_borrar->info.num_hab);
        free(a_borrar);
}

void buscar_huesped()
{
        int num_hab_buscar;
        printf("--- Buscar Huesped ---\n");
        if (esta_vacia())
        {
                printf("La lista esta vacia.\n");
                return;
        }

        printf("Ingrese el Numero de Habitacion a buscar: ");
        scanf("%d", &num_hab_buscar);
        limpiar_buffer_entrada();

        struct nodo *encontrado = buscar_por_num_hab(num_hab_buscar);

        if (encontrado != NULL)
        {
                printf("Huesped Encontrado:\n");
                printf("---------------------------------\n");
                printf("Habitacion: %d\n", encontrado->info.num_hab);
                printf("Nombre:     %s\n", encontrado->info.nombre_cliente);
                printf("Arribo:     %s\n", encontrado->info.fecha_arribo);
                printf("Precio:     $%.2f\n", encontrado->info.precio);
                printf("---------------------------------\n");
        }
        else
        {
                printf("No se encontro un huesped en la habitacion %d.\n", num_hab_buscar);
        }
}

void visualizar_informe()
{
        printf("--- Informe de Huespedes Registrados ---\n");
        if (esta_vacia())
        {
                printf("No hay huespedes registrados en el hotel.\n");
                return;
        }

        printf("======================================================================\n");
        printf("| %-5s | %-25s | %-15s | %-10s |\n", "Hab.", "Nombre Cliente", "Fecha Arribo", "Precio");
        printf("======================================================================\n");

        struct nodo *recorrido = lista;
        do
        {
                printf("| %-5d | %-25s | %-15s | $%-9.2f |\n",
                       recorrido->info.num_hab,
                       recorrido->info.nombre_cliente,
                       recorrido->info.fecha_arribo,
                       recorrido->info.precio);
                recorrido = recorrido->siguiente;
        } while (recorrido != lista);

        printf("======================================================================\n");
}

struct nodo *buscar_por_nombre(const char *nombre)
{
        if (esta_vacia())
        {
                return NULL;
        }
        struct nodo *recorrido = lista;
        do
        {
                if (strcmp(recorrido->info.nombre_cliente, nombre) == 0)
                {
                        return recorrido;
                }
                recorrido = recorrido->siguiente;
        } while (recorrido != lista);

        return NULL;
}

int calcular_dias(const char *fecha_inicio_str, const char *fecha_fin_str)
{
        struct tm tm_inicio = {0};
        struct tm tm_fin = {0};
        time_t t_inicio, t_fin;
        double segundos;

        int dia_i, mes_i, anio_i;
        int dia_f, mes_f, anio_f;

        sscanf(fecha_inicio_str, "%d/%d/%d", &dia_i, &mes_i, &anio_i);
        sscanf(fecha_fin_str, "%d/%d/%d", &dia_f, &mes_f, &anio_f);

        tm_inicio.tm_mday = dia_i;
        tm_inicio.tm_mon = mes_i - 1;
        tm_inicio.tm_year = anio_i - 1900;

        tm_fin.tm_mday = dia_f;
        tm_fin.tm_mon = mes_f - 1;
        tm_fin.tm_year = anio_f - 1900;

        t_inicio = mktime(&tm_inicio);
        t_fin = mktime(&tm_fin);

        if (t_inicio == -1 || t_fin == -1)
        {
                printf("Error al procesar las fechas.\n");
                return 0;
        }

        segundos = difftime(t_fin, t_inicio);

        int dias = (int)(segundos / (60 * 60 * 24));

        if (dias <= 0)
        {
                return 1;
        }

        return dias;
}

void facturacion()
{
        char nombre_buscar[MAX_BUFF];
        char fecha_salida[MAX_BUFF];
        printf("--- Facturacion ---\n");
        if (esta_vacia())
        {
                printf("No hay huespedes para facturar.\n");
                return;
        }

        printf("Ingrese el nombre exacto del huesped: ");
        fgets(nombre_buscar, MAX_BUFF, stdin);
        nombre_buscar[strcspn(nombre_buscar, "\n")] = 0;

        struct nodo *huesped = buscar_por_nombre(nombre_buscar);

        if (huesped == NULL)
        {
                printf("No se encontro al huesped '%s'.\n", nombre_buscar);
                return;
        }

        printf("Huesped encontrado: %s (Hab %d)\n", huesped->info.nombre_cliente, huesped->info.num_hab);
        printf("Fecha de Arribo: %s\n", huesped->info.fecha_arribo);

        printf("Ingrese la fecha de Salida (DD/MM/AAAA): ");
        fgets(fecha_salida, MAX_BUFF, stdin);
        fecha_salida[strcspn(fecha_salida, "\n")] = 0;

        int dias_alojado = calcular_dias(huesped->info.fecha_arribo, fecha_salida);

        if (dias_alojado > 0)
        {
                float total_pagar = dias_alojado * huesped->info.precio;
                printf("\n--- Recibo ---\n");
                printf("Cliente:   %s\n", huesped->info.nombre_cliente);
                printf("Habitacion: %d\n", huesped->info.num_hab);
                printf("Estadia:    %d dias\n", dias_alojado);
                printf("Precio/noche: $%.2f\n", huesped->info.precio);
                printf("--------------------\n");
                printf("TOTAL A PAGAR: $%.2f\n", total_pagar);
                printf("--------------------\n");
        }
        else
        {
                printf("Las fechas ingresadas no son validas para la facturacion.\n");
        }
}

void liberar_memoria()
{
        if (esta_vacia())
        {
                return;
        }

        struct nodo *recorrido = lista;
        struct nodo *a_borrar;

        lista->anterior->siguiente = NULL;

        while (recorrido != NULL)
        {
                a_borrar = recorrido;
                recorrido = recorrido->siguiente;
                free(a_borrar);
        }

        lista = NULL;
        printf("Memoria liberada.\n");
}