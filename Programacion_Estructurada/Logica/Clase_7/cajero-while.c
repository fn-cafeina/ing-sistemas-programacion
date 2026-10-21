// A lo largo de un día un cajero procesa a las personas que llegan a efectuar movimientos
// bancarios. Estos movimientos son esencialmente depósitos y retiros. Determinar la
// cantidad total de dinero obtenido por concepto de depósitos y retiros en todo el día, lo
// mismo que un balance que indique si hubo más retiros que consignaciones.

#include <stdio.h>
#include <stdlib.h>

void limpiarPantalla()
{
        if (system("cls"))
                system("clear");
}

int main()
{
        int cr = 0, cs = 0;
        float dineroTotal = 0;
        int accion = -1;

        while (accion != 2)
        {
                printf("¿Qué acción quiere realizar?\n0 - Depósito\n1 - Retiro\n2 - Nada, salir\nR = ");
                scanf("%d", &accion);

                limpiarPantalla();

                float dinero = 0;

                if (accion == 0)
                {
                        printf("=== Efectuando depósito ===\nCantidad de dinero a depositar: ");
                        scanf("%f", &dinero);
                        dineroTotal += dinero;
                        cs++;
                        limpiarPantalla();
                }
                else if (accion == 1)
                {
                        printf("=== Efectuando retiro ===\nCantidad de dinero a retirar: ");
                        scanf("%f", &dinero);
                        dineroTotal -= dinero;
                        cr++;
                        limpiarPantalla();
                }
        }

        printf("Dinero total: %.2f\nDepósitos: %d\nRetiros: %d\n", dineroTotal, cs, cr);

        if (cs || cr)
        {
                if (cs > cr)
                        printf("Hubo más depósitos\n");
                else if (cr > cs)
                        printf("Hubo más retiros\n");
                else
                        printf("Depósitos y retiros fueron iguales\n");
        }
        else
        {
                printf("No hubo depósitos ni retiros\n");
        }

        return 0;
}
