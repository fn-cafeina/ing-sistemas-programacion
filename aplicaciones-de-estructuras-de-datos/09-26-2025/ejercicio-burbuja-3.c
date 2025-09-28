// Escribe 4 programas en C utilizando el método burbuja, el ejercicio puede ser de su elección.

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define CANTIDAD_PERSONAS 5
#define MAX_NOMBRE 30

typedef struct
{
        char nombre[MAX_NOMBRE];
        int edad;
} Persona;

void bubble_sort_personas(Persona *, size_t);
void imprimir_personas(Persona *, size_t);

int main()
{
        Persona personas[CANTIDAD_PERSONAS] = {
            {"Ana", 25},
            {"Luis", 19},
            {"Carla", 32},
            {"Jorge", 21},
            {"Marta", 27}};

        printf("Lista original:\n");
        imprimir_personas(personas, CANTIDAD_PERSONAS);

        bubble_sort_personas(personas, CANTIDAD_PERSONAS);

        printf("\nLista ordenada por edad (ascendente):\n");
        imprimir_personas(personas, CANTIDAD_PERSONAS);

        return 0;
}

void bubble_sort_personas(Persona *array, size_t n)
{
        for (size_t i = 0; i < n - 1; i++)
        {
                for (size_t j = 0; j < n - 1 - i; j++)
                {
                        if (array[j].edad > array[j + 1].edad)
                        {
                                Persona temp = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = temp;
                        }
                }
        }
}

void imprimir_personas(Persona *array, size_t n)
{
        for (size_t i = 0; i < n; i++)
        {
                printf("%zu. %s - %d años\n", i + 1, array[i].nombre, array[i].edad);
        }
}
