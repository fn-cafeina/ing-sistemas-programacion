/*
    Ejercicio 2: Recorrer la lista circular dos veces
    Enunciado:
    Usando la lista del ejercicio anterior (10, 20, 30),
    haz que el programa muestre los valores dos veces seguidas,
    para demostrar que la lista es circular.
    Ejemplo de salida:
    Recorrido 1: 10 -> 20 -> 30 ->
    Recorrido 2: 10 -> 20 -> 30 ->
    Modificación:
    Puedes usar un contador que indique cuántas vueltas llevas en el recorrido.
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
        int vueltas = 0;

        while (vueltas < 2) {
                printf("Recorrido %d: ", vueltas + 1);
                do {
                        printf("%d -> ", actual->dato);
                        actual = actual->siguiente;
                } while (actual != primero);
                printf("\n");
                vueltas++;
        }

        free(primero);
        free(segundo);
        free(tercero);

        return 0;
}
