// Leer los 250000 votos otorgados a los 3 candidatos a gobernador
// e imprimir el numero del candidato ganador y su cantidad de votos.

#include <stdio.h>

int main()
{
        int voto;
        int candidato1, candidato2, candidato3;
        int cantidadDeVotos = 250000;

        int i = 1;

        do
        {
                printf("Ingrese la cantidad de votos para el candidato %d: ", i);
                scanf("%d", &voto);

                if (i == 1)
                        candidato1 = voto;
                if (i == 2)
                        candidato1 = voto;
                if (i == 3)
                        candidato1 = voto;

                cantidadDeVotos -= voto;
                i++;
        } while (cantidadDeVotos >= 0 && i <= 3);

        if (candidato1 >= candidato2 && candidato1 >= candidato3)
                printf("Ganó el candidato #1 con %d votos\n", candidato1);

        if (candidato2 >= candidato1 && candidato2 >= candidato3)
                printf("Ganó el candidato #2 con %d votos\n", candidato2);

        if (candidato3 >= candidato1 && candidato3 >= candidato2)
                printf("Ganó el candidato #3 con %d votos\n", candidato3);

        return 0;
}