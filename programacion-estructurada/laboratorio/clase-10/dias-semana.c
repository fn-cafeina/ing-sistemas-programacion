// Dias de la semana

#include <stdio.h>
#include <stdlib.h>

int main()
{
        if (system("cls"))
                system("clear");

        int opcion;

        printf("Ingrese el dia de la semana (1, 2, 3, 4, 5, 6, 7): ");
        scanf("%d", &opcion);

        switch (opcion)
        {
        case 1:
                printf("\nEl dia 1 es Lunes\n");
                break;
        case 2:
                printf("\nEl dia 2 es Martes\n");
                break;

        case 3:
                printf("\nEl dia 3 es Miercoles\n");
                break;

        case 4:
                printf("\nEl dia 4 es Jueves\n");
                break;

        case 5:
                printf("\nEl dia 5 es Viernes\n");
                break;

        case 6:
                printf("\nEl dia 6 es Sabado\n");
                break;

        case 7:
                printf("\nEl dia 7 es Domingo\n");
                break;

        default:
                printf("\n Opción invalida.\n");
                exit(0);
        }

        return 0;
}