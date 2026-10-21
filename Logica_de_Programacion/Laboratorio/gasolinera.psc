// Construya un pseudocódigo que resuelva el problema que tienen en una gasolinera.
// Los surtidores de la misma registran lo que "surten" en galones, pero el precio de la
// gasolina está fijado en litros. El pseudocódigo debe calcular e imprimir lo que hay que
// cobrarle al cliente.
// Consideraciones:
//	 - Cada galón tiene 3.785 litros
//	 - El precio del litro es C$ 49.89

Proceso gasolinera
	Definir litrosGalon, litroPrecio, cantidadDeGalones, precioPago Como Real;
	
	litrosGalon = 3.785;
	litroPrecio = 49.89;
	
	Escribir "Ingrese la cantidad de galones: ";
	Leer cantidadDeGalones;
	
	precioPago = (cantidadDeGalones * litrosGalon) * litroPrecio;
	
	Escribir "Precio a pagar: ", Concatenar('C$', ConvertirATexto(precioPago));
FinProceso
