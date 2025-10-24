/**
 * @file logica.h
 * @brief Prototipos de la lógica de negocio y estado global de la aplicación.
 */
#ifndef LOGICA_H
#define LOGICA_H

#include "tipos.h"
#include <stdio.h> // Para NULL

/**
 * @brief Puntero al array dinámico de técnicos.
 * Es el estado global de los técnicos, gestionado en logica.c.
 */
extern tecnico_t *g_tecnicos;
extern int g_num_tecnicos;
extern int g_sig_id_tecnico;

/**
 * @brief Puntero al array dinámico de solicitudes.
 * Es el estado global de las solicitudes, gestionado en logica.c.
 */
extern solicitud_t *g_solicitudes;
extern int g_num_solicitudes;
extern int g_sig_id_solicitud;

/**
 * @brief Inicializa los punteros globales de estado a NULL/0.
 */
void inicializar_datos(void);

/**
 * @brief Libera toda la memoria dinámica asignada a los arrays globales.
 */
void liberar_memoria(void);

/**
 * @brief Muestra la interfaz para registrar una nueva solicitud.
 */
void registrar_solicitud(void);

/**
 * @brief Muestra la interfaz para registrar un nuevo técnico.
 */
void registrar_tecnico(void);

/**
 * @brief Muestra la interfaz para asignar una solicitud pendiente a un técnico.
 */
void asignar_tarea(void);

/**
 * @brief Muestra la interfaz para cambiar el estado de una solicitud existente.
 */
void cambiar_estado_solicitud(void);

/**
 * @brief Muestra el submenú de reportes (por técnico, área o estado).
 */
void mostrar_reportes(void);

#endif // LOGICA_H