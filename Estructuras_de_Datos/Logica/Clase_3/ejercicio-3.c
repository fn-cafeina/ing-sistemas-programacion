// Realizar un programa que cree en memoria un array dinámico unidimensional de datos de
// tipo double. El programa pedirá inicialmente por teclado el número deseado de elementos
// de tal array, luego lo creará mediante asignación dinámica de memoria, a continuación,
// pedirá por teclado los datos a almacenar en dichos elementos del array, luego calculará la
// media aritmética de dichos datos, la presentará en pantalla y finalmente eliminará el array,
// liberando la memoria utilizada por el mismo.

#include <stdio.h>
#include <stdlib.h>

int main()
{
        int cantidad_datos = 0;

        printf("Ingrese la cantidad de dobles a almacenar: ");
        scanf("%d", &cantidad_datos);

        double *array = (double *)malloc(sizeof(double) * cantidad_datos);

        if (array == NULL)
        {
                perror("Error: No se pudo asignar memoria.");
                exit(0);
        }

        for (int i = 0; i < cantidad_datos; i++)
        {
                printf("Ingrese un doble en la posición [%d]: ", i);
                scanf("%lf", &array[i]);
        }

        double media_aritmetica = 0;

        for (int i = 0; i < cantidad_datos; i++)
        {
                media_aritmetica += array[i];
        }

        printf("La media aritmetica de los datos introducidos es: %lf\n\n", media_aritmetica / cantidad_datos);

        return 0;
}
