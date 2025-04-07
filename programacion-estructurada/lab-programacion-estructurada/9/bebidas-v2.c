// Bebidas

#include <stdio.h>
#include <stdlib.h>

int main()
{
        if (system("cls"))
        {
                system("clear");
        }

        int opcion;
        char moneda[99];

        printf("Menú de bebidas\n");
        printf("Bebida          Precio\n");
        printf("1 - Café        10C$\n");
        printf("2 - Agua        15C$\n");
        printf("3 - Coca Cola   20C$\n");
        printf("4 - Fresca      20C$\n");
        printf("5 - Fanta       25C$\n");

        printf("\nIngrese el número de bebida que quiere: ");
        scanf("%d", &opcion);

        printf("\nIngrese la moneda con la que pagará: ");
        scanf("%s", moneda);

        switch (opcion)
        {
        case 1:
                printf("\nSu bebida es Café y vale 10 %s\n", moneda);
                break;
        case 2:
                printf("\nSu bebida es Agua y vale 15 %s\n", moneda);
                break;
        case 3:
                printf("\nSu bebida es Coca Cola y vale 20 %s\n", moneda);
                break;
        case 4:
                printf("\nSu bebida es Fresca y vale 20 %s\n", moneda);
                break;
        case 5:
                printf("\nSu bebida es Fanta y vale 25 %s\n", moneda);
                break;
        default:
                printf("\nOpción no valida.\n");
                exit(0);
        }

        return 0;
}