/**
 * @file utils.h
 * @brief Prototipos de funciones de utilidad para la interfaz de consola.
 */
#ifndef UTILS_H
#define UTILS_H

/**
 * @brief Limpia la pantalla de la consola (multiplataforma).
 */
void limpiar_pantalla(void);

/**
 * @brief Pausa la ejecución del programa hasta que el usuario presione Enter.
 * Maneja de forma robusta el búfer de entrada.
 */
void pausar(void);

/**
 * @brief Lee y valida una opción numérica del usuario.
 * @param min El valor mínimo aceptado (inclusivo).
 * @param max El valor máximo aceptado (inclusivo).
 * @return La opción numérica validada.
 */
int leer_opcion(int min, int max);

/**
 * @brief Lee una cadena de texto de forma segura desde stdin.
 * Elimina el salto de línea final.
 * @param buffer Puntero al búfer donde se almacenará la cadena.
 * @param len El tamaño máximo del búfer.
 */
void get_string(char *buffer, int len);

#endif // UTILS_H