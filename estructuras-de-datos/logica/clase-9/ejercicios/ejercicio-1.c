/*
        Actividad: Modificar este ejemplo para trabajarlo con un menú de opciones
        y añada la operación de borrar un nodo cualquiera.
*/

#include <stdio.h>
#include <stdlib.h>

// Estructura que define cada nodo de la lista.
struct datos
{
        int valor;
        struct datos *sig, *ant; // Punteros al nodo siguiente y al anterior.
};

// 'pNodo' es un puntero a un nodo, 'Lista' es un puntero a la cabeza de la lista.
typedef struct datos *pNodo, *Lista;

// Prototipos de las funciones.
void InsertarLista(Lista *cab, int v);
void BorrarNodo(Lista *cab, int v);
void MostrarLista(Lista cab, int orden);
void BorrarLista(Lista *cab);
void menu();

int main()
{
        Lista c = NULL; // La lista inicia vacía.
        int opcion, valor;

        do
        {
                menu();
                scanf("%d", &opcion);

                switch (opcion)
                {
                case 1:
                        printf("  > Ingrese el valor a insertar: ");
                        scanf("%d", &valor);
                        InsertarLista(&c, valor);
                        break;
                case 2:
                        printf("  > Ingrese el valor a borrar: ");
                        scanf("%d", &valor);
                        BorrarNodo(&c, valor);
                        break;
                case 3:
                        MostrarLista(c, 0); // 0 para orden ascendente.
                        break;
                case 4:
                        MostrarLista(c, 1); // 1 para orden descendente.
                        break;
                case 5:
                        printf("  [!] Saliendo del programa...\n");
                        BorrarLista(&c); // Libera toda la memoria antes de terminar.
                        break;
                default:
                        printf("  [!] Opcion no valida.\n");
                }
        } while (opcion != 5);

        return 0;
}

void menu()
{
        printf("\n----------- MENU LISTA DOBLE -----------\n");
        printf(" 1. Insertar un elemento\n");
        printf(" 2. Borrar un elemento\n");
        printf(" 3. Mostrar lista (Inicio a Fin)\n");
        printf(" 4. Mostrar lista (Fin a Inicio)\n");
        printf(" 5. Salir\n");
        printf("----------------------------------------\n");
        printf(" Seleccione una opcion: ");
}

// Inserta un nuevo nodo siempre al inicio de la lista.
void InsertarLista(Lista *cab, int v)
{
        pNodo nuevo = (pNodo)malloc(sizeof(struct datos));
        if (!nuevo)
        {
                exit(1);
        } // Termina si no hay memoria.

        nuevo->valor = v;
        nuevo->ant = NULL;

        // --- Lógica de enlace ---
        nuevo->sig = *cab; // El nuevo nodo apunta a la antigua cabeza.
        if (*cab != NULL)
        {
                (*cab)->ant = nuevo; // La antigua cabeza ahora apunta hacia atrás, al nuevo nodo.
        }
        *cab = nuevo; // La cabeza de la lista ahora es el nuevo nodo.
}

// Muestra la lista en orden ascendente (0) o descendente (1).
void MostrarLista(Lista cab, int orden)
{
        if (!cab)
        {
                printf("\n  [!] La lista esta vacia.\n");
                return;
        }

        if (orden == 0)
        {
                printf("\n  [+] Lista (Orden Ascendente):\n  ");
                while (cab)
                {
                        printf("%d -> ", cab->valor);
                        cab = cab->sig;
                }
        }
        else
        {
                printf("\n  [+] Lista (Orden Descendente):\n  ");
                // Para el orden descendente, primero viajamos hasta el final de la lista.
                while (cab->sig)
                {
                        cab = cab->sig;
                }
                // Ahora recorremos hacia atrás usando el puntero 'ant'.
                while (cab)
                {
                        printf("%d -> ", cab->valor);
                        cab = cab->ant;
                }
        }
        printf("NULL\n");
}

// Busca un nodo por su valor y lo elimina de la lista.
void BorrarNodo(Lista *cab, int v)
{
        if (!*cab)
        {
                printf("  [!] La lista esta vacia.\n");
                return;
        }

        pNodo p = *cab;

        // Bucle para encontrar el nodo con el valor buscado.
        while (p != NULL && p->valor != v)
        {
                p = p->sig;
        }

        if (p == NULL)
        {
                printf("  [!] Valor %d no encontrado.\n", v);
                return;
        }

        // --- Lógica de re-enlace para eliminar el nodo 'p' ---
        if (p->ant != NULL)
        {
                p->ant->sig = p->sig; // El anterior a 'p' ahora apunta al siguiente de 'p'.
        }
        else
        {
                *cab = p->sig; // Si 'p' era la cabeza, la nueva cabeza es su siguiente.
        }

        if (p->sig != NULL)
        {
                p->sig->ant = p->ant; // El siguiente a 'p' ahora apunta al anterior de 'p'.
        }

        printf("  [!] Nodo con valor %d borrado.\n", v);
        free(p); // Se libera la memoria del nodo eliminado.
}

// Recorre toda la lista y libera la memoria de cada nodo.
void BorrarLista(Lista *cab)
{
        pNodo actual;
        while (*cab != NULL)
        {
                actual = *cab;
                *cab = actual->sig;
                free(actual);
        }
}