#include <stdio.h>

int main() {
        int anyio, anyioActual, edad;

        printf("Ingrese el año de nacimiento: ");
        scanf("%d", &anyio);

        printf("Ingrese el año actual: ");
        scanf("%d", &anyioActual);

        edad = anyioActual - anyio;

        printf("Su edad es: %d \n", edad);

        return 0;
}