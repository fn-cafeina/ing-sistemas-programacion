// Caluladora

#include <stdio.h>
#include <stdlib.h>

void limpiarBuffer()
{
        while (getchar() != '\n')
                ;
}

int main()
{
        if (system("cls"))
                system("clear");

        int n1, n2, operacion;
        float resultado;

        printf("Ingrese 2 números:\n");
        scanf("%d%d", &n1, &n2);

        limpiarBuffer();

        printf("\nIngrese la operación a efectuar (+, -, *, /): ");
        operacion = getchar();

        switch (operacion)
        {
        case '+':
                resultado = n1 + n2;
                break;
        case '-':
                resultado = n1 - n2;
                break;
        case '*':
                resultado = n1 * n2;
                break;
        case '/':
                if (n1 == 0 || n2 == 0)
                {
                        printf("\nNo se puede dividir por cero.\n");
                        exit(0);
                }
                else
                        resultado = n1 / n2;
                break;
        default:
                printf("Operación no valida.\n");
                exit(0);
        }

        printf("\nResultado: %d %c %d = %.2f\n", n1, operacion, n2, resultado);

        return 0;
}