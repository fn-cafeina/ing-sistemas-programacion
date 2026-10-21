// El costo de las llamadas telefonicas nacionales depende
// de la ciudad en la que se encuentre y el numero de minutos
// hablados, En la siguiente tabla se presenta el costo por
// minuto y por ciudad
//
// A cada ciudad se le asigna una clave
//
// Clave    Ciudad      Precio
// 1        Leon        2
// 5        Managua     2.2
// 8        Esteli      4.5
// 9        Matagalpa   3.5
// 13       Jinotega    6
// 2        Chinandega  6
// 15       Rivas       5
//
// Tambien, teniendo en cuante que por los primeros 8 minutos
// hablados se le cobrara 0.25 pero si se pasa de esta promocion,
// es decir, que por cada minuto extra que el cliente esta hablando
// se cobrara 0.15 mas el precio estipado para cada ciudad a la que
// se este llamando

Proceso llamadasTelefonicasSegun
	Definir minutoHablados Como Entero;
	Definir precioPorMinutos, pago Como Real;
	Definir ciudad Como Entero;
	
	precioPorMinutos = 0.25;
	
	Escribir "Ingrese la clave de la ciudad de donde hace la llamada: ";
	Escribir "Leon: 1";
	Escribir "Managua: 5";
	Escribir "Esteli: 8";
	Escribir "Matagalpa: 9";
	Escribir "Jinotega: 13";
	Escribir "Chinandega: 2";
	Escribir "Rivas: 15";
	
	Leer ciudad;
	
	Escribir "Ingrese la cantidad de minutos hablados: ";
	Leer minutoHablados;
	
	Segun ciudad Hacer
		Opcion 1:
			pago = minutoHablados * precioPorMinutos;
			
			Si (minutoHablados > 8) Entonces
				precioPorMinutos = 0.15;
				pago = (precioPorMinutos + 2) * minutoHablados;
			FinSi
		Opcion 5:
			pago = minutosHablados * precioPorMinutos;
			
			Si (minutoHablados > 8) Entonces
				precioPorMinutos = 0.15;
				pago = (precioPorMinutos + 2.2) * minutoHablados;
			FinSi
		Opcion 8:
			pago = minutoHablados * precioPorMinutos;
			
			Si (minutoHablados > 8) Entonces
				precioPorMinutos = 0.15;
				pago = (precioPorMinutos + 4.5) * minutoHablados;
			FinSi
		Opcion 9:
			pago = minutoHablados * precioPorMinutos;
			
			Si (minutoHablados > 8) Entonces
				precioPorMinutos = 0.15;
				pago = (precioPorMinutos + 3.5) * minutoHablados;
			FinSi
		Opcion 13:
			pago = minutosHablados * precioPorMinutos;
			
			Si (minutoHablados > 8) Entonces
				precioPorMinutos = 0.15;
				pago = (precioPorMinutos + 6) * minutoHablados;
			FinSi
		Opcion 2:
			pago = minutosHablados * precioPorMinutos;
			
			Si (minutoHablados > 8) Entonces
				precioPorMinutos = 0.15;
				pago = (precioPorMinutos + 6) * minutoHablados;
			FinSi
		Opcion 15:
			pago = minutosHablados * precioPorMinutos;
			
			Si (minutoHablados > 8) Entonces
				precioPorMinutos = 0.15;
				pago = (precioPorMinutos + 5) * minutoHablados;
			FinSi
	FinSegun
	
	Escribir "El precio a pagar por la llamada es: ", Concatenar("$" ConvertirATexto(pago));
FinProceso
