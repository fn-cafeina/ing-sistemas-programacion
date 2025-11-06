/*
    Ejercicio 1: Crear y mostrar una lista circular simple
    Enunciado:
    Escribe un programa en C que:
    1. Cree una lista circular con 3 números enteros fijos (10, 20 y 30).
    2. Recorra la lista y muestre los valores una sola vez.
    Ejemplo de salida:
    10 -> 20 -> 30 -> (vuelve al inicio)
    Modificación:
    El último nodo debe apuntar al primero (ultimo->siguiente = primero;).
*/

#include <stdio.h>
#include <stdlib.h>

typedef struct Nodo {
        int dato;
        struct Nodo* siguiente;
} Nodo;

int main() {
        Nodo* primero = (Nodo*)malloc(sizeof(Nodo));
        Nodo* segundo = (Nodo*)malloc(sizeof(Nodo));
        Nodo* tercero = (Nodo*)malloc(sizeof(Nodo));

        primero->dato = 10;
        segundo->dato = 20;
        tercero->dato = 30;

        primero->siguiente = segundo;
        segundo->siguiente = tercero;
        tercero->siguiente = primero; // circular

        Nodo* actual = primero;
        do {
                printf("%d -> ", actual->dato);
                actual = actual->siguiente;
        } while (actual != primero);

        printf("(vuelve al inicio)\n");

        free(primero);
        free(segundo);
        free(tercero);

        return 0;
}