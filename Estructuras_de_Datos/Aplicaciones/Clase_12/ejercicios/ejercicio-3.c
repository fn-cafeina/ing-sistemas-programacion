#include <stdio.h>
#include <stdlib.h>

struct node
{
        int data;
        struct node *next;
};

void insertar_final(struct node **head_ref, int data)
{
        struct node *nuevo_nodo = (struct node *)malloc(sizeof(struct node));
        nuevo_nodo->data = data;
        nuevo_nodo->next = NULL;

        if (*head_ref == NULL)
        {
                *head_ref = nuevo_nodo;
                return;
        }

        struct node *temp = *head_ref;
        while (temp->next != NULL)
        {
                temp = temp->next;
        }
        temp->next = nuevo_nodo;
}

void mostrar_lista_segura(struct node *head)
{
        if (head == NULL)
        {
                printf("[Vacía]\n");
                return;
        }
        struct node *temp = head;
        int i = 0;
        while (temp != NULL && i < 20)
        {
                printf("%d -> ", temp->data);
                temp = temp->next;
                i++;
        }
        if (temp != NULL)
        {
                printf("... (Ciclo detectado al mostrar)\n");
        }
        else
        {
                printf("NULL\n");
        }
}

void crear_ciclo(struct node *head, int posicion)
{
        if (head == NULL)
                return;

        struct node *nodo_ciclo = head;
        int contador = 1;
        while (contador < posicion && nodo_ciclo->next != NULL)
        {
                nodo_ciclo = nodo_ciclo->next;
                contador++;
        }

        struct node *ultimo = head;
        while (ultimo->next != NULL)
        {
                ultimo = ultimo->next;
        }

        printf("Simulando error: Conectando el último nodo (%d) al nodo en posición %d (%d)\n",
               ultimo->data, posicion, nodo_ciclo->data);
        ultimo->next = nodo_ciclo;
}

void detectar_y_romper_ciclo(struct node *head)
{
        if (head == NULL || head->next == NULL)
        {
                return;
        }

        struct node *tortuga = head, *liebre = head;

        tortuga = tortuga->next;
        liebre = liebre->next->next;
        while (liebre && liebre->next)
        {
                if (tortuga == liebre)
                {
                        break;
                }
                tortuga = tortuga->next;
                liebre = liebre->next->next;
        }

        if (tortuga != liebre)
        {
                printf("No se detectó ningún ciclo.\n");
                return;
        }

        printf("¡Ciclo detectado! Punto de encuentro: %d\n", tortuga->data);

        tortuga = head;
        while (tortuga != liebre)
        {
                tortuga = tortuga->next;
                liebre = liebre->next;
        }
        printf("El ciclo comienza en el nodo: %d\n", tortuga->data);

        while (liebre->next != tortuga)
        {
                liebre = liebre->next;
        }

        printf("Rompiendo el ciclo (enlace de %d a %d)\n", liebre->data, tortuga->data);
        liebre->next = NULL;
}

int main()
{
        struct node *head = NULL;
        insertar_final(&head, 10);
        insertar_final(&head, 20);
        insertar_final(&head, 30);
        insertar_final(&head, 40);
        insertar_final(&head, 50);
        insertar_final(&head, 60);

        printf("Lista original:\n");
        mostrar_lista_segura(head);

        crear_ciclo(head, 3);

        printf("\nLista con ciclo (mostrando con límite):\n");
        mostrar_lista_segura(head);

        printf("\n--- Detección y Eliminación ---\n");
        detectar_y_romper_ciclo(head);

        printf("\nLista final sin ciclo:\n");
        mostrar_lista_segura(head);

        return 0;
}