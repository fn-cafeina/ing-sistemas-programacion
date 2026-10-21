/*
        Una empresa medica desea realizar un sistema de control de pacientes,
        el líder del proyecto le encarga
        el desarrollo de dicho programa utilizando listas enlazadas
        para llevar el registro de pacientes.
        Dicha aplicación debe de presentar el siguiente menú:
        1. Registrar paciente
        2. Eliminar datos de paciente
        3. Actualizar datos de paciente
        4. Mostrar datos de paciente
        5. Mostrar listado de paciente

        La estructura a utilizar para llevar el control de pacientes:
        struct nodo{
                int codigo;             // campo codigo
                char nombres[30];       // campo que almacena el nombre
                char apellidos[30];     // campo que almacena el apellido
                char direccion[60];     // campo que almacena la direccion
                long telefono;          // campo que almacena el telefono
                struct nodo *sgte;
        };

        Nota: Recuerde que antes que finalice la ejecución del programa
        debe liberar toda la lista (memoria asignada)
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct patient
{
        int codigo;
        char nombres[30];
        char apellidos[30];
        char direccion[60];
        long telefono;
        struct patient *sgte;
};

void clear_input_buffer(void)
{
        int c;
        while ((c = getchar()) != '\n' && c != EOF)
        {
        }
}

void display_menu(void)
{
        printf("\n--- SISTEMA DE CONTROL DE PACIENTES ---\n");
        printf("1. Registrar paciente\n");
        printf("2. Eliminar datos de paciente\n");
        printf("3. Actualizar datos de paciente\n");
        printf("4. Mostrar datos de un paciente\n");
        printf("5. Mostrar listado de todos los pacientes\n");
        printf("6. Salir\n");
        printf("---------------------------------------\n");
        printf("Seleccione una opcion: ");
}

struct patient *find_patient(struct patient *head, int code)
{
        struct patient *curr = head;
        while (curr)
        {
                if (curr->codigo == code)
                        return curr;
                curr = curr->sgte;
        }
        return NULL;
}

void register_patient(struct patient **head)
{
        struct patient *new_patient = malloc(sizeof(*new_patient));
        if (!new_patient)
        {
                perror("Fallo en malloc");
                return;
        }

        printf("-> Ingrese codigo: ");
        scanf("%d", &new_patient->codigo);
        clear_input_buffer();

        if (find_patient(*head, new_patient->codigo))
        {
                printf("-> Error: ya existe un paciente con ese codigo.\n");
                free(new_patient);
                return;
        }

        printf("-> Ingrese nombres: ");
        fgets(new_patient->nombres, 30, stdin);
        new_patient->nombres[strcspn(new_patient->nombres, "\n")] = 0;

        printf("-> Ingrese apellidos: ");
        fgets(new_patient->apellidos, 30, stdin);
        new_patient->apellidos[strcspn(new_patient->apellidos, "\n")] = 0;

        printf("-> Ingrese direccion: ");
        fgets(new_patient->direccion, 60, stdin);
        new_patient->direccion[strcspn(new_patient->direccion, "\n")] = 0;

        printf("-> Ingrese telefono: ");
        scanf("%ld", &new_patient->telefono);
        clear_input_buffer();

        new_patient->sgte = *head;
        *head = new_patient;
        printf("-> Paciente registrado con exito.\n");
}

void delete_patient(struct patient **head)
{
        int code;
        struct patient *temp = *head;
        struct patient *prev = NULL;

        if (!*head)
        {
                printf("-> La lista esta vacia. Nada que eliminar.\n");
                return;
        }

        printf("-> Ingrese el codigo del paciente a eliminar: ");
        scanf("%d", &code);
        clear_input_buffer();

        if (temp != NULL && temp->codigo == code)
        {
                *head = temp->sgte;
                free(temp);
                printf("-> Paciente eliminado.\n");
                return;
        }

        while (temp != NULL && temp->codigo != code)
        {
                prev = temp;
                temp = temp->sgte;
        }

        if (temp == NULL)
        {
                printf("-> Paciente con codigo %d no encontrado.\n", code);
                return;
        }

        prev->sgte = temp->sgte;
        free(temp);
        printf("-> Paciente eliminado.\n");
}

void update_patient(struct patient *head)
{
        int code;
        struct patient *patient_to_update;

        if (!head)
        {
                printf("-> La lista esta vacia. Nada que actualizar.\n");
                return;
        }

        printf("-> Ingrese el codigo del paciente a actualizar: ");
        scanf("%d", &code);
        clear_input_buffer();

        patient_to_update = find_patient(head, code);

        if (!patient_to_update)
        {
                printf("-> Paciente con codigo %d no encontrado.\n", code);
                return;
        }

        printf("-> Introduzca los nuevos datos para el paciente %d:\n", code);
        printf("-> Ingrese nombres: ");
        fgets(patient_to_update->nombres, 30, stdin);
        patient_to_update->nombres[strcspn(patient_to_update->nombres, "\n")] = 0;

        printf("-> Ingrese apellidos: ");
        fgets(patient_to_update->apellidos, 30, stdin);
        patient_to_update->apellidos[strcspn(patient_to_update->apellidos, "\n")] = 0;

        printf("-> Ingrese direccion: ");
        fgets(patient_to_update->direccion, 60, stdin);
        patient_to_update->direccion[strcspn(patient_to_update->direccion, "\n")] = 0;

        printf("-> Ingrese telefono: ");
        scanf("%ld", &patient_to_update->telefono);
        clear_input_buffer();

        printf("-> Datos del paciente actualizados con exito.\n");
}

void display_one_patient(struct patient *head)
{
        int code;
        struct patient *found_patient;

        if (!head)
        {
                printf("-> La lista esta vacia.\n");
                return;
        }

        printf("-> Ingrese el codigo del paciente a buscar: ");
        scanf("%d", &code);
        clear_input_buffer();

        found_patient = find_patient(head, code);

        if (found_patient)
        {
                printf("\n-- Datos del Paciente --\n");
                printf("   Codigo: %d\n", found_patient->codigo);
                printf("   Nombre: %s %s\n", found_patient->nombres, found_patient->apellidos);
                printf("   Direccion: %s\n", found_patient->direccion);
                printf("   Telefono: %ld\n", found_patient->telefono);
                printf("------------------------\n");
        }
        else
        {
                printf("-> Paciente con codigo %d no encontrado.\n", code);
        }
}

void display_all_patients(struct patient *head)
{
        struct patient *curr = head;
        if (!curr)
        {
                printf("-> No hay pacientes registrados.\n");
                return;
        }
        printf("\n--- LISTADO COMPLETO DE PACIENTES ---\n");
        while (curr)
        {
                printf("\n-- Codigo: %d --\n", curr->codigo);
                printf("   Nombre: %s %s\n", curr->nombres, curr->apellidos);
                printf("   Direccion: %s\n", curr->direccion);
                printf("   Telefono: %ld\n", curr->telefono);
                curr = curr->sgte;
        }
        printf("-------------------------------------\n");
}

void free_patient_list(struct patient **head)
{
        struct patient *curr = *head;
        struct patient *next_node;
        while (curr)
        {
                next_node = curr->sgte;
                free(curr);
                curr = next_node;
        }
        *head = NULL;
}

int main(void)
{
        struct patient *patient_list = NULL;
        int choice = 0;

        while (choice != 6)
        {
                display_menu();
                scanf("%d", &choice);
                clear_input_buffer();

                switch (choice)
                {
                case 1:
                        register_patient(&patient_list);
                        break;
                case 2:
                        delete_patient(&patient_list);
                        break;
                case 3:
                        update_patient(patient_list);
                        break;
                case 4:
                        display_one_patient(patient_list);
                        break;
                case 5:
                        display_all_patients(patient_list);
                        break;
                case 6:
                        printf("Saliendo del programa...\n");
                        break;
                default:
                        printf("-> Opcion no valida. Intente de nuevo.\n");
                        break;
                }
        }

        free_patient_list(&patient_list);
        printf("Memoria liberada. Adios.\n");
        return 0;
}