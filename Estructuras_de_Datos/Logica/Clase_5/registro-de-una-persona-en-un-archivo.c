// Crear una estructura que almacene los siguientes datos de una persona: nombre, edad, ciudad de
// residencia. Pedir al usuario esos datos de la persona y guardarlos en un fichero llamado “gente.dat”.
// Cerrar el fichero, volverlo a abrir para lectura y mostrar los datos que se habían guardado.

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX 21 // Tamaño máximo para nombre y ciudad

struct datos
{
        char nombre[MAX];
        int edad;
        char ciudad[MAX];
};

int main()
{
        struct datos persona;
        FILE *fichero;

        // Abrir archivo para escritura
        fichero = fopen("gente.dat", "w");
        if (fichero == NULL)
        {
                printf("Error al abrir el archivo.\n");
                return 1;
        }

        // Entrada de datos
        printf("Nombre: ");
        fgets(persona.nombre, MAX, stdin);
        persona.nombre[strcspn(persona.nombre, "\n")] = '\0';

        printf("Edad: ");
        scanf("%d", &persona.edad);
        getchar(); // Limpiar buffer

        printf("Ciudad: ");
        fgets(persona.ciudad, MAX, stdin);
        persona.ciudad[strcspn(persona.ciudad, "\n")] = '\0';

        // Guardar en archivo
        fprintf(fichero, "%s\n%d\n%s\n", persona.nombre, persona.edad, persona.ciudad);
        fclose(fichero);

        // Leer desde archivo
        fichero = fopen("gente.dat", "r");
        if (fichero == NULL)
        {
                printf("Error al abrir el archivo.\n");
                return 1;
        }

        fgets(persona.nombre, MAX, fichero);
        persona.nombre[strcspn(persona.nombre, "\n")] = '\0';
        fscanf(fichero, "%d\n", &persona.edad);
        fgets(persona.ciudad, MAX, fichero);
        persona.ciudad[strcspn(persona.ciudad, "\n")] = '\0';

        // Mostrar datos
        printf("\nDatos leídos:\n");
        printf("Nombre: %s\n", persona.nombre);
        printf("Edad: %d\n", persona.edad);
        printf("Ciudad: %s\n", persona.ciudad);

        fclose(fichero);
        return 0;
}
