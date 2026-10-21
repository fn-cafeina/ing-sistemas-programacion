// Desarrolle un arreglo dinámico de estructura para un programa que lea una lista de
// alumnos y las notas correspondientes a una determinada asignatura; el resultado será
// el tanto por ciento (porcentaje) de los alumnos aprobados y reprobados.

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
        char *nombre; // Puntero a char para el nombre del alumno
        float nota;
} Alumno;

// Función para crear un nuevo alumno
// Esta función debe asignar memoria para la estructura Alumno y luego asigna
// memoria adicional para el nombre, copiando el nombre dado al puntero nombre del
// alumno.
Alumno *crearAlumno(const char *nombre, float nota)
{
        Alumno *nuevoAlumno = malloc(sizeof(Alumno));

        if (nuevoAlumno != NULL)
        {
                nuevoAlumno->nombre = malloc(strlen(nombre) + 1);

                if (nuevoAlumno->nombre != NULL)
                {
                        strcpy(nuevoAlumno->nombre, nombre);
                }

                nuevoAlumno->nota = nota;
        }

        return nuevoAlumno;
}

// Función para calcular el porcentaje de aprobados y reprobados
// Recibe un arreglo de punteros a Alumno, la cantidad de alumnos, y punteros a las
// variables que almacenarán los porcentajes de aprobados y reprobados.
void calcularPorcentaje(Alumno **alumnos, int cantidadAlumnos, float *porcentajeAprobados, float *porcentajeReprobados)
{
        int aprobados = 0, i;
        for (i = 0; i < cantidadAlumnos; i++)
        { // Verificar la nota de cada alumno para que esta sea superior o igual a 60 y tener los aprobados.
                if (alumnos[i]->nota >= 60)
                {
                        aprobados++;
                }
        }

        // Calcular porcentaje de aprobados y reprobados
        *porcentajeAprobados = (float)aprobados / cantidadAlumnos * 100;
        *porcentajeReprobados = 100.0 - *porcentajeAprobados;
}

int main()
{
        int cantidadAlumnos, i;
        char nombre[50];
        float nota;

        // Variables para almacenar los porcentajes
        float porcentajeAprobados = 0.0;
        float porcentajeReprobados = 0.0;

        // Solicitar la cantidad de alumnos
        printf("Ingrese la cantidad de alumnos: ");
        scanf("%d", &cantidadAlumnos);

        // Asignación dinámica de memoria para los punteros a alumnos
        Alumno **alumnos = malloc(cantidadAlumnos * sizeof(Alumno *));

        // Verificación de que la memoria fue asignada correctamente
        if (alumnos == NULL)
        {
                printf("Error al asignar memoria.\n");
                return 1;
        }

        // Ingresar la información de cada alumno
        for (i = 0; i < cantidadAlumnos; i++)
        {
                printf("Alumno %d:\n", i + 1);
                printf("Nombre: ");
                scanf("%s", nombre);
                printf("Nota: ");
                scanf("%f", &nota);

                // Crear el alumno y asignarlo al arreglo de punteros
                alumnos[i] = crearAlumno(nombre, nota);

                // Verificación de que el alumno fue creado correctamente
                if (alumnos[i] == NULL)
                {
                        printf("Error: No se pudo asignar memoria.\n");
                        return 1;
                }
        }

        // Calcular los porcentajes
        calcularPorcentaje(alumnos, cantidadAlumnos, &porcentajeAprobados, &porcentajeReprobados);

        // Mostrar los resultados
        printf("Porcentaje de alumnos aprobados: %.2f%%\n", porcentajeAprobados);
        printf("Porcentaje de alumnos reprobados: %.2f%%\n", porcentajeReprobados);

        // Liberar la memoria asignada para cada alumno y el arreglo de punteros
        for (i = 0; i < cantidadAlumnos; i++)
        {
                free(alumnos[i]->nombre); // Liberar la memoria del nombre
                free(alumnos[i]);         // Liberar la memoria del alumno
        }

        free(alumnos);
        return 0;
}