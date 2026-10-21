/*
       Ejercicio 4: Invertir la lista

        • Objetivo: Invertir el orden de los elementos de una lista doblemente enlazada.
        • Implementación: Se recorre la lista, intercambiando los punteros siguiente y
        anterior de cada nodo. Se debe actualizar también el puntero de la cabeza y la
        cola.
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
                perror("Fallo en malloc");
                return;
        }
        new_node->data = data;
        new_node->next = *head;
        new_node->prev = NULL;
        if (*head)
                (*head)->prev = new_node;
        *head = new_node;
}

void display_list(struct node *head)
{
        struct node *curr = head;
        while (curr)
        {
                printf("%d -> ", curr->data);
                curr = curr->next;
        }
        printf("NULL\n");
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

void reverse_list(struct node **head)
{
        struct node *temp = NULL;
        struct node *curr = *head;

        while (curr)
        {
                temp = curr->prev;
                curr->prev = curr->next;
                curr->next = temp;
                curr = curr->prev;
        }

        if (temp)
                *head = temp->prev;
}

int main(void)
{
        struct node *my_list = NULL;

        insert_at_head(&my_list, 4);
        insert_at_head(&my_list, 3);
        insert_at_head(&my_list, 2);
        insert_at_head(&my_list, 1);

        printf("Lista Original:  ");
        display_list(my_list);

        reverse_list(&my_list);

        printf("Lista Invertida: ");
        display_list(my_list);

        free_list(&my_list);
        return 0;
}