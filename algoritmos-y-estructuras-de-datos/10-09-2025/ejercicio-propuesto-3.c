#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_PALABRAS 100
#define MAX_LONGITUD 50

char palabras[MAX_PALABRAS][MAX_LONGITUD];
int total_palabras = 0;
char palabra_encontrada[MAX_LONGITUD];

void cargar_palabras()
{
        FILE *archivo = fopen("palabras.txt", "r");
        if (!archivo)
        {
                printf("Error al abrir el archivo.\n");
                return;
        }
        total_palabras = 0;
        while (fgets(palabras[total_palabras], MAX_LONGITUD, archivo))
        {
                palabras[total_palabras][strcspn(palabras[total_palabras], "\n")] = '\0';
                total_palabras++;
        }
        fclose(archivo);
}

void guardar_palabras()
{
        FILE *archivo = fopen("palabras.txt", "w");
        for (int i = 0; i < total_palabras; i++)
                fprintf(archivo, "%s\n", palabras[i]);
        fclose(archivo);
}

void visualizar_palabras()
{
        printf("\nPalabras actuales:\n");
        for (int i = 0; i < total_palabras; i++)
                printf("%d. %s\n", i + 1, palabras[i]);
}

void añadir_palabra()
{
        if (total_palabras >= MAX_PALABRAS)
        {
                printf("No se pueden añadir más palabras.\n");
                return;
        }
        printf("Ingrese la nueva palabra: ");
        scanf("%s", palabras[total_palabras]);
        total_palabras++;
        guardar_palabras();
}

int comparar(const void *a, const void *b)
{
        return strcmp((const char *)a, (const char *)b);
}

int busqueda_binaria(char *clave)
{
        int izquierda = 0, derecha = total_palabras - 1;
        while (izquierda <= derecha)
        {
                int medio = (izquierda + derecha) / 2;
                int cmp = strcmp(clave, palabras[medio]);
                if (cmp == 0)
                {
                        strcpy(palabra_encontrada, palabras[medio]);
                        return medio;
                }
                else if (cmp < 0)
                        derecha = medio - 1;
                else
                        izquierda = medio + 1;
        }
        return -1;
}

void menu()
{
        int opcion;
        do
        {
                printf("\n\n*****Búsqueda de Diccionario *****\n");
                printf("1. Visualizar palabras.\n");
                printf("2. Añadir una palabra a las existentes.\n");
                printf("3. Ordenar las palabras usando qsort.\n");
                printf("4. Buscar palabra usando búsqueda binaria.\n");
                printf("5. Visualizar la palabra encontrada.\n");
                printf("7. Regresar.\n");
                printf("\nSu opcion ?: ");
                scanf("%d", &opcion);

                switch (opcion)
                {
                case 1:
                        cargar_palabras();
                        visualizar_palabras();
                        break;
                case 2:
                        añadir_palabra();
                        break;
                case 3:
                        qsort(palabras, total_palabras, MAX_LONGITUD, comparar);
                        guardar_palabras();
                        printf("Palabras ordenadas con qsort.\n");
                        break;
                case 4:
                {
                        char clave[MAX_LONGITUD];
                        printf("Ingrese la palabra a buscar: ");
                        scanf("%s", clave);
                        qsort(palabras, total_palabras, MAX_LONGITUD, comparar);
                        int pos = busqueda_binaria(clave);
                        if (pos != -1)
                                printf("Palabra encontrada en la posición %d.\n", pos + 1);
                        else
                                printf("Palabra no encontrada.\n");
                        break;
                }
                case 5:
                        if (strlen(palabra_encontrada) > 0)
                                printf("Última palabra encontrada: %s\n", palabra_encontrada);
                        else
                                printf("No se ha realizado ninguna búsqueda aún.\n");
                        break;
                case 7:
                        printf("Saliendo del programa...\n");
                        break;
                default:
                        printf("Opción inválida.\n");
                }
        } while (opcion != 7);
}

int main()
{
        cargar_palabras();
        menu();
        return 0;
}