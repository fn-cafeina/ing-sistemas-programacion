/*
        Ejercicio 2: Gestión de una lista de estudiantes

        • Objetivo:
        Crear una lista de estudiantes, donde cada nodo contenga datos del estudiante
        como nombre, matrícula, etc.

        • Implementación:
        Se crea una estructura Estudiante que contiene los datos y punteros a siguiente y
        anterior. Se implementan funciones para:

        • Insertar: Agregar un nuevo estudiante a la lista, ya sea al principio, al final o en
        una posición específica.

        • Buscar: Encontrar un estudiante por su matrícula.

        • Eliminar: Eliminar un estudiante de la lista por su matrícula, actualizando los
        punteros de los nodos adyacentes y liberando la memoria.
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define ID_LEN 20
#define NAME_LEN 50

struct student
{
        char id[ID_LEN];
        char name[NAME_LEN];
        struct student *next;
        struct student *prev;
};

void insert_student(struct student **head, const char *id, const char *name)
{
        struct student *new_student = malloc(sizeof(*new_student));

        if (!new_student)
        {
                perror("Fallo en la asignacion de memoria");
                return;
        }

        strncpy(new_student->id, id, ID_LEN - 1);
        new_student->id[ID_LEN - 1] = '\0';

        strncpy(new_student->name, name, NAME_LEN - 1);
        new_student->name[NAME_LEN - 1] = '\0';

        new_student->next = NULL;

        if (!*head)
        {
                new_student->prev = NULL;
                *head = new_student;
                return;
        }

        struct student *last = *head;
        while (last->next)
                last = last->next;

        last->next = new_student;
        new_student->prev = last;
}

struct student *find_student(struct student *head, const char *id)
{
        struct student *curr = head;

        while (curr)
        {
                if (strcmp(curr->id, id) == 0)
                        return curr;
                curr = curr->next;
        }
        return NULL;
}

void delete_student(struct student **head, const char *id)
{
        struct student *to_delete = find_student(*head, id);

        if (!to_delete)
        {
                printf("-> Estudiante con matricula '%s' no encontrado.\n", id);
                return;
        }

        if (to_delete->prev)
                to_delete->prev->next = to_delete->next;
        else
                *head = to_delete->next;

        if (to_delete->next)
                to_delete->next->prev = to_delete->prev;

        free(to_delete);
        printf("-> Estudiante con matricula '%s' ha sido eliminado.\n", id);
}

void display_students(struct student *head)
{
        struct student *curr = head;
        if (!curr)
        {
                printf("La lista de estudiantes está vacía.\n");
                return;
        }
        while (curr)
        {
                printf("  Matricula: %-12s | Nombre: %s\n", curr->id, curr->name);
                curr = curr->next;
        }
}

void free_student_list(struct student **head)
{
        struct student *curr = *head;
        struct student *next_node;

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
        struct student *student_list = NULL;

        insert_student(&student_list, "2023-001A", "Juan Perez");
        insert_student(&student_list, "2023-002B", "Ana Gomez");
        insert_student(&student_list, "2023-003C", "Luis Castro");

        printf("Lista original:\n");
        display_students(student_list);

        printf("\nEliminando al estudiante 2023-002B...\n");
        delete_student(&student_list, "2023-002B");

        printf("\nLista final:\n");
        display_students(student_list);

        free_student_list(&student_list);

        return 0;
}