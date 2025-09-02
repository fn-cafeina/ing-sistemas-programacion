// Escribir un programa que haga uso de funciones y asignación dinámica de memoria para realizar
// las siguientes operaciones en base al valor de un parámetro leído:
// a) Sí se ingresa el parámetro –s, que sume dos fracciones.
// b) Sí se ingresa el parámetro –r, que reste dos fracciones.
// c) Sí se ingresa el parámetro –m, que multiplique dos fracciones.
// d) Sí el parámetro leído no es ninguno de los anteriores, que muestre el mensaje “Parámetro
// Invalido”.
//
// Utilice la siguiente estructura:
// struct racional
// {
//      int numerador;
//      int denominador;
// };
//
// typedef struct racional fraccion;
//
// Realice el código de cada acción, tomando en cuenta las siguientes funciones prototipos:
// fraccion * SumarFracciones(fraccion f1, fraccion f2);
// fraccion * RestarFracciones(fraccion f1, fraccion f2);
// fraccion * MultiplicarFracciones(fraccion f1, fraccion f2);

#include <stdio.h>
#include <stdlib.h>

struct racional
{
        int numerador;
        int denominador;
};
typedef struct racional fraccion;

fraccion *SumarFracciones(fraccion f1, fraccion f2);
fraccion *RestarFracciones(fraccion f1, fraccion f2);
fraccion *MultiplicarFracciones(fraccion f1, fraccion f2);

int abs_i(int x) { return x < 0 ? -x : x; }

int mcd(int a, int b)
{
        a = abs_i(a);
        b = abs_i(b);
        while (b != 0)
        {
                int t = a % b;
                a = b;
                b = t;
        }
        return a == 0 ? 1 : a;
}

void simplificar(fraccion *f)
{
        if (f->denominador == 0)
                return;
        int g = mcd(f->numerador, f->denominador);
        f->numerador /= g;
        f->denominador /= g;
        if (f->denominador < 0)
        {
                f->denominador = -f->denominador;
                f->numerador = -f->numerador;
        }
}

fraccion *SumarFracciones(fraccion f1, fraccion f2)
{
        fraccion *res = (fraccion *)malloc(sizeof(fraccion));
        if (!res)
                return NULL;
        res->numerador = f1.numerador * f2.denominador + f2.numerador * f1.denominador;
        res->denominador = f1.denominador * f2.denominador;
        simplificar(res);
        return res;
}

fraccion *RestarFracciones(fraccion f1, fraccion f2)
{
        fraccion *res = (fraccion *)malloc(sizeof(fraccion));
        if (!res)
                return NULL;
        res->numerador = f1.numerador * f2.denominador - f2.numerador * f1.denominador;
        res->denominador = f1.denominador * f2.denominador;
        simplificar(res);
        return res;
}

fraccion *MultiplicarFracciones(fraccion f1, fraccion f2)
{
        fraccion *res = (fraccion *)malloc(sizeof(fraccion));
        if (!res)
                return NULL;
        res->numerador = f1.numerador * f2.numerador;
        res->denominador = f1.denominador * f2.denominador;
        simplificar(res);
        return res;
}

int main(int argc, char *argv[])
{
        if (argc < 2)
        {
                printf("Uso: %s [-s|-r|-m]\n", argv[0]);
                return 0;
        }

        char op = '\0';
        if (argv[1][0] == '-' && argv[1][1] && argv[1][2] == '\0')
        {
                op = argv[1][1];
        }

        fraccion f1, f2;
        printf("Ingrese primera fraccion (numerador denominador): ");
        if (scanf("%d %d", &f1.numerador, &f1.denominador) != 2)
        {
                fprintf(stderr, "Entrada invalida.\n");
                return 1;
        }
        printf("Ingrese segunda fraccion (numerador denominador): ");
        if (scanf("%d %d", &f2.numerador, &f2.denominador) != 2)
        {
                fprintf(stderr, "Entrada invalida.\n");
                return 1;
        }

        if (f1.denominador == 0 || f2.denominador == 0)
        {
                fprintf(stderr, "Error: denominador cero no permitido.\n");
                return 1;
        }

        fraccion *res = NULL;
        switch (op)
        {
        case 's':
                res = SumarFracciones(f1, f2);
                break;
        case 'r':
                res = RestarFracciones(f1, f2);
                break;
        case 'm':
                res = MultiplicarFracciones(f1, f2);
                break;
        default:
                printf("Parámetro Invalido\n");
                return 0;
        }

        if (!res)
        {
                fprintf(stderr, "Error de memoria.\n");
                return 1;
        }

        printf("Resultado: %d/%d\n", res->numerador, res->denominador);
        free(res);
        return 0;
}
