#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct Estudiante
{
        int codigo;
        char nombre[50];
        char apellido[50];
        char correo[50];
        float nota;
        struct Estudiante *siguiente;
        struct Estudiante *anterior;
} ESTUDIANTE;

void limpiar_buffer();
ESTUDIANTE *CrearEstudiante();
void InsertarInicio(ESTUDIANTE **cabeza, ESTUDIANTE *nuevo);
void InsertarFinal(ESTUDIANTE **cabeza, ESTUDIANTE *nuevo);
void AgregarEstudiante(ESTUDIANTE **cabeza);
void BuscarEstudiante(ESTUDIANTE *cabeza);
void EliminarEstudiante(ESTUDIANTE **cabeza);
void TotalAprobados(ESTUDIANTE *cabeza);
void TotalReprobados(ESTUDIANTE *cabeza);
void ImprimirEstudiantes(ESTUDIANTE *cabeza);

int main()
{
        ESTUDIANTE *cabeza = NULL;
        int opcion = 0;

        do
        {
                printf("\n--- REGISTRO DE ESTUDIANTES ---\n");
                printf("1. Agregar un estudiante\n");
                printf("2. Buscar un estudiante por codigo\n");
                printf("3. Eliminar un estudiante\n");
                printf("4. Total de estudiantes aprobados\n");
                printf("5. Total de estudiantes reprobados\n");
                printf("6. Mostrar todos los estudiantes\n");
                printf("7. Salir\n");
                printf("Ingrese una opcion: ");

                if (scanf("%d", &opcion) != 1)
                {
                        opcion = 0;
                }
                limpiar_buffer();

                switch (opcion)
                {
                case 1:
                        AgregarEstudiante(&cabeza);
                        break;
                case 2:
                        BuscarEstudiante(cabeza);
                        break;
                case 3:
                        EliminarEstudiante(&cabeza);
                        break;
                case 4:
                        TotalAprobados(cabeza);
                        break;
                case 5:
                        TotalReprobados(cabeza);
                        break;
                case 6:
                        ImprimirEstudiantes(cabeza);
                        break;
                case 7:
                        printf("Saliendo del programa...\n");
                        break;
                default:
                        printf("Opcion no valida.\n");
                        break;
                }
        } while (opcion != 7);

        return 0;
}

void limpiar_buffer()
{
        int c;
        while ((c = getchar()) != '\n' && c != EOF)
                ;
}

void AgregarEstudiante(ESTUDIANTE **cabeza)
{
        ESTUDIANTE *nuevo = CrearEstudiante();
        if (nuevo == NULL)
                return;

        if (nuevo->nota >= 60.0)
        {
                InsertarInicio(cabeza, nuevo);
                printf("Estudiante APROBADO agregado al INICIO.\n");
        }
        else
        {
                InsertarFinal(cabeza, nuevo);
                printf("Estudiante REPROBADO agregado al FINAL.\n");
        }
}

void BuscarEstudiante(ESTUDIANTE *cabeza)
{
        int codigoBuscado;
        ESTUDIANTE *actual = cabeza;

        printf("Ingrese el codigo a buscar: ");
        if (scanf("%d", &codigoBuscado) != 1)
        {
                printf("Error: Codigo invalido.\n");
                limpiar_buffer();
                return;
        }
        limpiar_buffer();

        while (actual != NULL)
        {
                if (actual->codigo == codigoBuscado)
                {
                        printf("Estudiante encontrado:\n");
                        printf("  Codigo: %d\n", actual->codigo);
                        printf("  Nombre: %s", actual->nombre);
                        printf("  Apellido: %s", actual->apellido);
                        printf("  Correo: %s", actual->correo);
                        printf("  Nota: %.2f\n", actual->nota);
                        return;
                }
                actual = actual->siguiente;
        }
        printf("Estudiante con codigo %d no encontrado.\n", codigoBuscado);
}

