#include <stdio.h>
#include <stdlib.h>

enum costo
{
        gripe = 1,
        infeccionRenal,
        diabetes,
        hipertensionArterial
};

int main()
{
        enum costo enfermedad;
        int edad, diasIngresados;
        float pago;

        printf("Tipo de enfermedad          Costo/Paciente/Día\n");
        printf("1 (Gripe)                   25\n");
        printf("2 (Infección Renal)         16\n");
        printf("3 (Diabetes)                35\n");
        printf("4 (Hipertensión Arterial)   32\n\n");

        printf("Ingrese el tipo de enfermedad: ");
        scanf("%d", &enfermedad);

        printf("Ingrese la edad del paciente: ");
        scanf("%d", &edad);

        printf("Ingrese la cantidad de dias ingresado: ");
        scanf("%d", &diasIngresados);

        switch (enfermedad)
        {
        case gripe:
                pago = 25 * diasIngresados;
                break;
        case infeccionRenal:
                pago = 16 * diasIngresados;
                break;
        case diabetes:
                pago = 35 * diasIngresados;
                break;
        case hipertensionArterial:
                pago = 32 * diasIngresados;
                break;
        default:
                printf("Opción no valida.\n");
                exit(0);
        }

        if (edad >= 14 && edad <= 22)
                pago *= 1.05;

        printf("El pago total es de: %.2f C$\n", pago);

        return 0;
}