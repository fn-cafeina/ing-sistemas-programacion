// Se desea informatizar los resultados obtenidos por los equipos de baloncesto y de fútbol de León.
// La información de cada equipo:
//      • Nombre del equipo.
//      • Número de Victorias.
//      • Número de Derrotas.
// Para los equipos de baloncesto añadir la siguiente información:
//      • Número de pérdidas de balón.
//      • Número de rebotes alcanzados.
//      • Nombre del mejor anotador de triples.
// Para los equipos de fútbol añadir la información:
//      • Número de empates.
//      • Número de goles a favor.
//      • Número de goles en contra.
//      • Nombre del goleador del equipo.
// Dicho programa deberá mostrar los siguientes listados:
//      • Goleadores de cada equipo de fútbol.
//      • Nombre del equipo de baloncesto con menor número de victorias de balón.
//      • Nombre del equipo de fútbol con mayor número de derrotas.

#include <stdio.h>

struct Equipo
{
        char nombre[50];
        int nVictorias;
        int nDerrotas;
};

struct EquipoBaloncesto
{
        int nPerdidasBalon;
        int nRebotesAlcanzados;
        char mejorAnotadorTriples[50];

        struct Equipo equipo;
};

struct EquipoFutbol
{
        int nEmpates;
        int nGolesFavor;
        int nGolesContra;
        char goleador[50];

        struct Equipo equipo;
};

void registrarEB(struct EquipoBaloncesto *eb, int);
void limpiarBuffer(void);

int main()
{
        int nEquiposDeBaloncesto, nEquiposDeFutbol;

        printf("Ingrese la cantidad de equipos de baloncesto: ");
        scanf("%d", &nEquiposDeBaloncesto);

        printf("Ingrese la cantidad de equipos de futbol: ");
        scanf("%d", &nEquiposDeFutbol);

        struct EquipoBaloncesto equiposBaloncesto[nEquiposDeBaloncesto];
        struct EquipoFutbol equiposFutbol[nEquiposDeFutbol];

        registrarEB(equiposBaloncesto, nEquiposDeBaloncesto);

        return 0;
}

void registrarEB(struct EquipoBaloncesto *eb, int nEquiposDeBaloncesto)
{
        for (int i = 0; i < nEquiposDeBaloncesto; i++)
        {
                limpiarBuffer();

                printf("\n--- Información equipo de baloncesto #%d ---\n\n", i + 1);

                printf("Nombre del equipo: ");
                scanf("%s", eb[i].equipo.nombre);

                printf("Cantidad de victorias: ");
                scanf("%d", &eb[i].equipo.nVictorias);

                printf("Cantidad de derrotas: ");
                scanf("%d", &eb[i].equipo.nDerrotas);

                printf("Pérdidas de balón: ");
                scanf("%d", &eb[i].nPerdidasBalon);

                printf("Rebotes alcanzados: ");
                scanf("%d", &eb[i].nRebotesAlcanzados);

                printf("Nombre del mejor anotador de triples: ");
                scanf("%s", eb[i].mejorAnotadorTriples);
        }
}

void limpiarBuffer(void)
{
        while (getchar() != '\n')
                ;
}