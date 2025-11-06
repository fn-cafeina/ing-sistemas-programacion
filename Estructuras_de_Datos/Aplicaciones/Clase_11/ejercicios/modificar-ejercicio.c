/*
    Ejercicio Propuesto 1:
    Modifique el ejercicio propuesto #3 de la guía Listas doblemente enlazadas,
    de tal forma que aplique su funcionalidad por medio de una Lista circular.

    Operaciones básicas:
    - Insertar nodo
    - Mostrar lista
    - Borrar nodo
*/

#include <stdio.h>
#include <stdlib.h>

typedef struct Nodo {
        int dato;
        struct Nodo* siguiente;
} Nodo;

typedef Nodo* Lista;

void insertar(Lista *lista, int valor) {
        Nodo* nuevo = (Nodo*)malloc(sizeof(Nodo));
        nuevo->dato = valor;

        if (*lista == NULL) {
                *lista = nuevo;
                nuevo->siguiente = nuevo; // circular
        } else {
                nuevo->siguiente = (*lista)->siguiente;
                (*lista)->siguiente = nuevo;
        }
}

void mostrar(Lista lista) {
        if (!lista) {
                printf("Lista vacia\n");
                return;
        }
        Nodo* actual = lista->siguiente;
        do {
                printf("%d -> ", actual->dato);
                actual = actual->siguiente;
        } while (actual != lista->siguiente);
        printf("\n");
}

void borrar(Lista *lista, int valor) {
        if (!*lista) return;
        Nodo* actual = *lista;
        Nodo* anterior = NULL;

        do {
                anterior = actual;
                actual = actual->siguiente;
                if (actual->dato == valor) {
                        anterior->siguiente = actual->siguiente;
                        if (actual == *lista) {
                                *lista = anterior;
                        }
                        free(actual);
                        return;
                }
        } while (actual != *lista);
}

int main() {
        Lista lista = NULL;

        insertar(&lista, 10);
        insertar(&lista, 20);
        insertar(&lista, 30);

        printf("Lista inicial:\n");
        mostrar(lista);

        borrar(&lista, 20);
        printf("Lista despues de borrar 20:\n");
        mostrar(lista);

        return 0;
}
