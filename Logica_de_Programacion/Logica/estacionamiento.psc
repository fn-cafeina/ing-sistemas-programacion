// El dueño de un estacionamiento requiere un pseudocódigo que le permita determinar
// cuánto debe cobrar por el uso del estacionamiento a sus clientes.
// Las tarifas que se tienen son las siguientes: las tres primeras horas a C$100 c/u. Las siguientes a C$80 c/u.

Proceso estacionamiento
	Definir horas, pago Como Entero;
	
	Escribir "Ingrese la cantidad de horas que ocupara el estacionamiento: ";
	Leer horas;
	
	Si horas >= 3 Entonces
		pago = horas * 80;
	SiNo
		pago = horas * 100;
	FinSi
	
	Escribir "El monto a pagar es de: ", "C$", pago;
FinProceso
