// Una tienda de donas las ha puesto en promoción,
// ofreciendo un descuento del 10% por la compra de más de 20 donas y 5% en caso contrario.
// Considere que cada dona cuesta C$30. Diseñar un algoritmo que determine el monto de la compra,
// el descuento, el monto a pagar.

Proceso tiendaDonas
	Definir donas Como Entero;
	Definir descuento, pago Como Real;
	
	Escribir "Ingrese la cantidad de donas a comprar:";
	Leer donas;
	
	donas = donas * 30;
	
	Si donas >= 20 Entonces
		descuento = 0.10;
		pago = donas - (donas * descuento);
	SiNo
		descuento = 0.05;
		pago = donas - (donas * descuento);
	FinSi
	
	Escribir "El monto a pagar es de: ", "$", pago;
	Escribir "El descuento aplicado es de: ", descuento;
FinProceso