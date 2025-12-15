// El director de una escuela está planificando un viaje para sus alumnos,
// y requiere determinar cuánto debe cobrar a cada alumno y cuánto debe pagar a la empresa de viajes por el servicio.
// La forma de cobrar es la siguiente: si son 200 alumnos o más, el costo por cada alumno es de C$55; si no, el costo es de C$75.
// Determine cuánto debe pagar el director a la empresa de transporte.

Proceso alumnos
	Definir cantidadAlumnos, pago Como Entero;
	
	Escribir "Ingrese la cantidad de alumnos: ";
	Leer cantidadAlumnos;
	
	Si cantidadAlumnos >= 200 Entonces
		pago = cantidadAlumnos * 55;
	SiNo
		pago = cantidadAlumnos * 75;
	FinSi
	
	Escribir "El monto a pagar a la empresa es de: ", "C$", pago;
FinProceso
