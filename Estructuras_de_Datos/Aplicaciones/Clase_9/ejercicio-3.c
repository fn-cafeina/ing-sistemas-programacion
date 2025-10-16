/*
        Ejercicio 3: Contar y sumar los elementos de la lista

        Enunciado:
        Desarrolla un programa que cree una lista simplemente enlazada de números enteros.
        Luego, el programa debe:
        1. Mostrar todos los elementos de la lista.
        2. Calcular y mostrar la cantidad de nodos y la suma total de todos los valores.

        Objetivo: Practicar la recorrida completa de una lista enlazada y el uso de
        contadores/acumuladores.
*/

#include <stdio.h>
#include <stdlib.h>

struct node
{
        int data;
        struct node *next;
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
        new_node->next = *head;
        *head = new_node;
}

void analyze_list(struct node *head)
{
        struct node *curr = head;
        int count = 0;
        long sum = 0;

        while (curr)
        {
                sum += curr->data;
                count++;
                curr = curr->next;
        }
        printf("-> Cantidad de nodos: %d\n", count);
        printf("-> Suma total de valores: %ld\n", sum);
}

void display_list(struct node *head)
{
        struct node *curr = head;
        printf("Elementos en la lista: ");
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

int main(void)
{
        struct node *my_list = NULL;

        insert_node(&my_list, 55);
        insert_node(&my_list, 23);
        insert_node(&my_list, 7);
        insert_node(&my_list, 42);
        insert_node(&my_list, 18);

        display_list(my_list);
        analyze_list(my_list);

        free_list(&my_list);
        return 0;
}