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