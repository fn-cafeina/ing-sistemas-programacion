// #include <stdio.h>
// main() // La función main no tiene tipo especifico
// {
//         int i, *p;
//         i = 50;
//         p = i;
//         printf(“El valor de i es % i \n”, i);
//         printf(“El valor de * p es % i \n”, *p);
// }

#include <stdio.h>

int main()
{
        int i, *p;

        i = 50;
        p = &i; // Se corrige usando el valor para obtener la dirección de memoria de i "&"

        printf("El valor de i es %i \n", i);
        printf("El valor de *p es %i \n", *p);

        return 0; // Se agrega return 0; porque la función main es de tipo int
}