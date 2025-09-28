#include <stdio.h>

int main()
{
        int n, i, j, aux;
        int arreglo[100];

        printf("Ingrese la cantidad de elementos: ");

        // 1. Falta el operador & para pasar la dirección de 'n' a scanf.
        // scanf("%d", n); -> scanf("%d", &n);
        scanf("%d", &n);

        printf("Ingrese los elementos:\n");

        // 2. El bucle va de 0 a n, lo cual accede fuera del arreglo (índice n no es válido).
        // Debería ser: i < n
        for (i = 0; i < n; i++)
        {
                scanf("%d", &arreglo[i]);
        }

        // Burbuja (orden descendente)
        for (i = 0; i < n - 1; i++)
        {
                // 3. El límite debe ser j < n - 1 para evitar arreglo[j + 1] fuera de rango.
                for (j = 0; j < n - 1; j++)
                {
                        // 4. El código ordena de mayor a menor, ya que intercambia si el actual es menor.
                        if (arreglo[j] < arreglo[j + 1])
                        {
                                aux = arreglo[j];
                                arreglo[j] = arreglo[j + 1];
                                arreglo[j + 1] = aux;
                        }
                }
        }

        printf("Arreglo ordenado:\n");

        // 6. Nuevamente, i <= n accede un elemento de más.
        // Debe ser: i < n
        for (i = 0; i < n; i++)
        {
                printf("%d ", arreglo[i]);
        }

        printf("\n");

        // 7. Falta el punto y coma al final.
        return 0;
}

/*
8. Para orden ascendente, basta con cambiar:
   if (arreglo[j] < arreglo[j + 1])
   por
   if (arreglo[j] > arreglo[j + 1])
*/
