/*
        Escribir un programa en C que permita almacenar una serie de países y sus
        capitales en una lista lineal simplemente enlazada. Además, el programa deberá
        mostrar un informe de los países y sus correspondientes capitales y presentará la
        posibilidad de buscar un país según su capital y viceversa. Para todas estas
        operaciones haga uso de un menú donde el usuario pueda elegir la operación a
        realizar.

        Nota: puedes hacer uso de un fichero para guardar los países y capitales.
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define FICHERO "paises.txt"

#ifdef _WIN32
#define LIMPIAR "cls"
#define PAUSAR "pause"
#else
#define LIMPIAR "clear"
#define PAUSAR "read -p 'Presione ENTER para continuar...' var"
#endif

struct datos
{
        char pais[30];
        char capital[30];
        struct datos *siguiente;
};
typedef struct datos paises;

paises *nuevo(void);
void error(void);
void anadir(paises **cab, char pais[], char capital[]);
paises *buscar_por_pais(paises *cabecera, char pais[]);
paises *buscar_por_capital(paises *cabecera, char capital[]);
void borrar(paises **cab, char pais[]);
void ver(paises *cab);
int menu(char *opciones[], int numOpciones);
void limpiar_buffer(void);
void cargar_desde_fichero(paises **cab);
void guardar_en_fichero(paises *cab);
void limpiar_pantalla(void);
void pausar(void);

char *opciones[] = {
    "Insertar un elemento.",
    "Buscar por país.",
    "Buscar por capital.",
    "Ver todos los datos.",
    "Borrar un dato.",
    "Salir"};

int main(void)
{
        paises *cabecera = NULL;
        paises *q;
        char pa[30];
        char cap[30];
        int opcion;

        cargar_desde_fichero(&cabecera);

        while (1)
        {
                limpiar_pantalla();
                opcion = menu(opciones, 6);
                printf("\n");

                switch (opcion)
                {
                case 1:
                        printf("Introduzca el país: ");
                        limpiar_buffer();
                        fgets(pa, sizeof(pa), stdin);
                        pa[strcspn(pa, "\n")] = '\0';

                        printf("Introduzca la capital: ");
                        fgets(cap, sizeof(cap), stdin);
                        cap[strcspn(cap, "\n")] = '\0';

                        anadir(&cabecera, pa, cap);
                        guardar_en_fichero(cabecera);
                        printf("\nPaís y capital añadidos correctamente.\n");
                        break;

                case 2:
                        printf("Escriba el nombre del país: ");
                        limpiar_buffer();
                        fgets(pa, sizeof(pa), stdin);
                        pa[strcspn(pa, "\n")] = '\0';

                        q = buscar_por_pais(cabecera, pa);
                        if (q)
                                printf("\tLa capital de %s es %s\n\n", pa, q->capital);
                        else
                                printf("\tNo se encontró el país.\n");
                        break;

                case 3:
                        printf("Escriba el nombre de la capital: ");
                        limpiar_buffer();
                        fgets(cap, sizeof(cap), stdin);
                        cap[strcspn(cap, "\n")] = '\0';

                        q = buscar_por_capital(cabecera, cap);
                        if (q)
                                printf("\t%s es la capital de %s\n\n", cap, q->pais);
                        else
                                printf("\tNo hay resultados.\n");
                        break;

                case 4:
                        ver(cabecera);
                        break;

                case 5:
                        printf("¿Qué país desea borrar?: ");
                        limpiar_buffer();
                        fgets(pa, sizeof(pa), stdin);
                        pa[strcspn(pa, "\n")] = '\0';
                        borrar(&cabecera, pa);
                        guardar_en_fichero(cabecera);
                        break;

                case 6:
                        printf("Saliendo del programa...\n");
                        guardar_en_fichero(cabecera);
                        exit(0);
                }

                pausar();
        }
}

void limpiar_buffer(void)
{
        int c;
        while ((c = getchar()) != '\n' && c != EOF)
                ;
}

void limpiar_pantalla(void)
{
        system(LIMPIAR);
}

void pausar(void)
{
        system(PAUSAR);
}

paises *nuevo(void)
{
        paises *q = (paises *)malloc(sizeof(paises));
        if (!q)
                error();
        return q;
}

void error(void)
{
        printf("No hay espacio en memoria.\n");
        exit(-1);
}

int menu(char *opciones[], int numOpciones)
{
        int i, opcion;
        printf("__________________________________________\n\n");
        for (i = 1; i <= numOpciones; ++i)
                printf("%3d.- %s\n", i, opciones[i - 1]);
        printf("__________________________________________\n");

        do
        {
                printf("\nOpción (1 - %d): ", numOpciones);
                if (scanf("%d", &opcion) != 1)
                {
                        limpiar_buffer();
                        opcion = 0;
                }
        } while (opcion < 1 || opcion > numOpciones);
        return opcion;
}

void anadir(paises **cab, char pais[], char capital[])
{
        paises *nuevoNodo = nuevo();
        strcpy(nuevoNodo->pais, pais);
        strcpy(nuevoNodo->capital, capital);
        nuevoNodo->siguiente = *cab;
        *cab = nuevoNodo;
}

paises *buscar_por_pais(paises *cabecera, char pais[])
{
        while (cabecera)
        {
                if (strcmp(cabecera->pais, pais) == 0)
                        return cabecera;
                cabecera = cabecera->siguiente;
        }
        return NULL;
}

paises *buscar_por_capital(paises *cabecera, char capital[])
{
        while (cabecera)
        {
                if (strcmp(cabecera->capital, capital) == 0)
                        return cabecera;
                cabecera = cabecera->siguiente;
        }
        return NULL;
}

void borrar(paises **cab, char pais[])
{
        paises *actual = *cab;
        paises *anterior = NULL;

        while (actual)
        {
                if (strcmp(actual->pais, pais) == 0)
                {
                        if (anterior)
                                anterior->siguiente = actual->siguiente;
                        else
                                *cab = actual->siguiente;

                        free(actual);
                        printf("País borrado exitosamente.\n");
                        return;
                }
                anterior = actual;
                actual = actual->siguiente;
        }
        printf("País no encontrado.\n");
}

void ver(paises *cab)
{
        if (!cab)
        {
                printf("La lista está vacía.\n");
                return;
        }

        printf("\n--- LISTA DE PAÍSES Y CAPITALES ---\n");
        while (cab)
        {
                printf("País: %-20s  | Capital: %s\n", cab->pais, cab->capital);
                cab = cab->siguiente;
        }
        printf("------------------------------------\n");
}

void cargar_desde_fichero(paises **cab)
{
        FILE *f = fopen(FICHERO, "r");
        if (!f)
                return;

        char pais[30], capital[30];
        while (fscanf(f, "%29[^,],%29[^\n]\n", pais, capital) == 2)
        {
                anadir(cab, pais, capital);
        }

        fclose(f);
}

void guardar_en_fichero(paises *cab)
{
        FILE *f = fopen(FICHERO, "w");
        if (!f)
        {
                printf("Error al abrir el fichero para escritura.\n");
                return;
        }

        paises *actual = cab;
        while (actual)
        {
                fprintf(f, "%s,%s\n", actual->pais, actual->capital);
                actual = actual->siguiente;
        }

        fclose(f);
}
