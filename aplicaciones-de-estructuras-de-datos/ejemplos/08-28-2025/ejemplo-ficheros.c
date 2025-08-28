#include <stdio.h>

void menu();
void CrearFichero(FILE *Fichero);
void InsertarDatos(FILE *Fichero);
void VerDatos(FILE *Fichero);

struct sRegistro
{
        char Nombre[25];
        int Edad;
        float Sueldo;
} registro;

int main()
{
        int opcion;
        int exit = 0;

        FILE *fichero;

        while (!exit)
        {
                menu();

                printf("\nOpcion: ");
                scanf("%d", &opcion);

                switch (opcion)
                {
                case 1:
                        CrearFichero(fichero);
                        break;
                case 2:
                        InsertarDatos(fichero);
                        break;
                case 3:
                        VerDatos(fichero);
                        break;
                        exit = 1;
                        break;
                default:
                        printf("\nopcion no valida");
                }
        }

        return 0;
}

void menu()
{
        printf("\nMenu:");
        printf("\n\t1. Crear fichero");
        printf("\n\t2. Insertar datos");
        printf("\n\t3. Ver datos");
        printf("\n\t4. Salir");
}

void CrearFichero(FILE *Fichero)
{
        Fichero = fopen("fichero.txt", "r");

        if (!Fichero)
        {
                Fichero = fopen("fichero.txt", "w");
                printf("\nArchivo creado!");
        }
        else
        {
                printf("\nEl fichero ya existe!");
        }

        fclose(Fichero);

        return;
}

void InsertarDatos(FILE *Fichero)
{
        Fichero = fopen("fichero.txt", "a+");

        if (Fichero == NULL)
        {
                printf("\nFichero no existe! \nPor favor creelo");
                return;
        }

        printf("\nDigita el nombre: ");
        scanf("%s", &registro.Nombre);

        printf("\nDigita la edad: ");
        scanf("%d", &registro.Edad);

        printf("\nDigita el sueldo: ");
        scanf("%f", &registro.Sueldo);

        fwrite(&registro, sizeof(struct sRegistro), 1, Fichero);
        fclose(Fichero);

        return;
}

void VerDatos(FILE *Fichero)
{
        int numero = 1;

        Fichero = fopen("fichero", "r");

        if (Fichero == NULL)
        {
                printf("\nFichero no existe! \nPor favor creelo");
                return;
        }

        fread(&registro, sizeof(struct sRegistro), 1, Fichero);

        printf("\nNumero \tNombre \tEdad \tSueldo");

        while (!feof(Fichero))
        {
                printf("\n%d \t%s \t%d \t%.2f", numero, registro.Nombre,
                       registro.Edad, registro.Sueldo);

                fread(&registro, sizeof(struct sRegistro), 1, Fichero);

                numero++;
        }

        fclose(Fichero);

        return;
}