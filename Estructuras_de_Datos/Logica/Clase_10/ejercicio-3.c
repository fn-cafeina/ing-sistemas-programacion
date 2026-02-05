/*
        Ejercicio 3: Operaciones entre listas

        • Objetivo:
        Crear dos listas doblemente enlazadas e implementar operaciones entre ellas.

        • Implementación:
        o Unión: Combinar dos listas en una sola.
        o Intersección: Crear una nueva lista con los elementos comunes a ambas.
        o Diferencia: Crear una lista con los elementos que están en la primera
        lista pero no en la segunda.
*/

#include <stdio.h>
#include <stdlib.h>

struct node
{
        int data;
        struct node *next;
        struct node *prev;
};

void insert_node(struct node **head, int data)
{
        struct node *new_node = malloc(sizeof(*new_node));
        if (!new_node)
        {
                perror("Fallo en malloc");
                return;
        }
        new_node->data = data;
        new_node->next = NULL;

        if (!*head)
        {
                new_node->prev = NULL;
                *head = new_node;
                return;
        }

        struct node *last = *head;
        while (last->next)
                last = last->next;
        last->next = new_node;
        new_node->prev = last;
}

int exists(struct node *head, int data)
{
        struct node *curr = head;
        while (curr)
        {
                if (curr->data == data)
                        return 1;
                curr = curr->next;
        }
        return 0;
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

struct node *union_list(struct node *list_a, struct node *list_b)
{
        struct node *result = NULL;
        struct node *curr;

        for (curr = list_a; curr; curr = curr->next)
                insert_node(&result, curr->data);

        for (curr = list_b; curr; curr = curr->next)
        {
                if (!exists(result, curr->data))
                        insert_node(&result, curr->data);
        }
        return result;
}

struct node *intersection_list(struct node *list_a, struct node *list_b)
{
        struct node *result = NULL;
        struct node *curr;

        for (curr = list_a; curr; curr = curr->next)
        {
                if (exists(list_b, curr->data))
                        insert_node(&result, curr->data);
        }
        return result;
}

struct node *difference_list(struct node *list_a, struct node *list_b)
{
        struct node *result = NULL;
        struct node *curr;

        for (curr = list_a; curr; curr = curr->next)
        {
                if (!exists(list_b, curr->data))
                        insert_node(&result, curr->data);
        }
        return result;
}

int main(void)
{
        struct node *list_a = NULL;
        struct node *list_b = NULL;
        struct node *u_list, *i_list, *d_list;

        insert_node(&list_a, 10);
        insert_node(&list_a, 20);
        insert_node(&list_a, 30);

        insert_node(&list_b, 20);
        insert_node(&list_b, 40);
        insert_node(&list_b, 50);

        printf("Lista A: ");
        display_list(list_a);
        printf("Lista B: ");
        display_list(list_b);

        printf("\nUnion (A U B): ");
        u_list = union_list(list_a, list_b);
        display_list(u_list);

        printf("\nInterseccion (A n B): ");
        i_list = intersection_list(list_a, list_b);
        display_list(i_list);

        printf("\nDiferencia (A - B): ");
        d_list = difference_list(list_a, list_b);
        display_list(d_list);

        free_list(&u_list);
        free_list(&i_list);
        free_list(&d_list);
        free_list(&list_a);
        free_list(&list_b);

        return 0;
}