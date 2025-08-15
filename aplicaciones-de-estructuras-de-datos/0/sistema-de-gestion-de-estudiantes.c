// Cree un programa en C que permita registrar un máximo de 5 estudiantes.
// Por cada estudiante, se debe guardar:
// • Nombre (máximo 30 caracteres)
// • Edad (entero)
// • Promedio final (float)
// El programa debe:
// 1. Permitir ingresar los datos de todos los estudiantes.
// 2. Mostrar la lista completa de estudiantes registrados.
// 3. Calcular y mostrar el estudiante con el promedio más alto.
// 4. Realizar su respectivo diagrama de flujo de dicho código.
// 5. Su salida deberá presentar los datos del estudiante como Nombre su edad su correo y promedio.
// 6. Se deberá enviar a la plataforma captura del código y su salida.

#include <stdio.h>

#define N_ESTUDIANTES 5

struct Estudiante
{
  char nombre[30];
  char correo[50];
  int edad;
  float promedio;
};

int main()
{
  struct Estudiante estudiantes[N_ESTUDIANTES];

  for (size_t i = 0; i < N_ESTUDIANTES; i++)
  {
    printf("\nRegistro estudiante #%d\n", i + 1);

    printf("Nombre: ");
    scanf("%s", estudiantes[i].nombre);

    printf("Correo: ");
    scanf("%s", estudiantes[i].correo);

    printf("Edad: ");
    scanf("%d", &estudiantes[i].edad);

    float nota1, nota2, nota3;

    printf("Ingrese la nota de Calculo: ");
    scanf("%f", &nota1);

    printf("Ingrese la nota de Fisica: ");
    scanf("%f", &nota2);

    printf("Ingrese la nota de Programacion: ");
    scanf("%f", &nota3);

    estudiantes[i].promedio = (nota1 + nota2 + nota3) / 3;
  }

  float mayorPromedio = 0;
  int posicion;

  for (size_t i = 0; i < N_ESTUDIANTES; i++)
  {
    if (estudiantes[i].promedio > mayorPromedio)
    {
      mayorPromedio = estudiantes[i].promedio;
      posicion = i;
    }
  }

  printf("\nEl estudiante #%d tiene el mejor promedio.\n", posicion + 1);
  printf("Nombre: %s\n", estudiantes[posicion].nombre);
  printf("Correo: %s\n", estudiantes[posicion].correo);
  printf("Edad: %d\n", estudiantes[posicion].edad);
  printf("Promedio: %.2f\n", estudiantes[posicion].promedio);

  return 0;
}