// #include <stdio.h>
// main() // La función main no tiene un tipo especificado
// {
//         float x = 55.4;
//         int *p;
//         p = &x; // Se intenta pasar la referencia de una variable de tipo incompatible
//         printf("El valor correcto es: %f\n", x);
//         printf("Valor apuntado: %f \n", *p);
// }

// Código corregido
#include <stdio.h>

int main() // Se le pone un tipo especifico a la función main
{
        float x = 55.4;
        float *p; // Puntero entero lo cambio a float para que sea compatible

        p = &x;

        printf("El valor correcto es: %f\n", x);
        printf("Valor apuntado: %f \n", *p);

        return 0; // Se agrega return 0; porque la función main es de tipo int
}