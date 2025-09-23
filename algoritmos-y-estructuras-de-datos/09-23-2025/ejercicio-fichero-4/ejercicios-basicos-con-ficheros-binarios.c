#include <stdio.h>

int main()
{
	int x, n, a[10] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
	int b[10];
	char nombre[] = "Ejercicios ficheros binarios";
	FILE *binario = NULL;

	binario = fopen("binario.dat", "wb");

	if (binario != NULL)
	{
		printf("Archivo listo para escribir\n\n");

		printf("Ingrese un valor entero: ");
		scanf("%d", &x);
		fwrite(&x, sizeof(int), 1, binario);

		fwrite(a, sizeof(int), 5, binario);

		fwrite(nombre, sizeof(char), 10, binario);

		fclose(binario);
		binario = fopen("binario.dat", "rb");

		fseek(binario, sizeof(int), SEEK_SET);

		fread(b, sizeof(int), 5, binario);

		printf("Extraccion de numeros\n");
		for (n = 0; n < 5; n++)
			printf("%5d", b[n]);
		printf("\n\n");

		fclose(binario);
	}
	else
	{
		printf("El archivo no se pudo abrir. Asegúrese de que la carpeta c:/FICHEROS exista.\n\n");
	}

	return 0;
}