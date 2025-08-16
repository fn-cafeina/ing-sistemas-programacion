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
#include <string.h>

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
void registrarEF(struct EquipoFutbol *ef, int);
void mostrarGoleadoresFutbol(struct EquipoFutbol *ef, int);
void mostrarEquipoBaloncestoMenosVictorias(struct EquipoBaloncesto *eb, int);
void mostrarEquipoFutbolMasDerrotas(struct EquipoFutbol *ef, int);
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
        registrarEF(equiposFutbol, nEquiposDeFutbol);

        mostrarGoleadoresFutbol(equiposFutbol, nEquiposDeFutbol);
        mostrarEquipoBaloncestoMenosVictorias(equiposBaloncesto, nEquiposDeBaloncesto);
        mostrarEquipoFutbolMasDerrotas(equiposFutbol, nEquiposDeFutbol);

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

void registrarEF(struct EquipoFutbol *ef, int nEquiposDeFutbol)
{
        for (int i = 0; i < nEquiposDeFutbol; i++)
        {
                limpiarBuffer();

                printf("\n\n--- Información equipo de futbol #%d ---\n\n", i + 1);

                printf("Nombre del equipo: ");
                scanf("%s", ef[i].equipo.nombre);

                printf("Cantidad de victorias: ");
                scanf("%d", &ef[i].equipo.nVictorias);

                printf("Cantidad de derrotas: ");
                scanf("%d", &ef[i].equipo.nDerrotas);

                printf("Empates: ");
                scanf("%d", &ef[i].nEmpates);

                printf("Goles a favor: ");
                scanf("%d", &ef[i].nGolesFavor);

                printf("Goles en contra : ");
                scanf("%d", &ef[i].nGolesContra);

                printf("Nombre del goleador del equipo: ");
                scanf("%s", ef[i].goleador);
        }
}

void mostrarGoleadoresFutbol(struct EquipoFutbol *ef, int nEquiposDeFutbol)
{
        printf("\n\n--- Goleadores de cada equipo de fútbol ---\n");

        for (int i = 0; i < nEquiposDeFutbol; i++)
        {
                printf("Equipo: %s, Goleador: %s\n", ef[i].equipo.nombre, ef[i].goleador);
        }
}

void mostrarEquipoBaloncestoMenosVictorias(struct EquipoBaloncesto *eb, int nEquiposDeBaloncesto)
{
        if (nEquiposDeBaloncesto == 0)
        {
                printf("\n\nNo hay equipos de baloncesto para mostrar.\n");
                return;
        }

        int minVictorias = eb[0].equipo.nVictorias;
        char nombreEquipoMenosVictorias[50];

        strcpy(nombreEquipoMenosVictorias, eb[0].equipo.nombre);

        for (int i = 1; i < nEquiposDeBaloncesto; i++)
        {
                if (eb[i].equipo.nVictorias < minVictorias)
                {
                        minVictorias = eb[i].equipo.nVictorias;
                        strcpy(nombreEquipoMenosVictorias, eb[i].equipo.nombre);
                }
        }

        printf("\n\n--- Equipo de baloncesto con menor número de victorias ---\n");
        printf("Nombre del equipo: %s (Victorias: %d)\n", nombreEquipoMenosVictorias, minVictorias);
}

void mostrarEquipoFutbolMasDerrotas(struct EquipoFutbol *ef, int nEquiposDeFutbol)
{
        if (nEquiposDeFutbol == 0)
        {
                printf("\n\nNo hay equipos de fútbol para mostrar.\n");
                return;
        }

        int maxDerrotas = ef[0].equipo.nDerrotas;
        char nombreEquipoMasDerrotas[50];

        strcpy(nombreEquipoMasDerrotas, ef[0].equipo.nombre);

        for (int i = 1; i < nEquiposDeFutbol; i++)
        {
                if (ef[i].equipo.nDerrotas > maxDerrotas)
                {
                        maxDerrotas = ef[i].equipo.nDerrotas;
                        strcpy(nombreEquipoMasDerrotas, ef[i].equipo.nombre);
                }
        }

        printf("\n\n--- Equipo de fútbol con mayor número de derrotas ---\n");
        printf("Nombre del equipo: %s (Derrotas: %d)\n", nombreEquipoMasDerrotas, maxDerrotas);
}

void limpiarBuffer(void)
{
        while (getchar() != '\n')
                ;
}