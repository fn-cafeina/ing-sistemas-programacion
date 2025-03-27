// Construye un programa en C que permita calcular el precio del billete ida y vuelta
// en bus, conociendo tanto la distancia entre las dos ciudades como el tiempo de
// estancia en la ciudad destino. Si el número de días de estancia es superior a 15 y la
// distancia total (ida y vuelta) a recorrer es superior a 500 km, el precio del billete se
// reduce 20%. El precio por km es de C$ 25.

#include <stdio.h>

int main()
{
        int distanciaKm, diasEstancia, valorKm = 25;
        float precioBillete;

        printf("Ingrese la distancia en km: ");
        scanf("%d", &distanciaKm);

        printf("Ingrese la estancia en dias: ");
        scanf("%d", &diasEstancia);

        precioBillete = (distanciaKm * 2) * valorKm;

        if ((distanciaKm * 2) > 500 && diasEstancia > 15)
                precioBillete = precioBillete - (precioBillete * 0.2);

        printf("El precio del billete es de: %.2fC$\n", precioBillete);

        return 0;
}