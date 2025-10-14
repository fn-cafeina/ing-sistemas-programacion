/*
        Modificar el ejercicio anterior, añadiendo la siguiente funcionalidad:
        - Ventas de un producto: Se debe actualizar los que correspondan, y verifique que
        la nueva existencia no esté por debajo del mínimo (Datos: clave, cantidad
        vendida).
        - Reabastecimiento de un producto: Se deben actualizar los campos que
        correspondan. (Datos: Clave, Cantidad comprada).
        - Información sobre el producto: Se deben proporcionar todos los datos
        relacionados a un producto. (Dato: Clave).
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MIN_EXISTENCIA 5 // Constante para la existencia mínima permitida.

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
void VenderProducto(Lista cab);
void ReabastecerProducto(Lista cab);
void InformacionProducto(Lista cab);
pNodo BuscarProducto(Lista cab, int clave); // Función clave para reutilizar código.
void menu();

int main()
{
        Lista inventario = NULL;
        int opcion;

        do
        {
                menu();
                scanf("%d", &opcion);
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
                        VenderProducto(inventario);
                        break;
                case 4:
                        ReabastecerProducto(inventario);
                        break;
                case 5:
                        InformacionProducto(inventario);
                        break;
                case 6:
                        printf("  [!] Saliendo...\n");
                        BorrarInventario(&inventario);
                        break;
                default:
                        printf("  [!] Opcion no valida.\n");
                }
        } while (opcion != 6);

        return 0;
}

void menu()
{
        printf("\n======= GESTION DE INVENTARIO v2.0 =======\n");
        printf(" 1. Agregar un nuevo producto\n");
        printf(" 2. Mostrar inventario completo\n");
        printf(" 3. Vender un producto\n");
        printf(" 4. Reabastecer un producto\n");
        printf(" 5. Buscar informacion de un producto\n");
        printf(" 6. Salir\n");
        printf("==========================================\n");
        printf(" Seleccione una opcion: ");
}

// Función auxiliar: busca un producto por su clave y devuelve un puntero al nodo.
// Si no lo encuentra, devuelve NULL.
pNodo BuscarProducto(Lista cab, int clave)
{
        while (cab)
        {
                if (cab->clave == clave)
                {
                        return cab; // Se encontró el producto.
                }
                cab = cab->sig;
        }
        return NULL; // No se encontró.
}

// Procesa la venta de un producto, actualizando su existencia.
void VenderProducto(Lista cab)
{
        int clave, cantidad;
        printf("\n--- Venta de Producto ---\n");
        printf("  Clave del producto a vender: ");
        scanf("%d", &clave);

        pNodo p = BuscarProducto(cab, clave);

        if (p)
        { // Si el producto fue encontrado...
                printf("  > Producto: %s | Existencia actual: %d\n", p->descripcion, p->existencia);
                printf("  Cantidad a vender: ");
                scanf("%d", &cantidad);

                // Lógica de negocio: verifica que la existencia no baje del mínimo permitido.
                if (p->existencia - cantidad >= MIN_EXISTENCIA)
                {
                        p->existencia -= cantidad;
                        printf("  [!] Venta exitosa. Nueva existencia: %d\n", p->existencia);
                }
                else
                {
                        printf("  [!] Error: Existencia insuficiente para realizar la venta.\n");
                }
        }
        else
        {
                printf("  [!] Error: Producto con clave %d no encontrado.\n", clave);
        }
}

// Aumenta la existencia de un producto.
void ReabastecerProducto(Lista cab)
{
        int clave, cantidad;
        printf("\n--- Reabastecer Inventario ---\n");
        printf("  Clave del producto: ");
        scanf("%d", &clave);

        pNodo p = BuscarProducto(cab, clave);

        if (p)
        {
                printf("  > Producto: %s\n", p->descripcion);
                printf("  Cantidad a agregar: ");
                scanf("%d", &cantidad);

                p->existencia += cantidad;
                printf("  [!] Reabastecimiento exitoso. Nueva existencia: %d\n", p->existencia);
        }
        else
        {
                printf("  [!] Error: Producto con clave %d no encontrado.\n", clave);
        }
}

// Muestra toda la información de un producto específico.
void InformacionProducto(Lista cab)
{
        int clave;
        printf("\n--- Informacion de Producto ---\n");
        printf("  Clave del producto a buscar: ");
        scanf("%d", &clave);

        pNodo p = BuscarProducto(cab, clave);

        if (p)
        {
                printf("\n  [+] Detalles del Producto encontrado:\n");
                printf("    Clave: %d\n", p->clave);
                printf("    Producto: %s\n", p->descripcion);
                printf("    Existencia: %d unidades\n", p->existencia);
                printf("    Precio: $%.2f\n", p->precio);
        }
        else
        {
                printf("  [!] Error: Producto con clave %d no encontrado.\n", clave);
        }
}

/* Las siguientes funciones (AgregarProducto, MostrarInventario, BorrarInventario)
   son necesarias para que el programa compile y funcione, pero su código es
   idéntico al del Ejercicio 2.
*/
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
        nuevo->descripcion[strcspn(nuevo->descripcion, "\n")] = 0;
        printf("  Existencia inicial: ");
        scanf("%d", &nuevo->existencia);
        printf("  Precio: ");
        scanf("%f", &nuevo->precio);
        nuevo->ant = NULL;
        nuevo->sig = *cab;
        if (*cab != NULL)
        {
                (*cab)->ant = nuevo;
        }
        *cab = nuevo;
        printf("  [!] Producto agregado correctamente.\n");
}

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
                printf("  Clave: %-5d | Producto: %-30s | Existencia: %-5d | Precio: $%.2f\n", cab->clave, cab->descripcion, cab->existencia, cab->precio);
                cab = cab->sig;
        }
        printf("---------------------------------------------------\n");
}

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