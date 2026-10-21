// Elaborar un algoritmo que solicite el número de respuestas correctas e
// incorrectas y en blanco, correspondientes a postulantes, y muestre su puntaje
// final considerando, que por cada respuesta correcta tendrá 4 puntos, respuestas
// incorrectas tendrá -1 y respuestas en blanco tendrá 0.

#include <stdio.h>
#include <stdlib.h>

int main()
{
        int respuestaActual = 0, puntuacion = 0, respuestasCorrectas = 0;
        char *preguntas[3] = {"¿Cual es la capital de Francia?\n1 - Paris\n2 - Roma \n3 - No se \nR = ",
                              "¿Cuantos dias tiene un año normal?\n1 - 365\n2 - 366 \n3 - No se \nR = ",
                              "¿Que planeta esta mas cerca del sol?\n1 - Mercurio\n2 - Venus \n3 - No se \nR = "};

        system("clear");

        for (int i = 0; i < 3; i++)
        {
                printf("%s", preguntas[i]);
                scanf("%d", &respuestaActual);

                if (respuestaActual == 1)
                {
                        puntuacion += 4;
                        respuestasCorrectas++;
                }
                else if (respuestaActual == 2)
                {
                        puntuacion -= 1;
                }
                else if (respuestaActual == 3)
                {
                        puntuacion += 0;
                }

                system("clear");
        }

        printf("Su puntuacion es: %d \n", puntuacion);
        printf("La cantidad de respuestas correctas es: %d \n", respuestasCorrectas);

        return 0;
}