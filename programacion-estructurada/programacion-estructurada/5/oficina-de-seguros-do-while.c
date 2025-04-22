// Una oficina de seguros ha reunido datos concernientes a todos los accidentes de tránsito
// ocurridos en el área metropolitana de Medellín en el último año. Por cada conductor
// involucrado en un accidente se toman los siguientes datos: año de nacimiento, sexo(0:
// Masculino, 1: Femenino), registro del carro(1: Medellín, 2: Otras ciudades). Hacer un
// programa en C que muestre:
// • El porcentaje de conductores menores de 25 años.
// • Porcentaje de conductores del sexo femenino.
// • Porcentaje de conductores masculinos con edades entre 12 y 30 años.
// • Porcentaje de conductores cuyos carros están registrados fuera de Medellín.

#include <stdio.h>
#include <stdlib.h>

#define ANYO_ACTUAL 2025

void limpiarPantalla()
{
        if (system("cls"))
                system("clear");
}

void limpiarBuffer()
{
        while (getchar() != '\n')
                ;
}

int main()
{
        limpiarPantalla();

        int conductoresI, conductoresM25 = 0, conductoresF = 0, conductoresM12a30 = 0, conductoresOtrasCiudades = 0;
        int esValido;

        printf("Ingrese la cantidad de conductores involucrados en los accidentes de transito: ");
        esValido = scanf("%d", &conductoresI);

        if (esValido)
        {
                if (conductoresI <= 0)
                {
                        printf("\nIngrese un numero de conductores valido.\n");
                        return 1;
                }
        }
        else
        {
                printf("\nIngrese un tipo de dato valido.\n");
                limpiarBuffer();
                return 1;
        }

        int anyioNacimiento, edad, sexo, ciudad;
        int i = 1;

        do
        {
                printf("\nEvaluación del conductor #%d\n", i);

                printf("Año de nacimiento: ");
                esValido = scanf("%d", &anyioNacimiento);

                if (!esValido)
                {
                        printf("\nIngrese un año valido. Intente de nuevo...\n");
                        limpiarBuffer();
                        continue;
                }

                edad = ANYO_ACTUAL - anyioNacimiento;

                if (edad < 0)
                {
                        printf("\n¿Edad negativa? ¿No te confundiste? Volve a intentarlo...\n");
                        limpiarBuffer();
                        continue;
                }

                printf("Sexo(0: Masculino | 1: Femenino): ");
                esValido = scanf("%d", &sexo);

                if (!esValido || (sexo != 0 && sexo != 1))
                {
                        printf("\nGénero no válido, preguntando de nuevo...\n");
                        limpiarBuffer();
                        continue;
                }

                printf("Registro del carro(1: Medellín | 2: Otras ciudades): ");
                esValido = scanf("%d", &ciudad);

                if (!esValido || (ciudad != 1 && ciudad != 2))
                {
                        printf("\nOpción de ciudad no válida, preguntando de nuevo...\n");
                        limpiarBuffer();
                        continue;
                }

                if (edad < 25)
                        conductoresM25++;

                if (sexo == 1)
                        conductoresF++;

                if (sexo == 0 && edad >= 12 && edad <= 30)
                        conductoresM12a30++;

                if (ciudad == 2)
                        conductoresOtrasCiudades++;

                limpiarBuffer();

                i++;
        } while (i <= conductoresI);

        if (conductoresI > 0)
        {
                printf("\nPorcentaje de conductores menores de 25 años: %.2f%%\n", (float)conductoresM25 / conductoresI * 100);
                printf("Porcentaje de conductores del sexo femenino: %.2f%%\n", (float)conductoresF / conductoresI * 100);
                printf("Porcentaje de conductores masculinos entre 12 y 30 años: %.2f%%\n", (float)conductoresM12a30 / conductoresI * 100);
                printf("Porcentaje de conductores con carros registrados fuera de Medellín: %.2f%%\n", (float)conductoresOtrasCiudades / conductoresI * 100);
        }
        else
                printf("\nNo se ingresaron datos de conductores.\n");

        return 0;
}