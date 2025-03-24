#include <stdio.h>

int main()
{
        int sexo;
        char nombre[99];

        printf("Ingrese su nombre: ");
        scanf("%s", &nombre);

        printf("Ingrese su sexo: \n0 - Masculino \n1 - Femenino \n2 - Otro \n");
        scanf("%d", &sexo);

        if (sexo == 0)
        {
                printf("Su nombres es: %s, y su sexo es: Masculino \n", nombre);
        }
        else if (sexo == 1)
        {
                printf("Su nombres es: %s, y su sexo es: Femenino \n", nombre);
        }
        else
        {
                printf("Su nombres es: %s, y usted es de otro genero \n");
        }

        return 0;
}