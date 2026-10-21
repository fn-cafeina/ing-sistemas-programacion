// Se necesita almacenar información sobre animales
// para gestionar una clínica veterinaria. Para comenzar,
// se supondrá que sólo hay un animal. Del animal es
// necesario conocer:
//    Tipo de animal (perro, gato, etc.)
//    Nombre
//    Edad
//    Nombre del dueño
// Implementa un programa que pida los datos necesarios del
// animal utilizando la siguiente variable de tipo puntero:
// animal *a;

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
        char tipo[30];
        char nombre[30];
        int edad;
        char duenio[50];
} animal;

int main()
{
        animal *a;

        a = (animal *)malloc(sizeof(animal));

        if (a == NULL)
        {
                printf("Error al reservar memoria.\n");
                return 1;
        }

        printf("Ingrese el tipo de animal: ");
        fgets(a->tipo, sizeof(a->tipo), stdin);
        a->tipo[strcspn(a->tipo, "\n")] = '\0';

        printf("Ingrese el nombre del animal: ");
        fgets(a->nombre, sizeof(a->nombre), stdin);
        a->nombre[strcspn(a->nombre, "\n")] = '\0';

        printf("Ingrese la edad del animal: ");
        scanf("%d", &a->edad);
        getchar();

        printf("Ingrese el nombre del dueño: ");
        fgets(a->duenio, sizeof(a->duenio), stdin);
        a->duenio[strcspn(a->duenio, "\n")] = '\0';

        printf("\n--- Datos del animal ---\n");
        printf("Tipo: %s\n", a->tipo);
        printf("Nombre: %s\n", a->nombre);
        printf("Edad: %d\n", a->edad);
        printf("Dueño: %s\n", a->duenio);

        free(a);

        return 0;
}