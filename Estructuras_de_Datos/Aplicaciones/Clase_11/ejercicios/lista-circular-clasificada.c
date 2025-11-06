/*
    Ejercicio Propuesto 2:
    Lista circular clasificada para un hotel.

    Cada nodo contiene:
    - NumHab (número de habitación)
    - Nombre (nombre del cliente)
    - FechaArr (fecha de arribo, simplificada como entero o string)
    - Precio (precio de la habitación)

    Operaciones:
    a) Registrar huésped
    b) Borrar huésped
    c) Buscar huésped
    d) Mostrar informe tabular
    e) Facturación (dado nombre y días de estancia)
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct Huesped {
        int numHab;
        char nombre[50];
        char fechaArr[20];
        float precio;
        struct Huesped* siguiente;
} Huesped;

typedef Huesped* Lista;

void registrar(Lista *lista, int numHab, char *nombre, char *fecha, float precio) {
        Huesped* nuevo = (Huesped*)malloc(sizeof(Huesped));
        nuevo->numHab = numHab;
        strcpy(nuevo->nombre, nombre);
        strcpy(nuevo->fechaArr, fecha);
        nuevo->precio = precio;

        if (*lista == NULL) {
                *lista = nuevo;
                nuevo->siguiente = nuevo;
        } else {
                Huesped* actual = *lista;
                Huesped* anterior = NULL;
                do {
                        if (numHab < actual->numHab) break;
                        anterior = actual;
                        actual = actual->siguiente;
                } while (actual != *lista);

                if (anterior == NULL) {
                        nuevo->siguiente = *lista;
                        Huesped* ultimo = *lista;
                        while (ultimo->siguiente != *lista) ultimo = ultimo->siguiente;
                        ultimo->siguiente = nuevo;
                        *lista = nuevo;
                } else {
                        nuevo->siguiente = actual;
                        anterior->siguiente = nuevo;
                }
        }
}

void mostrar(Lista lista) {
        if (!lista) {
                printf("Lista vacia\n");
                return;
        }
        Huesped* actual = lista;
        printf("\n%-10s %-20s %-15s %-10s\n", "Hab", "Nombre", "FechaArr", "Precio");
        do {
                printf("%-10d %-20s %-15s %-10.2f\n",
                       actual->numHab, actual->nombre, actual->fechaArr, actual->precio);
                actual = actual->siguiente;
        } while (actual != lista);
}

Huesped* buscar(Lista lista, char *nombre) {
        if (!lista) return NULL;
        Huesped* actual = lista;
        do {
                if (strcmp(actual->nombre, nombre) == 0) return actual;
                actual = actual->siguiente;
        } while (actual != lista);
        return NULL;
}

void borrar(Lista *lista, char *nombre) {
        if (!*lista) return;
        Huesped* actual = *lista;
        Huesped* anterior = NULL;
        do {
                if (strcmp(actual->nombre, nombre) == 0) {
                        if (anterior) anterior->siguiente = actual->siguiente;
                        if (actual == *lista) *lista = actual->siguiente;
                        free(actual);
                        return;
                }
                anterior = actual;
                actual = actual->siguiente;
        } while (actual != *lista);
}

float facturar(Lista lista, char *nombre, int dias) {
        Huesped* h = buscar(lista, nombre);
        if (h) return h->precio * dias;
        return 0.0;
}

int main() {
        Lista hotel = NULL;

        registrar(&hotel, 101, "Carlos Perez", "2025-11-06", 50.0);
        registrar(&hotel, 103, "Ana Lopez", "2025-11-06", 70.0);
        registrar(&hotel, 102, "Maria Ruiz", "2025-11-06", 60.0);

        mostrar(hotel);

        printf("\nFactura de Ana (3 dias): %.2f\n", facturar(hotel, "Ana Lopez", 3));

        borrar(&hotel, "Carlos Perez");
        printf("\nLista despues de borrar a Carlos:\n");
        mostrar(hotel);

        return 0;
}
