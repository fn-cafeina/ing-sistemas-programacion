/*
        Ejercicio 1: Recorrer una lista en ambos sentidos

        • Objetivo:
        Implementar las funciones para recorrer la lista hacia adelante y hacia atrás.

        • Implementación:
        Se necesita una estructura de nodo que contenga un puntero siguiente y un
        puntero anterior. Se implementan funciones para recorrer desde el primer nodo
        (cabeza) hacia el final, y otra para recorrer desde el último nodo (cola) hacia el
        principio.
*/

#include <stdio.h>
#include <stdlib.h>

struct node
{
        int data;
        struct node *next;
        struct node *prev;
};

void insert_at_head(struct node **head, int data)
{
        struct node *new_node = malloc(sizeof(*new_node));

        if (!new_node)
        {
                perror("Fallo en la asignacion de memoria");
                return;
        }

        new_node->data = data;
        new_node->next = *head;
        new_node->prev = NULL;

        if (*head)
                (*head)->prev = new_node;

        *head = new_node;
}

void free_list(struct node **head)
{
        struct node *curr = *head;
        struct node *next_node;

        while (curr)
        {
                next_node = curr->next;
                free(curr);
                curr = next_node;
        }
        *head = NULL;
}

void traverse_forward(struct node *head)
{
        struct node *curr = head;

        printf("Recorrido hacia adelante: ");
        while (curr)
        {
                printf("%d -> ", curr->data);
                curr = curr->next;
        }
        printf("NULL\n");
}

void traverse_backward(struct node *head)
{
        struct node *tail = head;

        if (!head)
                return;

        while (tail->next)
                tail = tail->next;

        printf("Recorrido hacia atras:    ");
        while (tail)
        {
                printf("%d -> ", tail->data);
                tail = tail->prev;
        }
        printf("NULL\n");
}

int main(void)
{
        struct node *my_list = NULL;

        insert_at_head(&my_list, 30);
        insert_at_head(&my_list, 20);
        insert_at_head(&my_list, 10);

        traverse_forward(my_list);
        traverse_backward(my_list);

        free_list(&my_list);

        return 0;
}