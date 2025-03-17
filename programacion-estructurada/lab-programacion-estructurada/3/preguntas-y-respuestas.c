// Elaborar un algoritmo que solicite el número de respuestas correctas e
// incorrectas y en blanco, correspondientes a postulantes, y muestre su puntaje
// final considerando, que por cada respuesta correcta tendrá 4 puntos, respuestas
// incorrectas tendrá -1 y respuestas en blanco tendrá 0.

#include <stdio.h>
#include <stdlib.h>

int main()
{
        int respuestaActual, puntuacion, respuestasCorrectas;

        system("clear");

        printf("¿Cual es la capital de Francia?\n0 - Paris\n1 - Roma \nR = ");
        scanf("%d", &respuestaActual);

        if (respuestaActual == 0)
        {
                puntuacion += 4;
                respuestasCorrectas++;
        }
        else
        {
                puntuacion -= 1;
        }

        system("clear");

        printf("¿Cuantos dias tiene un año normal?\n0 - 365\n1 - 366 \nR = ");
        scanf("%d", &respuestaActual);

        if (respuestaActual == 0)
        {
                puntuacion += 4;
                respuestasCorrectas++;
        }
        else
        {
                puntuacion -= 1;
        }

        system("clear");

        printf("¿Que planeta esta mas cerca del sol?\n0 - Mercurio\n1 - Venus \nR = ");
        scanf("%d", &respuestaActual);

        if (respuestaActual == 0)
        {
                puntuacion += 4;
                respuestasCorrectas++;
        }
        else
        {
                puntuacion -= 1;
        }

        system("clear");

        printf("Su puntuacion es: %d \n", puntuacion);
        printf("La cantidad de respuestas correctas es: %d \n", respuestasCorrectas);

        return 0;
}