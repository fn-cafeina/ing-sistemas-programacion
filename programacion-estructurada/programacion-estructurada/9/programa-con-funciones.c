#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <math.h>

#define MAX_LEN 100

int main()
{
        int numero;
        printf("Introduce un número (entero): ");
        scanf("%d", &numero);
        getchar();

        printf("El número introducido es: %d\n", numero);

        char ch;
        printf("Introduce un carácter: ");
        ch = (char)getchar();
        getchar();

        if (isalpha(ch))
        {
                printf("'%c' es una letra. En mayúscula: %c\n", ch, toupper(ch));
        }
        else if (isdigit(ch))
        {
                printf("'%c' es un dígito.\n", ch);
        }
        else if (isspace(ch))
        {
                printf("Es un espacio en blanco.\n");
        }
        else
        {
                printf("'%c' es otro tipo de carácter. En minúscula (si aplica): %c\n", ch, tolower(ch));
        }

        char texto[MAX_LEN];
        printf("Introduce una cadena: ");
        fgets(texto, MAX_LEN, stdin);

        int letras = 0, digitos = 0, espacios = 0;
        for (int i = 0; texto[i] != '\0'; i++)
        {
                if (isalpha(texto[i]))
                        letras++;
                else if (isdigit(texto[i]))
                        digitos++;
                else if (isspace(texto[i]))
                        espacios++;
        }

        printf("Análisis de cadena:\nLetras: %d\nDígitos: %d\nEspacios: %d\n", letras, digitos, espacios);

        int *ptr = (int *)malloc(sizeof(int));
        if (ptr == NULL)
        {
                printf("Error al reservar memoria\n");
                return 1;
        }

        srand(42);
        *ptr = rand() % 100;
        printf("Número aleatorio guardado en memoria: %d\n", *ptr);
        free(ptr);

        char strNum[] = "123";
        int numConvertido = atoi(strNum);
        printf("Número convertido desde cadena '%s': %d\n", strNum, numConvertido);

        double raiz = sqrt((double)numero);
        double potencia = pow((double)numero, 2);
        double valor = -25.78;
        double absoluto = fabs(valor);
        double redondeoArriba = ceil(valor);
        double redondeoAbajo = floor(valor);

        printf("Raíz cuadrada de %d: %.2f\n", numero, raiz);
        printf("%d al cuadrado: %.2f\n", numero, potencia);
        printf("Valor absoluto de %.2f: %.2f\n", valor, absoluto);
        printf("Redondeo hacia arriba de %.2f: %.2f\n", valor, redondeoArriba);
        printf("Redondeo hacia abajo de %.2f: %.2f\n", valor, redondeoAbajo);

        return 0;
}
