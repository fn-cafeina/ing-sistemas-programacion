#include <stdio.h>

int main()
{
        int sexo;

        printf("Ingrese su sexo: \n0 - Masculino \n1 - Femenino \n2 - Otro \n");
        scanf("%d", &sexo);

        if (sexo == 0)
        {
                printf("Usted es hombre. \n");
        }
        else if (sexo == 1)
        {
                printf("Usted es mujer. \n");
        }
        else
        {
                printf("Usted es de otro genero. \n");
        }

        return 0;
}