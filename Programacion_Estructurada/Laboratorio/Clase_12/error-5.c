#include <stdio.h>
#include <string.h>

int main()
{
	float comp, des, tot;
	char colbol[20];
	char res[2];

	do
	{
		printf("\nIngrese el color de la bolita: ");
		scanf("%s", colbol);

		printf("\nIngrese el importe de la compra: ");
		scanf("%f", &comp);

		if (strcmp(colbol, "rojo") == 0)
			des = comp * 0.40;
		else
		{
			if (strcmp(colbol, "amarillo") == 0)
				des = comp * 0.25;
			else
			{
				if (strcmp(colbol, "blanco") == 0)
					des = 0;
				else
					printf("\nColor invalido");
			}
		}

		tot = comp - des;

		printf("\nCantidad a pagar es: %.2f\n", tot);

		printf("\nDesea introducir otro cliente: ");
		scanf("%s", res);
	} while (strcmp(res, "S") == 0 || strcmp(res, "s") == 0);

	return 0;
}