// En una tienda donde se lleva el control de la venta de productos se desea calcular
// el total de ganancia que produce dicho negocio en el mes. Para ello se cuenta con la
// siguiente información por producto: precio del Costo, precio de venta, código y
// cantidad vendida en ese periodo. Realizar un programa en lenguaje C que permita
// calcular las ganancias de la tienda.
// Defina un tipo de dato llamado Producto para gestionar la información e
// implemente el mecanismo de asignación dinámica de memoria.

#include <stdio.h>
#include <stdlib.h>

// Definición del tipo de dato Producto
typedef struct
{
        int codigo;
        float precioCosto;
        float precioVenta;
        int cantidadVendida;
} Producto;

// Función para crear un nuevo producto
// Esta función crea un nuevo producto asignando dinámicamente memoria para
// un Producto y luego inicializa sus campos. Devuelve un puntero al nuevo producto.
Producto *crearProducto(int codigo, float precioCosto, float precioVenta, int cantidadVendida)
{
        // Asigne al puntero nuevoProducto un bloque de memoria del tipo Producto
        Producto *nuevoProducto = malloc(sizeof(Producto));

        if (nuevoProducto != NULL)
        {
                // Asignar campos
                nuevoProducto->codigo = codigo;
                nuevoProducto->precioCosto = precioCosto;
                nuevoProducto->precioVenta = precioVenta;
                nuevoProducto->cantidadVendida = cantidadVendida;
        }

        return nuevoProducto;
}

float calcularGanancia(Producto *p)
{
        // precio de venta – precio de costo multiplicado por la cantidad vendida
        return (p->precioVenta - p->precioCosto) * p->cantidadVendida;
}

// Función para calcular la ganancia total
// Recibe un arreglo de punteros a productos y calcula la ganancia total sumando
// las ganancias de todos los productos.
float calcularGananciaTotal(Producto **productos, int cantidadProductos)
{
        float gananciaTotal = 0.0;

        for (int i = 0; i < cantidadProductos; i++)
        {
                // Llamar a la función calcularGanancia
                gananciaTotal += calcularGanancia(productos[i]);
        }

        return gananciaTotal;
}

int main()
{
        int cantidadProductos;

        Producto **productos = NULL;

        int codigo;

        float precioCosto, precioVenta;

        int cantidadVendida;

        // Solicitar la cantidad de productos
        printf("Ingrese la cantidad de productos: ");
        scanf("%d", &cantidadProductos);

        // Asignación dinámica de memoria para un arreglo de punteros a productos
        productos = malloc(sizeof(Producto));

        if (productos == NULL)
        {
                printf("Error al asignar memoria.\n");
                return 1;
        }

        for (int i = 0; i < cantidadProductos; i++)
        {
                printf("Producto %d:\n", i + 1);
                printf("Código: ");
                scanf("%d", &codigo);
                printf("Precio de Costo: ");
                scanf("%f", &precioCosto);
                printf("Precio de Venta: ");
                scanf("%f", &precioVenta);
                printf("Cantidad Vendida: ");
                scanf("%d", &cantidadVendida);

                // Crear el producto y asignarlo al arreglo de punteros
                // Llamar a la función correspondiente.
                productos[i] = crearProducto(codigo, precioCosto, precioVenta, cantidadVendida);

                // Verificación de que el producto fue creado correctamente
                if (productos[i] == NULL)
                {
                        printf("Error al asignar memoria para el producto.\n");
                        return 1;
                }
        }

        // Calcular y mostrar la ganancia total
        float gananciaTotal = calcularGananciaTotal(productos, cantidadProductos);
        printf("La ganancia total de la tienda en el mes es: %.2f\n", gananciaTotal);

        for (int i = 0; i < cantidadProductos; i++)
        {
                free(productos[i]);
        }

        // Libera la memoria asignada al arreglo de punteros
        free(productos);

        return 0;
}