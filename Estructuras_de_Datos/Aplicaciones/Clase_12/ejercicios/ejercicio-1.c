#include <stdio.h>
#include <stdlib.h>

struct node
{
        int data;
        struct node *next;
        struct node *prev;
};

struct node *crear_nodo(int data)
{
        struct node *nuevo_nodo = (struct node *)malloc(sizeof(struct node));
        nuevo_nodo->data = data;
        nuevo_nodo->next = NULL;
        nuevo_nodo->prev = NULL;
        return nuevo_nodo;
}

void insertar_ordenado(struct node **head_ref, int data)
{
        struct node *nuevo_nodo = crear_nodo(data);

        if (*head_ref == NULL)
        {
                *head_ref = nuevo_nodo;
                nuevo_nodo->next = nuevo_nodo;
                nuevo_nodo->prev = nuevo_nodo;
                return;
        }

        struct node *head = *head_ref;
        struct node *ultimo = head->prev;

        if (data < head->data)
        {
                nuevo_nodo->next = head;
                nuevo_nodo->prev = ultimo;
                ultimo->next = nuevo_nodo;
                head->prev = nuevo_nodo;
                *head_ref = nuevo_nodo;
                return;
        }

        struct node *actual = head;
        while (actual->next != head && actual->next->data < data)
        {
                actual = actual->next;
        }

        nuevo_nodo->next = actual->next;
        nuevo_nodo->prev = actual;
        actual->next->prev = nuevo_nodo;
        actual->next = nuevo_nodo;
}

void mostrar_adelante(struct node *head)
{
        if (head == NULL)
        {
                printf("Lista vacía.\n");
                return;
        }

        struct node *temp = head;
        printf("Lista (Adelante): ");
        do
        {
                printf("%d <-> ", temp->data);
                temp = temp->next;
        } while (temp != head);
        printf("(Inicio)\n");
}

void mostrar_atras(struct node *head)
{
        if (head == NULL)
        {
                printf("Lista vacía.\n");
                return;
        }

        struct node *ultimo = head->prev;
        struct node *temp = ultimo;

        printf("Lista (Atrás):   ");
        do
        {
                printf("%d <-> ", temp->data);
                temp = temp->prev;
        } while (temp != ultimo);
        printf("(Fin)\n");
}

int main()
{
        struct node *head = NULL;

        printf("Insertando 10, 5, 20, 15...\n");
        insertar_ordenado(&head, 10);
        insertar_ordenado(&head, 5);
        insertar_ordenado(&head, 20);
        insertar_ordenado(&head, 15);

        mostrar_adelante(head);
        mostrar_atras(head);

        return 0;
}