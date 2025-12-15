// Realice un programa en C que implemente una función la cual determine si un
// carácter que será pasado como parámetro es una letra(A...Z, a...z), un dígito o
// cualquier otro carácter (que no sea ni letra ni número). El prototipo de la función
// es: void VerificarCaracter(char c);

#include <stdio.h>
#include <ctype.h>

void VerificarCaracter(char);

int main()
{
        char c;

        printf("Ingrese un caracter: ");
        scanf("%c", &c);

        VerificarCaracter(c);

        return 0;
}

void VerificarCaracter(char c)
{
        if (isdigit(c))
                printf("\nEs un digito.\n");

        if (ispunct(c))
                printf("\nEs una caracter de puntuación.\n");

        if (isalpha(c))
        {
                if (isupper(c))
                        printf("\nEs una letra mayuscula.\n");
                else
                        printf("\nEs una letra minuscula.\n");
        }
}