#include <stdio.h>
#include <stdlib.h>

typedef struct nodo
{
        int dato;
        struct nodo *siguiente;
        struct nodo *anterior;
} NODO;

NODO *CrearNodo(int dato);
void InsertarFinal(NODO **cabeza, int dato);
void ImprimirLista(NODO *cabeza);
void invertirLista(NODO **cabeza);

int main()
{
        NODO *cabeza = NULL;

        InsertarFinal(&cabeza, 1);
        InsertarFinal(&cabeza, 2);
        InsertarFinal(&cabeza, 3);
        InsertarFinal(&cabeza, 4);
        InsertarFinal(&cabeza, 5);

        printf("Lista Original: ");
        ImprimirLista(cabeza);

        invertirLista(&cabeza);

        printf("Lista Invertida: ");
        ImprimirLista(cabeza);

        return 0;
}

void invertirLista(NODO **cabeza)
{
        NODO *temp = NULL;
        NODO *actual = *cabeza;
        NODO *ultimoNodo = NULL;

        while (actual != NULL)
        {
                ultimoNodo = actual;

                temp = actual->anterior;
                actual->anterior = actual->siguiente;
                actual->siguiente = temp;

                actual = actual->anterior;
        }

        if (ultimoNodo != NULL)
        {
                *cabeza = ultimoNodo;
        }
}

NODO *CrearNodo(int dato)
{
        NODO *nuevo = (NODO *)malloc(sizeof(NODO));
        if (nuevo != NULL)
        {
                nuevo->dato = dato;
                nuevo->siguiente = NULL;
                nuevo->anterior = NULL;
        }
        return nuevo;
}

void InsertarFinal(NODO **cabeza, int dato)
{
        NODO *nuevo = NULL, *nAux = *cabeza;
        nuevo = CrearNodo(dato);
        if (nuevo != NULL)
        {
                if (*cabeza == NULL)
                {
                        *cabeza = nuevo;
                        return;
                }
                while (nAux->siguiente != NULL)
                {
                        nAux = nAux->siguiente;
                }
                nuevo->anterior = nAux;
                nAux->siguiente = nuevo;
        }
}

void ImprimirLista(NODO *cabeza)
{
        NODO *nAux = cabeza;
        while (nAux != NULL)
        {
                printf("%d ", nAux->dato);
                nAux = nAux->siguiente;
        }
        printf("\n");
}