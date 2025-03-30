// Calcular el número de pulsaciones que debe tener una persona por cada 10
// segundos de ejercicio aeróbico; la fórmula que se aplica cuando el sexo es
// femenino es: num_pulsaciones=(220-edad)/10 y si el sexo es masculino:
// num_pulsaciones=(210-edad)/10.

#include <stdio.h>
#include <string.h>
#include <ctype.h>

int main()
{
        char sexo[10];
        int edad;

        printf("Ingrese su sexo (Femenino o Masculino): ");
        scanf("%s", sexo);

        printf("Ingrese su edad: ");
        scanf("%d", &edad);

        for (int i = 0; sexo[i]; i++)
                sexo[i] = tolower(sexo[i]);

        if (strcmp(sexo, "masculino") == 0)
                printf("Su sexo es: %s y su numero de pulsaciones es de: %.2f\n", sexo, (float)(210 - edad) / 10);
        else if (strcmp(sexo, "femenino") == 0)
                printf("Su sexo es: %s y su numero de pulsaciones es de: %.2f\n", sexo, (float)(220 - edad) / 10);
        else
                printf("Sexo desconocido.\n");

        return 0;
}