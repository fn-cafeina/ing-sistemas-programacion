// En una elección realizada en Piedra Dura se presentaron tres candidatos: Pedro, Pablo y
// Vilma. Por cada votante se tiene la siguiente información:
//
// Piedracédula: Número de cédula del votante. Dentro de sus posibles valores no tiene uno que
// sea cero o negativo. El ciclo de entrada de datos terminará cuando encuentre un valor de cero
// para el campo piedracédula.
// Opción: Campo que indica el candidato escogido, si el valor del campo es:
// 1: votó por Pedro
// 2: votó por Pablo
// 3: votó por Vilma
// 4: votó en blanco
// Elaborar un programa que muestre el número de votos depositados por cada cantidato y el
// total de votantes.

#include <stdio.h>

int main()
{
        int piedracedula, opcion;
        int votosPedro = 0, votosPablo = 0, votosVilma = 0, votosBlanco = 0, totalVotantes = 0;

        for (;;)
        {
                printf("Ingrese la piedracédula (0 para terminar): ");
                scanf("%d", &piedracedula);

                if (piedracedula == 0)
                {
                        break;
                }

                printf("Ingrese la opción (1: Pedro, 2: Pablo, 3: Vilma, 4: Blanco): ");
                scanf("%d", &opcion);

                totalVotantes++;

                switch (opcion)
                {
                case 1:
                        votosPedro++;
                        break;
                case 2:
                        votosPablo++;
                        break;
                case 3:
                        votosVilma++;
                        break;
                case 4:
                        votosBlanco++;
                        break;
                default:
                        printf("Opción inválida.\n");
                        totalVotantes--;
                        break;
                }
        }

        printf("\nResultados de la elección:\n");
        printf("Votos por Pedro: %d\n", votosPedro);
        printf("Votos por Pablo: %d\n", votosPablo);
        printf("Votos por Vilma: %d\n", votosVilma);
        printf("Votos en blanco: %d\n", votosBlanco);
        printf("Total de votantes: %d\n", totalVotantes);

        return 0;
}