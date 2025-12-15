/*
        Al momento de ingresar a un hospital, a un paciente se le solicitan los siguientes datos:
        - Nombre.
        - Edad.
        - Sexo.
        - Domicilio: (Calle, Numero, Ciudad.)
        - Teléfono.
        - Seguro (Este campo tendrá valor VERDADERO si el paciente tiene seguro médico y FALSO en otro caso).

        Construya un programa en lenguaje C que almacene la información en una lista circular y pueda llevar
        a cabo las siguientes operaciones:
        Listar los nombres de todos los pacientes hospitalizados.
        - Obtener el porcentaje de pacientes hospitalizados en las siguientes categorías (dadas por edad):
                - Niños: Hasta 13 años.
                - Jóvenes: Mayores de 13 años, y hasta 30 años de edad.
                - Adultos: Mayores de 30 años.
        - Obtener el porcentaje de hombres y mujeres hospitalizados.
        - Dado el nombre de un paciente, listar todos los datos relacionados con dicho paciente.
        - Calcular el porcentaje de pacientes que poseen seguro médico.

        - Construir la lista de modo que los datos vayan quedando almacenados en el orden que sean
        ingresados.
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
        char calle[100];
        int numero;
        char ciudad[100];
} Domicilio;

typedef struct
{
        char nombre[100];
        int edad;
        char sexo[20];
        Domicilio domicilio;
        char telefono[20];
        int tieneSeguro;
} Paciente;

typedef struct _nodo
{
        Paciente paciente;
        struct _nodo *siguiente;
} tipoNodo;

typedef tipoNodo *pNodo;
typedef tipoNodo *Lista;

void limpiarBuffer()
{
        int c;
        while ((c = getchar()) != '\n' && c != EOF)
                ;
}

void leerString(char *destino, int tamano)
{
        fgets(destino, tamano, stdin);
        size_t len = strlen(destino);
        if (len > 0 && destino[len - 1] == '\n')
        {
                destino[len - 1] = '\0';
        }
        else
        {
                limpiarBuffer();
        }
}

int estaVacia(Lista lista)
{
        return lista == NULL;
}

void InsertarAlFinal(Lista *lista, Paciente p)
{
        pNodo nuevo = (pNodo)malloc(sizeof(tipoNodo));
        if (!nuevo)
        {
                printf("Error: No hay memoria disponible.\n");
                return;
        }
        nuevo->paciente = p;

        if (estaVacia(*lista))
        {
                *lista = nuevo;
                nuevo->siguiente = nuevo;
        }
        else
        {
                nuevo->siguiente = (*lista)->siguiente;
                (*lista)->siguiente = nuevo;
                *lista = nuevo;
        }
}

void LiberarLista(Lista *lista)
{
        if (estaVacia(*lista))
        {
                return;
        }

        pNodo nodo;

        while ((*lista)->siguiente != *lista)
        {
                nodo = (*lista)->siguiente;
                (*lista)->siguiente = nodo->siguiente;
                free(nodo);
        }

        free(*lista);
        *lista = NULL;
}

void ListarNombres(Lista lista)
{
        if (estaVacia(lista))
        {
                printf("No hay pacientes hospitalizados.\n");
                return;
        }

        pNodo actual = lista->siguiente;

        printf("\n--- Lista de Pacientes Hospitalizados ---\n");
        do
        {
                printf("- %s\n", actual->paciente.nombre);
                actual = actual->siguiente;
        } while (actual != lista->siguiente);
}

void CalcularPorcentajesEdad(Lista lista)
{
        if (estaVacia(lista))
        {
                printf("No hay pacientes para calcular estadísticas.\n");
                return;
        }

        int ninos = 0, jovenes = 0, adultos = 0, total = 0;
        pNodo actual = lista->siguiente;

        do
        {
                int edad = actual->paciente.edad;
                if (edad <= 13)
                {
                        ninos++;
                }
                else if (edad > 13 && edad <= 30)
                {
                        jovenes++;
                }
                else
                {
                        adultos++;
                }
                total++;
                actual = actual->siguiente;
        } while (actual != lista->siguiente);

        printf("\n--- Porcentaje de Pacientes por Edad ---\n");
        printf("Total de pacientes: %d\n", total);
        printf("Ninos (<= 13 anos): \t%.2f%%\n", (double)ninos / total * 100);
        printf("Jovenes (14-30 anos): \t%.2f%%\n", (double)jovenes / total * 100);
        printf("Adultos (> 30 anos): \t%.2f%%\n", (double)adultos / total * 100);
}

void CalcularPorcentajeSexo(Lista lista)
{
        if (estaVacia(lista))
        {
                printf("No hay pacientes para calcular estadísticas.\n");
                return;
        }

        int hombres = 0, mujeres = 0, total = 0;
        pNodo actual = lista->siguiente;

        do
        {
                if (strcmp(actual->paciente.sexo, "Hombre") == 0)
                {
                        hombres++;
                }
                else if (strcmp(actual->paciente.sexo, "Mujer") == 0)
                {
                        mujeres++;
                }
                total++;
                actual = actual->siguiente;
        } while (actual != lista->siguiente);

        if (total == 0)
        {
                printf("No se registraron pacientes como 'Hombre' o 'Mujer'.\n");
                return;
        }

        printf("\n--- Porcentaje de Pacientes por Sexo ---\n");
        printf("Total de pacientes (H/M): %d\n", total);
        printf("Hombres: \t%.2f%%\n", (double)hombres / total * 100);
        printf("Mujeres: \t%.2f%%\n", (double)mujeres / total * 100);
}

void ImprimirDatosPaciente(Paciente p)
{
        printf("  Nombre: %s\n", p.nombre);
        printf("  Edad: %d\n", p.edad);
        printf("  Sexo: %s\n", p.sexo);
        printf("  Telefono: %s\n", p.telefono);
        printf("  Seguro Medico: %s\n", p.tieneSeguro ? "VERDADERO" : "FALSO");
        printf("  Domicilio:\n");
        printf("    Calle: %s\n", p.domicilio.calle);
        printf("    Numero: %d\n", p.domicilio.numero);
        printf("    Ciudad: %s\n", p.domicilio.ciudad);
}

void BuscarPaciente(Lista lista, char nombreBuscar[])
{
        if (estaVacia(lista))
        {
                printf("No hay pacientes en la lista.\n");
                return;
        }

        pNodo actual = lista->siguiente;
        int encontrado = 0;

        do
        {
                if (strcmp(actual->paciente.nombre, nombreBuscar) == 0)
                {
                        printf("\n--- Datos del Paciente Encontrado ---\n");
                        ImprimirDatosPaciente(actual->paciente);
                        encontrado = 1;
                }
                actual = actual->siguiente;
        } while (actual != lista->siguiente);

        if (!encontrado)
        {
                printf("No se encontro ningun paciente con el nombre: %s\n", nombreBuscar);
        }
}

void CalcularPorcentajeSeguro(Lista lista)
{
        if (estaVacia(lista))
        {
                printf("No hay pacientes para calcular estadísticas.\n");
                return;
        }

        int conSeguro = 0, total = 0;
        pNodo actual = lista->siguiente;

        do
        {
                if (actual->paciente.tieneSeguro == 1)
                {
                        conSeguro++;
                }
                total++;
                actual = actual->siguiente;
        } while (actual != lista->siguiente);

        printf("\n--- Porcentaje de Pacientes con Seguro Medico ---\n");
        printf("Total de pacientes: %d\n", total);
        printf("Con Seguro Medico: \t%.2f%%\n", (double)conSeguro / total * 100);
}

Paciente solicitarPaciente()
{
        Paciente p;
        char opcion;

        printf("\n--- Ingreso de Nuevo Paciente ---\n");

        printf("Nombre completo: ");
        leerString(p.nombre, 100);

        printf("Edad: ");
        scanf("%d", &p.edad);
        limpiarBuffer();

        printf("Sexo (H = Hombre / M = Mujer): ");
        scanf(" %c", &opcion);
        limpiarBuffer();
        if (opcion == 'H' || opcion == 'h')
        {
                strcpy(p.sexo, "Hombre");
        }
        else
        {
                strcpy(p.sexo, "Mujer");
        }

        printf("--- Domicilio --- \n");
        printf("  Calle: ");
        leerString(p.domicilio.calle, 100);
        printf("  Numero: ");
        scanf("%d", &p.domicilio.numero);
        limpiarBuffer();
        printf("  Ciudad: ");
        leerString(p.domicilio.ciudad, 100);

        printf("Telefono: ");
        leerString(p.telefono, 20);

        printf("Tiene seguro medico? (S = Si / N = No): ");
        scanf(" %c", &opcion);
        limpiarBuffer();
        if (opcion == 'S' || opcion == 's')
        {
                p.tieneSeguro = 1;
        }
        else
        {
                p.tieneSeguro = 0;
        }

        return p;
}

void mostrarMenu()
{
        printf("\n\n--- SISTEMA DE PACIENTES HOSPITALIZADOS ---\n");
        printf("1. Ingresar nuevo paciente\n");
        printf("2. Listar nombres de pacientes\n");
        printf("3. Mostrar porcentaje por edad\n");
        printf("4. Mostrar porcentaje por sexo\n");
        printf("5. Buscar paciente por nombre\n");
        printf("6. Mostrar porcentaje con seguro medico\n");
        printf("0. Salir\n");
        printf("Seleccione una opcion: ");
}

int main()
{
        Lista listaPacientes = NULL;
        int opcion;
        char nombreBusqueda[100];

        do
        {
                mostrarMenu();
                if (scanf("%d", &opcion) != 1)
                {
                        printf("Error: Entrada no válida. Debe ingresar un número.\n");
                        limpiarBuffer();
                        opcion = -1;
                        continue;
                }
                limpiarBuffer();

                switch (opcion)
                {
                case 1:
                        InsertarAlFinal(&listaPacientes, solicitarPaciente());
                        printf("\nPaciente ingresado con exito.\n");
                        break;
                case 2:
                        ListarNombres(listaPacientes);
                        break;
                case 3:
                        CalcularPorcentajesEdad(listaPacientes);
                        break;
                case 4:
                        CalcularPorcentajeSexo(listaPacientes);
                        break;
                case 5:
                        printf("Ingrese el nombre completo del paciente a buscar: ");
                        leerString(nombreBusqueda, 100);
                        BuscarPaciente(listaPacientes, nombreBusqueda);
                        break;
                case 6:
                        CalcularPorcentajeSeguro(listaPacientes);
                        break;
                case 0:
                        printf("Saliendo del programa y liberando memoria...\n");
                        LiberarLista(&listaPacientes);
                        break;
                default:
                        printf("Opcion no valida. Intente de nuevo.\n");
                }

                if (opcion != 0)
                {
                        printf("\nPresione Enter para continuar...");
                        getchar();
                }

        } while (opcion != 0);

        return 0;
}