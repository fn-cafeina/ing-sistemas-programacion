// Escribir un programa que pregunte al usuario una cantidad a invertir,
// el interés anual y el número de años,
// y muestre por pantalla el capital obtenido en la inversión cada año que dura la inversión,
// almacenarlo en un archivo de texto .txt

#include <stdio.h>

int main()
{
        float cantidad_inversion, interes_anual;
        int numero_anyos;

        printf("Ingrese la cantidad a invertir: ");
        scanf("%f", &cantidad_inversion);

        printf("Ingrese el interés anual (en porcentaje, ej. 5 para 5%%): ");
        scanf("%f", &interes_anual);

        printf("Ingrese el número de años: ");
        scanf("%d", &numero_anyos);

        FILE *fp = fopen("texto.txt", "w");
        if (!fp)
        {
                perror("Error al abrir el archivo");
                return 1;
        }

        fprintf(fp, "Resumen de inversión:\n");
        fprintf(fp, "Monto inicial: %.2f\n", cantidad_inversion);
        fprintf(fp, "Interés anual: %.2f%%\n", interes_anual);
        fprintf(fp, "Duración: %d años\n\n", numero_anyos);

        printf("\nCapital acumulado cada año:\n");

        float capital = cantidad_inversion;
        for (int i = 1; i <= numero_anyos; i++)
        {
                capital += capital * (interes_anual / 100.0f);
                printf("Año %d: %.2f\n", i, capital);
                fprintf(fp, "Año %d: %.2f\n", i, capital);
        }

        fclose(fp);
        return 0;
}
