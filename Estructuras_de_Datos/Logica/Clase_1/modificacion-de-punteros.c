/*
    Archivo: medina_jasmir_ej1.c
    Ejercicio 1: Manipulación de Variables con Punteros
*/

#include <stdio.h>

int main()
{
        int a = 5, b = 10; // Declaración de variables
        int *p;            // Declaración de puntero

        // Antes de modificar
        printf("Antes de modificar:\n");
        printf("Variable a: valor = %d, direccion = %p\n", a, (void *)&a); // & obtiene la dirección
        printf("Variable b: valor = %d, direccion = %p\n", b, (void *)&b);

        // Modificamos usando puntero
        p = &a;  // & obtiene dirección de a
        *p = 15; // * desreferencia y cambia el valor apuntado (a = 15)

        p = &b;  // & obtiene dirección de b
        *p = 20; // * desreferencia y cambia el valor apuntado (b = 20)

        // Después de modificar
        printf("\nDespues de modificar:\n");
        printf("Variable a: valor = %d, direccion = %p\n", a, (void *)&a);
        printf("Variable b: valor = %d, direccion = %p\n", b, (void *)&b);

        return 0;
}

/*
    Nota Técnica:
    Un error común con punteros es desreferenciar un puntero no inicializado.
    Esto puede causar acceso a direcciones inválidas y fallos de segmentación.
    Para evitarlo, siempre se debe asignar una dirección válida antes de usar *p.
*/
