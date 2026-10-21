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

        if (*head_ref == NULL)
        {
                *head_ref = nuevo_nodo;
                nuevo_nodo->next = *head_ref;
        }
        else
        {
                struct node *temp = *head_ref;
                while (temp->next != *head_ref)
                {
                        temp = temp->next;
                }
                temp->next = nuevo_nodo;
                nuevo_nodo->next = *head_ref;
        }
}

void mostrar_lista(struct node *head, const char *nombre)
{
        if (head == NULL)
        {
                printf("%s: [Vacía]\n", nombre);
                return;
        }

        struct node *temp = head;
        printf("%s: ", nombre);
        do
        {
                printf("%d -> ", temp->data);
                temp = temp->next;
        } while (temp != head);
        printf("(Inicio)\n");
}

void dividir_lista(struct node *head, struct node **head1_ref, struct node **head2_ref)
{
        if (head == NULL)
        {
                *head1_ref = NULL;
                *head2_ref = NULL;
                return;
        }

        int n = 0;
        struct node *temp = head;
        do
        {
                n++;
                temp = temp->next;
        } while (temp != head);

        int tam1 = (n / 2) + (n % 2);

        struct node *ultimo_lista1 = head;
        for (int i = 0; i < tam1 - 1; i++)
        {
                ultimo_lista1 = ultimo_lista1->next;
        }

        struct node *ultimo_lista2 = ultimo_lista1->next;
        while (ultimo_lista2->next != head)
        {
                ultimo_lista2 = ultimo_lista2->next;
        }

        *head1_ref = head;
        *head2_ref = ultimo_lista1->next;

        ultimo_lista1->next = *head1_ref;
        ultimo_lista2->next = *head2_ref;
}

int main()
{
        struct node *head = NULL;
        struct node *head1 = NULL;
        struct node *head2 = NULL;

        printf("--- Caso 1: Lista Impar (5 nodos) ---\n");
        insertar_final(&head, 1);
        insertar_final(&head, 2);
        insertar_final(&head, 3);
        insertar_final(&head, 4);
        insertar_final(&head, 5);

        mostrar_lista(head, "Lista Original");
        dividir_lista(head, &head1, &head2);
        mostrar_lista(head1, "Primera Mitad");
        mostrar_lista(head2, "Segunda Mitad");

        head = NULL;
        head1 = NULL;
        head2 = NULL;

        printf("\n--- Caso 2: Lista Par (4 nodos) ---\n");
        insertar_final(&head, 10);
        insertar_final(&head, 20);
        insertar_final(&head, 30);
        insertar_final(&head, 40);

        mostrar_lista(head, "Lista Original");
        dividir_lista(head, &head1, &head2);
        mostrar_lista(head1, "Primera Mitad");
        mostrar_lista(head2, "Segunda Mitad");

        return 0;
}