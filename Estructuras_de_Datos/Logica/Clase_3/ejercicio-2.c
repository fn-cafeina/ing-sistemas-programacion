// Se tiene la siguiente declaración de registro:

#include <stdio.h>
#include <string.h>
#include <stdlib.h>

struct producto
{
        int codigo;
        char descripcion[41];
        float precio;
};

int main()
{
        struct producto *prod;
        int cantidad, i;

        printf("Cuantos productos desea guardar?: ");
        scanf("%i", &cantidad);

        while (getchar() != '\n')
                ;

        prod = (struct producto *)malloc(cantidad * sizeof(struct producto));
        if (prod == NULL)
        {
                printf("Error: No se pudo asignar memoria.\n");
                return 1;
        }

        for (i = 0; i < cantidad; i++)
        {
                printf("\n--- Producto %d ---\n", i + 1);
                printf("Ingrese el codigo: ");
                scanf("%i", &prod[i].codigo);

                while (getchar() != '\n')
                        ;

                printf("Ingrese la descripcion: ");
                fgets(prod[i].descripcion, sizeof(prod[i].descripcion), stdin);
                prod[i].descripcion[strcspn(prod[i].descripcion, "\n")] = 0;

                printf("Ingrese el precio: ");
                scanf("%f", &prod[i].precio);

                while (getchar() != '\n')
                        ;
        }

        printf("\n--- Listado de Productos ---\n");
        for (i = 0; i < cantidad; i++)
        {
                printf("\nProducto %d:\n", i + 1);
                printf("Codigo: %i\n", prod[i].codigo);
                printf("Descripcion: %s\n", prod[i].descripcion);
                printf("Precio: %.2f\n", prod[i].precio);
        }

        free(prod);

        return 0;
}

// Actividad 2: El ejercicio anterior guarda la información de un producto, realice una
// modificación al ejercicio para que pregunte al usuario cuantos productos desea guardar y
// lea e imprima los datos de todos los productos.