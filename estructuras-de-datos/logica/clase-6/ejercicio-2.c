// Escribir un programa que pida al usuario un número
// entero y muestre por pantalla un triángulo rectángulo
// como el de más abajo, y se almacene en un archivo binario .dat

#include <stdio.h>
int main()
{
        int num, i, j, impar;

        printf("ingrese un numero entero ");
        scanf("%d", &num);

        FILE *binario = NULL;
        binario = fopen("binario.dat", "wb");
        if (binario == NULL)
        {
                printf("Error al abrir el archivo\n\n");
                return 1;
        }

        for (i = 1; i <= num; i++)
        {
                for (j = i; j >= 1; j--)
                {
                        impar = 2 * j - 1;
                        printf("%d ", impar);
                        fprintf(binario, "%d", impar);
                }
                printf("\n");
                fprintf(binario, "\n");
        }
        fclose(binario);
        printf("\nTriángulo guardado en 'binario.dat'.\n");

        return 0;
}
