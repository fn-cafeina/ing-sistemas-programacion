// Realizar un pseudocódigo que determine el valor a pagar por la compra de marcadores acrílicos,
// considerando que cada uno cuesta C$30; pero si compra a partir de 20 marcadores se le aplica un descuento del 20%.

Proceso marcadoresAcrilicos
	Definir marcadores Como Entero;
	Definir pago Como Real;
	
	Escribir "Ingrese la cantidad de marcadores a comprar: ";
	Leer marcadores;
	
	marcadores = marcadores * 30;
	
	Si marcadores >= 20 Entonces
		pago = marcadores - (marcadores * 0.20);
	SiNo
		pago = marcadores - (marcadores * 0.30);
	FinSi
	
	Escribir "El monto a pagar es de: ", "C$", pago;
FinProceso