// Una oficina de seguros ha reunido datos concernientes a todos los accidentes de tránsito
// ocurridos en el área metropolitana de Medellín en el último año. Por cada conductor
// involucrado en un accidente se toman los siguientes datos: año de nacimiento, sexo(1:
// Femenino, 2: Masculino), registro del carro(1: Medellín, 2: Otras ciudades). Hacer un
// programa en C que muestre:
// • El porcentaje de conductores menores de 25 años.
// • Porcentaje de conductores del sexo femenino.
// • Porcentaje de conductores masculinos con edades entre 12 y 30 años.
// • Porcentaje de conductores cuyos carros están registrados fuera de Medellín.

#include <stdio.h>
#include <stdlib.h>

int main()
{
        int n, i;
        int nacimiento, sexo, registro;
        int menores25 = 0, mujeres = 0, hombres12a30 = 0, fueraMedellin = 0;
        int edad;
        int anyoActual = 2024;

        printf("Ingrese la cantidad de conductores: ");
        scanf("%d", &n);

        if (n < 1)
        {
                printf("Ingrese un número válido.\n");
                exit(0);
        }

        for (i = 0; i < n; i++)
        {
                printf("\n>>> Conductor #%d\n", i + 1);
                printf("  - Año de nacimiento: ");
                scanf("%d", &nacimiento);

                printf("  - Sexo (1: Femenino, 2: Masculino): ");
                scanf("%d", &sexo);

                printf("  - Registro del carro (1: Medellín, 2: Otras ciudades): ");
                scanf("%d", &registro);

                edad = anyoActual - nacimiento;

                if (edad < 25)
                        menores25++;

                if (sexo == 1)
                        mujeres++;

                if (sexo == 2 && edad >= 12 && edad <= 30)
                        hombres12a30++;

                if (registro == 2)
                        fueraMedellin++;
        }

        printf("\n===== Resultados =====\n");
        printf("- Porcentaje de conductores menores de 25 años: %.2f%%\n", (menores25 * 100.0) / n);
        printf("- Porcentaje de conductores del sexo femenino: %.2f%%\n", (mujeres * 100.0) / n);
        printf("- Porcentaje de hombres entre 12 y 30 años: %.2f%%\n", (hombres12a30 * 100.0) / n);
        printf("- Porcentaje de carros registrados fuera de Medellín: %.2f%%\n", (fueraMedellin * 100.0) / n);

        return 0;
}
