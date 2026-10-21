#include "persistencia.h"
#include "logica.h"
#include "tipos.h"
#include <stdio.h>
#include <stdlib.h>
#include <sys/stat.h> // <-- Parche: Movido aquí para que aplique a Windows y Linux

// Includes para creación de directorios (multiplataforma)
#ifdef _WIN32
#include <direct.h>
#define MKDIR(path) _mkdir(path)
#else
#include <sys/types.h>
#define MKDIR(path) mkdir(path, 0755) // 0755 = rwxr-xr-x
#endif

/**
 * @brief Verifica si el directorio de datos (DATA_DIR) existe.
 * Si no existe, intenta crearlo.
 * Es 'static' porque solo se usa dentro de este módulo.
 */
static void asegurar_directorio_de_datos(void)
{
        struct stat st = {0};

        // stat(DATA_DIR, &st) devuelve -1 si el directorio no existe
        if (stat(DATA_DIR, &st) == -1)
        {
                printf("Advertencia: Directorio '%s' no encontrado. Creandolo...\n", DATA_DIR);
                if (MKDIR(DATA_DIR) != 0)
                {
                        perror("Error fatal al crear directorio de datos");
                        exit(1);
                }
        }
}

void cargar_datos(void)
{
        FILE *f;
        asegurar_directorio_de_datos();

        if ((f = fopen(FILE_TECNICOS, "rb")) != NULL)
        {
                fread(&g_num_tecnicos, sizeof(int), 1, f);
                fread(&g_sig_id_tecnico, sizeof(int), 1, f);

                g_tecnicos = (tecnico_t *)malloc(g_num_tecnicos * sizeof(tecnico_t));
                if (g_tecnicos == NULL)
                {
                        perror("Error al asignar memoria para tecnicos");
                        exit(1);
                }
                fread(g_tecnicos, sizeof(tecnico_t), g_num_tecnicos, f);
                fclose(f);
        }
        else
        {
                printf("Info: No se encontro '%s'. Empezando de cero.\n", FILE_TECNICOS);
        }

        if ((f = fopen(FILE_SOLICITUDES, "rb")) != NULL)
        {
                fread(&g_num_solicitudes, sizeof(int), 1, f);
                fread(&g_sig_id_solicitud, sizeof(int), 1, f);

                g_solicitudes = (solicitud_t *)malloc(g_num_solicitudes * sizeof(solicitud_t));
                if (g_solicitudes == NULL)
                {
                        perror("Error al asignar memoria para solicitudes");
                        exit(1);
                }
                fread(g_solicitudes, sizeof(solicitud_t), g_num_solicitudes, f);
                fclose(f);
        }
        else
        {
                printf("Info: No se encontro '%s'. Empezando de cero.\n", FILE_SOLICITUDES);
        }
}

void guardar_datos(void)
{
        FILE *f;
        asegurar_directorio_de_datos();

        if ((f = fopen(FILE_TECNICOS, "wb")) == NULL)
        {
                perror("Error al abrir archivo para guardar tecnicos");
                return;
        }
        fwrite(&g_num_tecnicos, sizeof(int), 1, f);
        fwrite(&g_sig_id_tecnico, sizeof(int), 1, f);
        fwrite(g_tecnicos, sizeof(tecnico_t), g_num_tecnicos, f);
        fclose(f);

        if ((f = fopen(FILE_SOLICITUDES, "wb")) == NULL)
        {
                perror("Error al abrir archivo para guardar solicitudes");
                return;
        }
        fwrite(&g_num_solicitudes, sizeof(int), 1, f);
        fwrite(&g_sig_id_solicitud, sizeof(int), 1, f);
        fwrite(g_solicitudes, sizeof(solicitud_t), g_num_solicitudes, f);
        fclose(f);
}