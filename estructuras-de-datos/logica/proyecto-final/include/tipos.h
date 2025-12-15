/**
 * @file tipos.h
 * @brief Definición de tipos de datos, estructuras y constantes globales.
 */
#ifndef TIPOS_H
#define TIPOS_H

#define MAX_DESC 256
#define MAX_NOMBRE 100
#define MAX_UBICACION 100

#define DATA_DIR "data/"
#define FILE_TECNICOS DATA_DIR "tecnicos.dat"
#define FILE_SOLICITUDES DATA_DIR "solicitudes.dat"

/**
 * @struct tecnico
 * @brief Almacena los datos de un técnico de mantenimiento.
 */
typedef struct tecnico
{
        int id_tecnico;
        char nombre[MAX_NOMBRE];
        char especialidad[MAX_NOMBRE];
        int activo; ///< 1 si está activo, 0 si está inactivo.
} tecnico_t;

/**
 * @struct solicitud
 * @brief Almacena los datos de una solicitud de mantenimiento.
 */
typedef struct solicitud
{
        int id_solicitud;
        char ubicacion[MAX_UBICACION];
        char descripcion[MAX_DESC];
        int prioridad;           ///< 1=Baja, 2=Media, 3=Alta.
        int estado;              ///< 1=Pendiente, 2=En Proceso, 3=Finalizada.
        int id_tecnico_asignado; ///< ID del técnico (0 si no está asignado).
} solicitud_t;

#endif // TIPOS_H