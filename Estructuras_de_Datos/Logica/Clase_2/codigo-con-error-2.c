// #include <stdio.h>
// main() // La función main no tiene un tipo especificado
// {
//         int i, *p;
//         i = 50;
//         *p = i; // No se le pasa la referencia de la variable i y se trata de asignar usando el operador de contenido "*"
//         printf(“El valor de i es % i \n”, i);
//         printf(“El valor de *p es % i \n”, *p);
// }

#include <stdio.h>

int main() // Se le pone un tipo especifico a la función main
{
        int i, *p;

        i = 50;
        p = &i; // Se corrige usando el valor de referencia y quitando el operador de contenido "*"

        printf("El valor de i es %i \n", i);
        printf("El valor de *p es %i \n", *p);

        return 0; // Se agrega return 0; porque la función main es de tipo int
}