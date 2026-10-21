/*
        Ejercicio 2: Buscar y eliminar un elemento

        Enunciado:
        Usando una lista simplemente enlazada, realiza un programa que:
        1. Inserte varios números enteros.
        2. Permita al usuario buscar un número específico en la lista.
        3. Si el número existe, debe eliminarlo de la lista y mostrar el resultado.
        4. Si no existe, debe mostrar un mensaje indicando que no se encontró.

        Objetivo: Practicar la búsqueda y eliminación de nodos en listas simples.
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

void find_and_delete(struct node **head, int key)
{
        struct node *temp = *head;
        struct node *prev = NULL;

        if (temp != NULL && temp->data == key)
        {
                *head = temp->next;
                free(temp);
                printf("-> El numero %d ha sido eliminado.\n", key);
                return;
        }

        while (temp != NULL && temp->data != key)
        {
                prev = temp;
                temp = temp->next;
        }

        if (temp == NULL)
        {
                printf("-> El numero %d no se encontro en la lista.\n", key);
                return;
        }

        prev->next = temp->next;
        free(temp);
        printf("-> El numero %d ha sido eliminado.\n", key);
}

void display_list(struct node *head)
{
        struct node *curr = head;
        printf("Lista actual: ");
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
        int number_to_find;

        insert_node(&my_list, 50);
        insert_node(&my_list, 40);
        insert_node(&my_list, 30);
        insert_node(&my_list, 20);
        insert_node(&my_list, 10);

        display_list(my_list);

        printf("Ingrese el numero que desea buscar y eliminar: ");
        scanf("%d", &number_to_find);

        find_and_delete(&my_list, number_to_find);

        display_list(my_list);

        free_list(&my_list);
        return 0;
}