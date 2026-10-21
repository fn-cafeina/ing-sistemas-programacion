// Realice un programa en C que, al recibir como dato el precio de un producto,
// incremente 11% el mismo si es inferior a 12,000 y 8% si fuera mayor o igual a dicho
// precio; además, debe escribir el nuevo precio del producto.

#include <stdio.h>

int main()
{
        float producto;
        int incremento;

        printf("Ingrese el precio del producto: ");
        scanf("%f", &producto);

        if (producto < 12000)
        {
                incremento = 11;
                producto = producto + (incremento * producto / 100);
        }

        if (producto >= 12000)
        {
                incremento = 8;
                producto = producto + (incremento * producto / 100);
        }

        printf("El nuevo precio del producto es: %.2f\n", producto);
        printf("El incremento ha sido del: %d%c\n", incremento, '%');

        return 0;
}