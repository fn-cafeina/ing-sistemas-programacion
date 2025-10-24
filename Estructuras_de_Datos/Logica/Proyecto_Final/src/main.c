#include <stdio.h>
#include "tipos.h"
#include "utils.h"
#include "persistencia.h"
#include "logica.h"

int main(void)
{

        inicializar_datos();
        cargar_datos();

        int opcion;
        do
        {
                limpiar_pantalla();
                printf("==================================================\n");
                printf("  Sistema de Gestion de Mantenimiento (Proyecto 2)\n");
                printf("==================================================\n");
                printf("1. Registrar Nueva Solicitud\n");
                printf("2. Registrar Nuevo Tecnico\n");
                printf("3. Asignar Tarea a Tecnico\n");
                printf("4. Actualizar Estado de Solicitud\n");
                printf("5. Ver Reportes\n");
                printf("0. Guardar y Salir\n");
                printf("--------------------------------------------------\n");

                opcion = leer_opcion(0, 5);

                switch (opcion)
                {
                case 1:
                        registrar_solicitud();
                        break;
                case 2:
                        registrar_tecnico();
                        break;
                case 3:
                        asignar_tarea();
                        break;
                case 4:
                        cambiar_estado_solicitud();
                        break;
                case 5:
                        mostrar_reportes();
                        break;
                case 0:
                        break;
                }

                if (opcion != 0)
                {
                        pausar();
                }

        } while (opcion != 0);

        printf("Guardando datos en '%s'...\n", DATA_DIR);
        guardar_datos();

        liberar_memoria();
        printf("Datos guardados. Adios.\n");

        return 0;
}