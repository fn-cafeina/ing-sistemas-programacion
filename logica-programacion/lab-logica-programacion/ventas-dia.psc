Proceso ventasDia
	Definir numProductos, i Como Entero;
	Definir ventas Como Real;
	Definir totalVentas, precioMayor, precioMenor Como Real;
	Definir precios Como Real;
	
	Escribir "¿Cuantos productos se vendieron hoy?";
	Leer numProductos;
	
	Dimension precios[numProductos];
	
	totalVentas = 0;
	
	Para i = 0 Hasta numProductos - 1 Hacer
		Escribir "Introduce el precio del producto ", i + 1;
		Leer precios[i];
		
		totalVentas = totalVentas + precios[i];
		
		Si i == 0 Entonces
			precioMayor = precios[i];
			precioMenor = precios[i];
		SiNo
			Si precios[i] > precioMayor Entonces
				precioMayor = precios[i];
			FinSi
			
			Si precios[i] < precioMenor Entonces
				precioMenor = precios[i];
			FinSi
		FinSi
	FinPara
	
	Escribir "El total de ventas del dia son: ", totalVentas;
	Escribir "El producto con el precio mas barato es: ", precioMenor;
	Escribir "El producto con el precio mas caro es: ", precioMayor;
FinProceso