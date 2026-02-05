// Realizar un pseudocódigo que permita calcular el costo
// por la compra de N hamburguesas considerando que:
// la hamburguesa sencilla cuesta C$110, la hamburguesa doble cuesta C$200,
// y la hamburguesa especial cuesta C$300. Además,
// si la persona paga con tarjeta de crédito se le carga el 5% adicional.
// Considere que la persona sólo puede comprar un tipo de hamburguesa

Proceso compraHamburguesas
	Definir cantidadHamburguesas, tipoHamburguesa, pagoTarjeta Como Entero;
	Definir pago Como Real;
	
	Escribir "Ingrese la cantidad de hamburguesas a comprar: ";
	Leer cantidadHamburguesas;
	
	Escribir "Ingrese el tipo de hamburguesa: ";
	
	Escribir "0 - Sencilla";
	Escribir "1 - Doble";
	Escribir "2 - Especial";
	
	Leer tipoHamburguesa;
	
	Escribir "Pagara con tarjeta?";
	Escribir "0 - NO";
	Escribir "1 - SI";
	
	Leer pagoTarjeta;
	
	Si tipoHamburguesa == 0 Entonces
		pago = cantidadHamburguesas * 110;
	FinSi
	
	Si tipoHamburguesa == 1 Entonces
		pago = cantidadHamburguesas * 200;
	FinSi
	
	Si tipoHamburguesa == 2 Entonces
		pago = cantidadHamburguesas * 300;
	FinSi
	
	Si pagoTarjeta == 1 Entonces
		pago = pago + (pago * 0.05);
	FinSi
	
	Escribir "La cantidad a pagar es de: ", "C$", pago;
FinProceso