void EliminarEstudiante(ESTUDIANTE **cabeza)
{
        int codigoBuscado;
        ESTUDIANTE *actual = *cabeza;

        printf("Ingrese el codigo a eliminar: ");
        if (scanf("%d", &codigoBuscado) != 1)
        {
                printf("Error: Codigo invalido.\n");
                limpiar_buffer();
                return;
        }
        limpiar_buffer();

        while (actual != NULL)
        {
                if (actual->codigo == codigoBuscado)
                {
                        if (actual == *cabeza)
                        {
                                *cabeza = actual->siguiente;
                                if (*cabeza != NULL)
                                        (*cabeza)->anterior = NULL;
                        }
                        else if (actual->siguiente == NULL)
                        {
                                actual->anterior->siguiente = NULL;
                        }
                        else
                        {
                                actual->anterior->siguiente = actual->siguiente;
                                actual->siguiente->anterior = actual->anterior;
                        }

                        free(actual);
                        printf("Estudiante con codigo %d eliminado.\n", codigoBuscado);
                        return;
                }
                actual = actual->siguiente;
        }
        printf("Estudiante con codigo %d no encontrado.\n", codigoBuscado);
}

void TotalAprobados(ESTUDIANTE *cabeza)
{
        ESTUDIANTE *actual = cabeza;
        int contador = 0;
        while (actual != NULL)
        {
                if (actual->nota >= 60.0)
                {
                        contador++;
                }
                actual = actual->siguiente;
        }
        printf("Total de estudiantes APROBADOS: %d\n", contador);
}

void TotalReprobados(ESTUDIANTE *cabeza)
{
        ESTUDIANTE *actual = cabeza;
        int contador = 0;
        while (actual != NULL)
        {
                if (actual->nota < 60.0)
                {
                        contador++;
                }
                actual = actual->siguiente;
        }
        printf("Total de estudiantes REPROBADOS: %d\n", contador);
}

ESTUDIANTE *CrearEstudiante()
{
        ESTUDIANTE *nuevo = (ESTUDIANTE *)malloc(sizeof(ESTUDIANTE));
        if (nuevo == NULL)
        {
                printf("Error: No hay memoria disponible.\n");
                return NULL;
        }

        printf("Ingrese Codigo: ");
        while (scanf("%d", &nuevo->codigo) != 1)
        {
                printf("Entrada invalida. Ingrese un Codigo numerico: ");
                limpiar_buffer();
        }
        limpiar_buffer();

        printf("Ingrese Nombre: ");
        fgets(nuevo->nombre, 50, stdin);

        printf("Ingrese Apellido: ");
        fgets(nuevo->apellido, 50, stdin);

        printf("Ingrese Correo: ");
        fgets(nuevo->correo, 50, stdin);

        printf("Ingrese Nota: ");
        while (scanf("%f", &nuevo->nota) != 1)
        {
                printf("Entrada invalida. Ingrese una Nota numerica: ");
                limpiar_buffer();
        }
        limpiar_buffer();

        nuevo->siguiente = NULL;
        nuevo->anterior = NULL;

        return nuevo;
}

void InsertarInicio(ESTUDIANTE **cabeza, ESTUDIANTE *nuevo)
{
        if (nuevo != NULL)
        {
                nuevo->siguiente = *cabeza;
                nuevo->anterior = NULL;
                if (*cabeza != NULL)
                        (*cabeza)->anterior = nuevo;
                *cabeza = nuevo;
        }
}

void InsertarFinal(ESTUDIANTE **cabeza, ESTUDIANTE *nuevo)
{
        if (nuevo != NULL)
        {
                if (*cabeza == NULL)
                {
                        *cabeza = nuevo;
                        return;
                }

                ESTUDIANTE *nAux = *cabeza;
                while (nAux->siguiente != NULL)
                {
                        nAux = nAux->siguiente;
                }
                nuevo->anterior = nAux;
                nAux->siguiente = nuevo;
        }
}

void ImprimirEstudiantes(ESTUDIANTE *cabeza)
{
        ESTUDIANTE *actual = cabeza;
        if (actual == NULL)
        {
                printf("La lista esta vacia.\n");
                return;
        }

        printf("\n--- LISTA COMPLETA DE ESTUDIANTES ---\n");
        while (actual != NULL)
        {
                printf("------------------------------------\n");
                printf("  Codigo: %d\n", actual->codigo);
                printf("  Nombre: %s", actual->nombre);
                printf("  Apellido: %s", actual->apellido);
                printf("  Nota: %.2f (%s)\n", actual->nota, (actual->nota >= 60 ? "Aprobado" : "Reprobado"));
                actual = actual->siguiente;
        }
        printf("------------------------------------\n");
}