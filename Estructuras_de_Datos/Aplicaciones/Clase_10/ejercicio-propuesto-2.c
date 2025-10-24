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
int contarOcurrencias(NODO *cabeza, int valor);

int main()
{
        NODO *cabeza = NULL;
        int valorBuscado, contador;

        InsertarFinal(&cabeza, 5);
        InsertarFinal(&cabeza, 2);
        InsertarFinal(&cabeza, 7);
        InsertarFinal(&cabeza, 2);
        InsertarFinal(&cabeza, 5);
        InsertarFinal(&cabeza, 5);

        printf("Lista actual: ");
        ImprimirLista(cabeza);

        printf("Ingrese el valor que desea buscar: ");
        scanf("%d", &valorBuscado);

        contador = contarOcurrencias(cabeza, valorBuscado);

        if (contador == 0)
        {
                printf("El dato %d no fue encontrado en la lista.\n", valorBuscado);
        }
        else
        {
                printf("El dato %d se encuentra %d vez/veces en la lista.\n", valorBuscado, contador);
        }

        return 0;
}

int contarOcurrencias(NODO *cabeza, int valor)
{
        NODO *actual = cabeza;
        int contador = 0;
        while (actual != NULL)
        {
                if (actual->dato == valor)
                {
                        contador++;
                }
                actual = actual->siguiente;
        }
        return contador;
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