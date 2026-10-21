// Bebidas

#include <stdio.h>
#include <stdlib.h>

int main()
{
        if (system("cls"))
                system("clear");

        int opcion;

        printf("Menú de bebidas\n");
        printf("Bebida          Precio\n");
        printf("1 - Café        10C$\n");
        printf("2 - Agua        15C$\n");
        printf("3 - Coca Cola   20C$\n");
        printf("4 - Fresca      20C$\n");
        printf("5 - Fanta       25C$\n");

        printf("\nIngrese el número de bebida que quiere: ");
        scanf("%d", &opcion);

        switch (opcion)
        {
        case 1:
                printf("\nSu bebida es Café y vale 10C$\n");
                break;
        case 2:
                printf("\nSu bebida es Agua y vale 15C$\n");
                break;
        case 3:
                printf("\nSu bebida es Coca Cola y vale 20C$\n");
                break;
        case 4:
                printf("\nSu bebida es Fresca y vale 20C$\n");
                break;
        case 5:
                printf("\nSu bebida es Fanta y vale 25C$\n");
                break;
        default:
                printf("\nOpción no valida.\n");
                exit(0);
        }

        return 0;
}