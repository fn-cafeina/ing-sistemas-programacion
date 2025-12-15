// La pizzería Bella Valenty ofrece pizzas vegetarianas y no vegetarianas a sus clientes.
// Los ingredientes para cada tipo de pizza aparecen a continuación.
//
// - Ingredientes vegetarianos: Pimiento y tofu.
// - Ingredientes no vegetarianos: Peperoni, Jamón y Salmón.
//
// Escribir un programa que pregunte al usuario si quiere una pizza vegetariana o no,
// y en función de su respuesta le muestre un menú con los ingredientes disponibles para que elija.
// Solo se puede eligir un ingrediente además de la mozzarella y el tomate que están en todas la pizzas.
// Al final se debe mostrar por pantalla si la pizza elegida es vegetariana o no y
// todos los ingredientes que lleva.

#include <stdio.h>
#include <stdlib.h>

void limpiarPantalla()
{
        if (system("cls"))
                system("clear");
}

int main()
{
        limpiarPantalla();

        int opcion, opcion1, opcion2;

        printf("Ingrese que tipo de pizza quiere:\n1 - Normal\n2 - Vegetariana\nR = ");
        scanf("%d", &opcion);

        limpiarPantalla();

        if (opcion == 1)
        {
                printf("Que ingredientes quiere en su pizza?\n1 - Peperoni\n2 - Jamón\n3 - Salmón\nR = ");
                scanf("%d", &opcion1);

                limpiarPantalla();

                switch (opcion1)
                {
                case 1:
                        printf("\nPizza normal con Peperoni, mozzarella y el tomate.\n");
                        break;
                case 2:
                        printf("\nPizza normal con Jamón, mozzarella y el tomate.\n");
                        break;
                case 3:
                        printf("\nPizza normal con Salmón, mozzarella y el tomate.\n");
                        break;

                default:
                        printf("\nPizza normal sin ingredientes extras.\n");
                        break;
                }
        }
        else if (opcion == 2)
        {
                printf("Que ingredientes quiere en su pizza?\n1 - Pimiento\n2 - Tofu\nR = ");
                scanf("%d", &opcion2);

                limpiarPantalla();

                switch (opcion2)
                {
                case 1:
                        printf("\nPizza vegetariana con Pimiento, mozzarella y el tomate.\n");
                        break;
                case 2:
                        printf("\nPizza vegetariana con Tofu, mozzarella y el tomate.\n");
                        break;
                default:
                        printf("\nPizza vegetariana sin ingredientes extras.\n");
                        break;
                }
        }
        else
        {
                limpiarPantalla();
                printf("\nTipo de pizza no disponible.\n");
        }

        return 0;
}