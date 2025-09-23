// Ampliar el programa anterior para que use un “array de estructuras”, de forma que se puedan tener
// datos de 10 personas. Se deberá pedir al usuario los datos de estas personas y guardarlos en el
// fichero. Después se pedirá al usuario un número del 1 al 10 y se mostrarán los datos de la persona
// indicada por ese número, que se deberán leer del fichero (1 será la primera ficha, y 10 será la
// última). Por ejemplo, si el usuario indica que quiere ver los datos de la persona 3 (tercera), se deberá
// leer las dos primeras, ignorando su contenido, y después leer la tercera, que sí se deberá mostrar.

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX 21
#define TOTAL 10

struct datos
{
        char nombre[MAX];
        int edad;
        char ciudad[MAX];
};

int main()
{
        struct datos personas[TOTAL];
        FILE *fichero;
        int i, seleccion;

        // Entrada de datos para 10 personas
        for (i = 0; i < TOTAL; i++)
        {
                printf("\nPersona %d\n", i + 1);

                printf("Nombre: ");
                fgets(personas[i].nombre, MAX, stdin);
                personas[i].nombre[strcspn(personas[i].nombre, "\n")] = '\0';

                printf("Edad: ");
                scanf("%d", &personas[i].edad);
                getchar(); // Limpiar buffer

                printf("Ciudad: ");
                fgets(personas[i].ciudad, MAX, stdin);
                personas[i].ciudad[strcspn(personas[i].ciudad, "\n")] = '\0';
        }

        // Guardar en archivo en formato binario
        fichero = fopen("gente.dat", "wb");
        if (fichero == NULL)
        {
                printf("Error al abrir el archivo para escritura.\n");
                return 1;
        }

        fwrite(personas, sizeof(struct datos), TOTAL, fichero);
        fclose(fichero);

        // Selección de persona a consultar
        printf("\nIngrese un número del 1 al 10 para ver los datos de esa persona: ");
        scanf("%d", &seleccion);

        if (seleccion < 1 || seleccion > TOTAL)
        {
                printf("Número fuera de rango.\n");
                return 1;
        }

        // Leer solo la persona seleccionada desde el archivo
        fichero = fopen("gente.dat", "rb");
        if (fichero == NULL)
        {
                printf("Error al abrir el archivo para lectura.\n");
                return 1;
        }

        // Mover el puntero al registro deseado
        fseek(fichero, (seleccion - 1) * sizeof(struct datos), SEEK_SET);

        struct datos persona;
        fread(&persona, sizeof(struct datos), 1, fichero);
        fclose(fichero);

        // Mostrar los datos
        printf("\nDatos de la persona %d:\n", seleccion);
        printf("Nombre: %s\n", persona.nombre);
        printf("Edad: %d\n", persona.edad);
        printf("Ciudad: %s\n", persona.ciudad);

        return 0;
}
