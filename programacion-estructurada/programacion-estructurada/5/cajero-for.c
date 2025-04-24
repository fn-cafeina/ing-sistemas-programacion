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

        for (;;)
        {
                int accion;
                printf("¿Que acción quiere realizar?\n0 - Depósito\n1 - Retiro\n2 - Nada, salir\nR = ");
                scanf("%d", &accion);

                limpiarPantalla();

                float dinero = 0;
                if (accion == 0)
                {
                        printf("=== Efectuando deposito ===\nCantidad de dinero a depositar: ");
                        scanf("%f", &dinero);
                        dineroTotal += dinero;
                        cs++;
                        limpiarPantalla();
                }
                else
                {
                        if (accion == 1)
                        {
                                printf("=== Efectuando retiro ===\nCantidad de dinero a retirar: ");
                                scanf("%f", &dinero);
                                dineroTotal -= dinero;
                                cr++;
                                limpiarPantalla();
                        }
                        else
                        {
                                break;
                                limpiarPantalla();
                        }
                }
        }

        printf("Dinero total: %.2f\nDepositos: %d\nRetiros: %d\n", dineroTotal, cs, cr);

        if (cs || cr)
        {
                if (cs > cr)
                        printf("Hubo mas depósitos\n");
                else
                        printf("Hubo mas retiros\n");
        }
        else
                printf("No hubo depositos ni retiros\n");

        return 0;
}