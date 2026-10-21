// Suponga que el usuario quiere encontrar la suma:
// 15 + 47 + 43 + 64 + 29
// Escriba un programa donde el usuario no sepa de anticipado la cantidad de números a
// sumar. En vez de ello, el usuario escribe cada número, uno después de otro y termina la
// escritura de datos por medio del centinela n(de no). Consejo: Use como centinela el
// siguiente rótulo: “Teclee s para continuar, n para parar:”

#include <stdio.h>
#include <string.h>
#include <stdlib.h>

void limpiarPantalla()
{
        if (system("cls"))
                system("clear");
}

int main()
{
        char centinela[2] = "s";
        int suma = 0;

        while (strcmp(centinela, "s") == 0)
        {
                int numero;

                printf("Digite un número: ");
                scanf("%d", &numero);

                suma += numero;

                printf("\nTeclee s para continuar, n para parar: ");
                scanf("%s", centinela);

                limpiarPantalla();
        }

        printf("La suma es de: %d\n", suma);

        return 0;
}
