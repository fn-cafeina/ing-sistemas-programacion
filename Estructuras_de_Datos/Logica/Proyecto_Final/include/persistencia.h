/**
 * @file persistencia.h
 * @brief Prototipos de funciones para guardar y cargar datos en archivos.
 */
#ifndef PERSISTENCIA_H
#define PERSISTENCIA_H

/**
 * @brief Carga el estado de la aplicación (técnicos y solicitudes) desde
 * archivos binarios (definidos en tipos.h).
 * Si los archivos no existen, inicializa los contadores a 0.
 */
void cargar_datos(void);

/**
 * @brief Guarda el estado actual de la aplicación (técnicos y solicitudes)
 * en archivos binarios.
 */
void guardar_datos(void);

#endif // PERSISTENCIA_H