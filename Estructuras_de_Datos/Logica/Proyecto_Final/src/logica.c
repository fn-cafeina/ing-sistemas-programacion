#include "logica.h"
#include "utils.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Definición de las variables globales de estado (declaradas en logica.h)
tecnico_t *g_tecnicos = NULL;
int g_num_tecnicos = 0;
int g_sig_id_tecnico = 1;

solicitud_t *g_solicitudes = NULL;
int g_num_solicitudes = 0;
int g_sig_id_solicitud = 1;

// --- Funciones Auxiliares (static) ---

static tecnico_t *buscar_tecnico(int id)
{
        for (int i = 0; i < g_num_tecnicos; i++)
        {
                if (g_tecnicos[i].id_tecnico == id)
                {
                        return &g_tecnicos[i];
                }
        }
        return NULL;
}

static solicitud_t *buscar_solicitud(int id)
{
        for (int i = 0; i < g_num_solicitudes; i++)
        {
                if (g_solicitudes[i].id_solicitud == id)
                {
                        return &g_solicitudes[i];
                }
        }
        return NULL;
}

static void listar_tecnicos(void)
{
        printf("ID  | Nombre                         | Especialidad\n");
        printf("----+--------------------------------+-----------------\n");
        int activos = 0;
        for (int i = 0; i < g_num_tecnicos; i++)
        {
                if (g_tecnicos[i].activo)
                {
                        printf("%-3d | %-30s | %s\n",
                               g_tecnicos[i].id_tecnico,
                               g_tecnicos[i].nombre,
                               g_tecnicos[i].especialidad);
                        activos++;
                }
        }
        if (activos == 0)
        {
                printf("No hay tecnicos activos registrados.\n");
        }
}

static void listar_solicitudes(int estado_filtro)
{
        const char *estados[] = {"N/A", "Pendiente", "En Proceso", "Finalizada"};
        const char *prioridades[] = {"N/A", "Baja", "Media", "Alta"};

        printf("ID  | Estado       | Prioridad | Ubicacion          | Descripcion\n");
        printf("----+--------------+-----------+--------------------+------------------\n");

        int encontrados = 0;
        for (int i = 0; i < g_num_solicitudes; i++)
        {
                if (estado_filtro == 0 || g_solicitudes[i].estado == estado_filtro)
                {
                        printf("%-3d | %-12s | %-9s | %-18s | %.30s...\n",
                               g_solicitudes[i].id_solicitud,
                               estados[g_solicitudes[i].estado],
                               prioridades[g_solicitudes[i].prioridad],
                               g_solicitudes[i].ubicacion,
                               g_solicitudes[i].descripcion);
                        encontrados++;
                }
        }

        if (encontrados == 0)
        {
                printf(estado_filtro == 0 ? "No hay solicitudes registradas.\n"
                                          : "No hay solicitudes con ese estado.\n");
        }
}

// --- Implementación de Funciones Públicas ---

void inicializar_datos(void)
{
        g_tecnicos = NULL;
        g_num_tecnicos = 0;
        g_sig_id_tecnico = 1;
        g_solicitudes = NULL;
        g_num_solicitudes = 0;
        g_sig_id_solicitud = 1;
}

void liberar_memoria(void)
{
        free(g_tecnicos);
        free(g_solicitudes);
        g_tecnicos = NULL;
        g_solicitudes = NULL;
}

void registrar_solicitud(void)
{
        limpiar_pantalla();
        printf("--- Registrar Nueva Solicitud ---\n");

        g_num_solicitudes++;
        solicitud_t *temp = (solicitud_t *)realloc(g_solicitudes, g_num_solicitudes * sizeof(solicitud_t));
        if (temp == NULL)
        {
                perror("Error al reasignar memoria para solicitud");
                g_num_solicitudes--;
                return;
        }
        g_solicitudes = temp;

        solicitud_t *nueva = &g_solicitudes[g_num_solicitudes - 1];
        nueva->id_solicitud = g_sig_id_solicitud++;

        printf("Ubicacion (Ej: Oficina 101): ");
        get_string(nueva->ubicacion, MAX_UBICACION);

        printf("Descripcion del problema: ");
        get_string(nueva->descripcion, MAX_DESC);

        printf("Prioridad (1=Baja, 2=Media, 3=Alta): ");
        nueva->prioridad = leer_opcion(1, 3);
        nueva->estado = 1;
        nueva->id_tecnico_asignado = 0;

        printf("\nSolicitud (Folio %d) registrada como PENDIENTE.\n", nueva->id_solicitud);
}

void registrar_tecnico(void)
{
        limpiar_pantalla();
        printf("--- Registrar Nuevo Tecnico ---\n");

        g_num_tecnicos++;
        tecnico_t *temp = (tecnico_t *)realloc(g_tecnicos, g_num_tecnicos * sizeof(tecnico_t));
        if (temp == NULL)
        {
                perror("Error al reasignar memoria para tecnico");
                g_num_tecnicos--;
                return;
        }
        g_tecnicos = temp;

        tecnico_t *nuevo = &g_tecnicos[g_num_tecnicos - 1];
        nuevo->id_tecnico = g_sig_id_tecnico++;

        printf("Nombre completo del tecnico: ");
        get_string(nuevo->nombre, MAX_NOMBRE);

        printf("Especialidad (Ej: Electricidad, Plomeria): ");
        get_string(nuevo->especialidad, MAX_NOMBRE);
        nuevo->activo = 1;

        printf("\nTecnico '%s' (ID %d) registrado.\n", nuevo->nombre, nuevo->id_tecnico);
}

