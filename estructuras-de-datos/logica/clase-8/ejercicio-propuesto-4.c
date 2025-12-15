#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
        int **p;
        int filas;
        int cols;
} tmatriz2D;

tmatriz2D *AsignarMem2D(int filas, int cols)
{
        int f;
        tmatriz2D *x = (tmatriz2D *)malloc(sizeof(tmatriz2D));
        if (x == NULL)
                return NULL;

        x->filas = filas;
        x->cols = cols;

        x->p = (int **)malloc(filas * sizeof(int *));
        if (x->p == NULL)
                return NULL;

        for (f = 0; f < filas; f++)
        {
                x->p[f] = (int *)malloc(cols * sizeof(int));
                if (x->p[f] == NULL)
                {
                        for (int k = 0; k < f; k++)
                                free(x->p[k]);
                        free(x->p);
                        free(x);
                        return NULL;
                }
        }
        return x;
}

void LiberarMem2D(tmatriz2D x)
{
        for (int f = 0; f < x.filas; f++)
        {
                free(x.p[f]);
        }
        free(x.p);
}

void LeerDatos(tmatriz2D *m)
{
        printf("Ingrese los valores de la matriz %dx%d:\n", m->filas, m->cols);
        for (int i = 0; i < m->filas; i++)
        {
                for (int j = 0; j < m->cols; j++)
                {
                        printf("Elemento [%d][%d]: ", i, j);
                        scanf("%d", &m->p[i][j]);
                }
        }
}

void Visualizar(tmatriz2D m)
{
        printf("\nMatriz:\n");
        for (int i = 0; i < m.filas; i++)
        {
                for (int j = 0; j < m.cols; j++)
                {
                        printf("%4d ", m.p[i][j]);
                }
                printf("\n");
        }
}

int comparar(const void *a, const void *b)
{
        return (*(int *)a - *(int *)b);
}

void Ordenar(tmatriz2D *m)
{
        int n = m->filas * m->cols;
        int *temp = (int *)malloc(n * sizeof(int));

        int k = 0;
        for (int i = 0; i < m->filas; i++)
                for (int j = 0; j < m->cols; j++)
                        temp[k++] = m->p[i][j];

        qsort(temp, n, sizeof(int), comparar);

        k = 0;
        for (int i = 0; i < m->filas; i++)
                for (int j = 0; j < m->cols; j++)
                        m->p[i][j] = temp[k++];

        free(temp);
}

void BusquedaBinaria(tmatriz2D *m, int valor)
{
        int n = m->filas * m->cols;
        int *temp = (int *)malloc(n * sizeof(int));

        int k = 0;
        for (int i = 0; i < m->filas; i++)
                for (int j = 0; j < m->cols; j++)
                        temp[k++] = m->p[i][j];

        qsort(temp, n, sizeof(int), comparar);

        int inf = 0, sup = n - 1, encontrado = -1;
        while (inf <= sup)
        {
                int mid = (inf + sup) / 2;
                if (temp[mid] == valor)
                {
                        encontrado = mid;
                        break;
                }
                else if (valor < temp[mid])
                {
                        sup = mid - 1;
                }
                else
                {
                        inf = mid + 1;
                }
        }

        if (encontrado != -1)
                printf("Valor %d encontrado en la posición lineal %d.\n", valor, encontrado);
        else
                printf("Valor %d no encontrado.\n", valor);

        free(temp);
}

int main()
{
        int n, valor;
        printf("Ingrese el tamaño de la matriz cuadrada: ");
        scanf("%d", &n);

        tmatriz2D *mat = AsignarMem2D(n, n);
        if (!mat)
        {
                printf("Error al asignar memoria.\n");
                return 1;
        }

        LeerDatos(mat);
        Visualizar(*mat);

        Ordenar(mat);
        printf("\nMatriz ordenada:\n");
        Visualizar(*mat);

        printf("\nIngrese el valor a buscar: ");
        scanf("%d", &valor);
        BusquedaBinaria(mat, valor);

        LiberarMem2D(*mat);
        free(mat);
        return 0;
}