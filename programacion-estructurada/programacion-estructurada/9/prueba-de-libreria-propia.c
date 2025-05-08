#include <stdio.h>
#include <cafeina.h>

int main()
{
        int opcion, num1, num2, numero;

        do
        {
                limpiarConsola();

                printf("=== MENÚ DE CAFEINA ===\n");
                printf("1. Sumar dos números\n");
                printf("2. Restar dos números\n");
                printf("3. Multiplicar dos números\n");
                printf("4. Verificar número Fibonacci\n");
                printf("0. Salir\n\n");
                printf("Seleccione una opción: ");

                if (scanf("%d", &opcion) != 1)
                {
                        printf("Entrada inválida.\n");
                        limpiarBuffer();
                        continue;
                }

                limpiarBuffer();

                switch (opcion)
                {
                case 1:
                        printf("\nIngrese dos números para sumar: ");
                        scanf("%d %d", &num1, &num2);
                        printf("Resultado: %d + %d = %d\n", num1, num2, sumar(num1, num2));
                        limpiarBuffer();
                        break;

                case 2:
                        printf("\nIngrese dos números para restar: ");
                        scanf("%d %d", &num1, &num2);
                        printf("Resultado: %d - %d = %d\n", num1, num2, restar(num1, num2));
                        limpiarBuffer();
                        break;

                case 3:
                        printf("\nIngrese dos números para multiplicar: ");
                        scanf("%d %d", &num1, &num2);
                        printf("Resultado: %d * %d = %d\n", num1, num2, multiplicar(num1, num2));
                        limpiarBuffer();
                        break;

                case 4:
                        printf("\nIngrese un número para verificar Fibonacci: ");
                        scanf("%d", &numero);

                        if (esFibonacci(numero))
                                printf("%d es un número Fibonacci.\n", numero);
                        else
                                printf("%d no es un número Fibonacci.\n", numero);

                        limpiarBuffer();
                        break;

                case 0:
                        printf("\nSaliendo...\n");
                        break;

                default:
                        printf("\nOpción inválida.\n");
                }

                if (opcion != 0)
                {
                        printf("\nPresiona Enter para continuar...");
                        limpiarBuffer();
                }

        } while (opcion != 0);

        return 0;
}