void asignar_tarea(void)
{
        limpiar_pantalla();
        printf("--- Asignar Tarea a Tecnico ---\n");

        listar_solicitudes(1); // 1 = Pendiente

        printf("\nIngrese el ID de la Solicitud (0 para cancelar): ");
        int id_sol = leer_opcion(0, g_sig_id_solicitud);
        if (id_sol == 0)
                return;

        solicitud_t *sol = buscar_solicitud(id_sol);
        if (sol == NULL || sol->estado != 1)
        {
                printf("Error: ID de solicitud no valido o no esta pendiente.\n");
                return;
        }

        printf("\nTecnicos Activos:\n");
        listar_tecnicos();

        printf("\nIngrese el ID del Tecnico a asignar (0 para cancelar): ");
        int id_tec = leer_opcion(0, g_sig_id_tecnico);
        if (id_tec == 0)
                return;

        tecnico_t *tec = buscar_tecnico(id_tec);
        if (tec == NULL || tec->activo == 0)
        {
                printf("Error: ID de tecnico no valido o no esta activo.\n");
                return;
        }

        sol->id_tecnico_asignado = id_tec;
        sol->estado = 2; // 2 = En Proceso

        printf("\nAsignacion exitosa: Solicitud %d -> Tecnico %s.\n", sol->id_solicitud, tec->nombre);
        printf("Estado de la solicitud: EN PROCESO.\n");
}

void cambiar_estado_solicitud(void)
{
        limpiar_pantalla();
        printf("--- Actualizar Estado de Solicitud ---\n");

        listar_solicitudes(0); // 0 = Todas

        printf("\nIngrese el ID de la Solicitud (0 para cancelar): ");
        int id_sol = leer_opcion(0, g_sig_id_solicitud);
        if (id_sol == 0)
                return;

        solicitud_t *sol = buscar_solicitud(id_sol);
        if (sol == NULL)
        {
                printf("Error: ID de solicitud no valido.\n");
                return;
        }

        const char *estados[] = {"N/A", "Pendiente", "En Proceso", "Finalizada"};
        printf("Estado actual de Sol. %d: %s\n", sol->id_solicitud, estados[sol->estado]);

        printf("\nSeleccione el nuevo estado:\n");
        printf("1. Pendiente\n");
        printf("2. En Proceso\n");
        printf("3. Finalizada\n");
        int nuevo_estado = leer_opcion(1, 3);

        sol->estado = nuevo_estado;

        // Lógica de negocio: Si se finaliza o se regresa a pendiente,
        // se des-asigna automáticamente al técnico.
        if (nuevo_estado == 1 || nuevo_estado == 3)
        {
                if (sol->id_tecnico_asignado != 0)
                {
                        printf("Nota: La solicitud se ha desvinculado del tecnico.\n");
                        sol->id_tecnico_asignado = 0;
                }
        }

        printf("\nEstado de la Solicitud %d actualizado a: %s.\n", sol->id_solicitud, estados[sol->estado]);
}

void mostrar_reportes(void)
{
        int opcion;
        const char *estados[] = {"N/A", "Pendiente", "En Proceso", "Finalizada"};

        do
        {
                limpiar_pantalla();
                printf("--- Menu de Reportes ---\n");
                printf("1. Reporte por Tecnico\n");
                printf("2. Reporte por Area (Ubicacion)\n");
                printf("3. Reporte por Estado\n");
                printf("0. Volver al Menu Principal\n");

                opcion = leer_opcion(0, 3);

                limpiar_pantalla();
                switch (opcion)
                {
                case 1:
                        printf("--- Reporte por Tecnico ---\n");
                        listar_tecnicos();
                        printf("Ingrese el ID del Tecnico: ");
                        int id_tec = leer_opcion(1, g_sig_id_tecnico);
                        tecnico_t *tec = buscar_tecnico(id_tec);
                        if (tec)
                        {
                                printf("Mostrando solicitudes para: %s\n", tec->nombre);
                                for (int i = 0; i < g_num_solicitudes; i++)
                                {
                                        if (g_solicitudes[i].id_tecnico_asignado == id_tec)
                                        {
                                                printf("  ID: %d | Estado: %s | Ubicacion: %s\n",
                                                       g_solicitudes[i].id_solicitud,
                                                       estados[g_solicitudes[i].estado],
                                                       g_solicitudes[i].ubicacion);
                                        }
                                }
                        }
                        else
                        {
                                printf("Tecnico no encontrado.\n");
                        }
                        break;

                case 2:
                        printf("--- Reporte por Area (Ubicacion) ---\n");
                        char ubicacion[MAX_UBICACION];
                        printf("Ingrese la ubicacion a buscar (parcial): ");
                        get_string(ubicacion, MAX_UBICACION);

                        printf("Mostrando solicitudes para la ubicacion: %s\n", ubicacion);
                        int encontrados = 0;
                        for (int i = 0; i < g_num_solicitudes; i++)
                        {
                                if (strstr(g_solicitudes[i].ubicacion, ubicacion) != NULL)
                                {
                                        printf("  ID: %d | Estado: %s | Desc: %s\n",
                                               g_solicitudes[i].id_solicitud,
                                               estados[g_solicitudes[i].estado],
                                               g_solicitudes[i].descripcion);
                                        encontrados++;
                                }
                        }
                        if (encontrados == 0)
                        {
                                printf("No se encontraron solicitudes para esa ubicacion.\n");
                        }
                        break;

                case 3:
                        printf("--- Reporte por Estado ---\n");
                        printf("1. Pendiente\n2. En Proceso\n3. Finalizada\n");
                        int estado_filtro = leer_opcion(1, 3);
                        printf("Mostrando solicitudes: %s\n", estados[estado_filtro]);
                        listar_solicitudes(estado_filtro);
                        break;
                }

                if (opcion != 0)
                {
                        pausar();
                }

        } while (opcion != 0);
}