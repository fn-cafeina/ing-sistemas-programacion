/*
        Una compañía distribuye productos a distintos comercios de la cuidad. La información
        suministrada de los productos es la siguiente:

        - Clave.
        - Descripción.
        - Existencia (valor mínimo: 5).
        - Precio Unitario.

        Elabore un programa que permita implementar las operaciones básicas de una lista
        doblemente enlazada.
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Estructura para almacenar los datos de un producto.
struct producto
{
        int clave;
        char descripcion[100];
        int existencia;
        float precio;
        struct producto *sig, *ant;
};

typedef struct producto *pNodo, *Lista;

void AgregarProducto(Lista *cab);
void MostrarInventario(Lista cab);
void BorrarInventario(Lista *cab);
void menu();

int main()
{
        Lista inventario = NULL;
        int opcion;

        do
        {
                menu();
                scanf("%d", &opcion);
                // Limpia el buffer de entrada para evitar problemas con fgets.
                getchar();

                switch (opcion)
                {
                case 1:
                        AgregarProducto(&inventario);
                        break;
                case 2:
                        MostrarInventario(inventario);
                        break;
                case 3:
                        printf("  [!] Saliendo...\n");
                        BorrarInventario(&inventario);
                        break;
                default:
                        printf("  [!] Opcion no valida.\n");
                }
        } while (opcion != 3);

        return 0;
}

void menu()
{
        printf("\n======= GESTION DE INVENTARIO =======\n");
        printf(" 1. Agregar un nuevo producto\n");
        printf(" 2. Mostrar inventario completo\n");
        printf(" 3. Salir\n");
        printf("=====================================\n");
        printf(" Seleccione una opcion: ");
}

// Pide los datos de un producto y lo añade al inicio de la lista.
void AgregarProducto(Lista *cab)
{
        pNodo nuevo = (pNodo)malloc(sizeof(struct producto));
        if (!nuevo)
        {
                exit(1);
        }

        printf("\n--- Nuevo Producto ---\n");
        printf("  Clave: ");
        scanf("%d", &nuevo->clave);
        getchar();
        printf("  Descripcion: ");
        fgets(nuevo->descripcion, 100, stdin);
        // Elimina el salto de línea que fgets agrega al final.
        nuevo->descripcion[strcspn(nuevo->descripcion, "\n")] = 0;
        printf("  Existencia inicial: ");
        scanf("%d", &nuevo->existencia);
        printf("  Precio: ");
        scanf("%f", &nuevo->precio);

        // La lógica para insertar al inicio es la misma que en el Ejercicio 1.
        nuevo->ant = NULL;
        nuevo->sig = *cab;
        if (*cab != NULL)
        {
                (*cab)->ant = nuevo;
        }
        *cab = nuevo;
        printf("  [!] Producto agregado correctamente.\n");
}

// Muestra todos los productos del inventario.
void MostrarInventario(Lista cab)
{
        if (!cab)
        {
                printf("\n  [!] El inventario esta vacio.\n");
                return;
        }

        printf("\n---------------- INVENTARIO ACTUAL ----------------\n");
        while (cab)
        {
                printf("  Clave: %d\n", cab->clave);
                printf("  Producto: %s\n", cab->descripcion);
                printf("  Existencia: %d unidades\n", cab->existencia);
                printf("  Precio: $%.2f\n", cab->precio);
                printf("  -----------------------------------------------\n");
                cab = cab->sig;
        }
}

// Libera la memoria de todo el inventario.
void BorrarInventario(Lista *cab)
{
        pNodo actual;
        while (*cab != NULL)
        {
                actual = *cab;
                *cab = actual->sig;
                free(actual);
        }
        printf("  [!] Inventario borrado.\n");
}