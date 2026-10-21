// Construya un pseucodigo tal que dado como datos
// la categoria y el sueldo de un trabajador, calcule el aumento
// correspondiente teniendo en cuenta lo siguiente:
//
// - Si el trabajador se encuentra en al categoria 1, el aumento del sueldo
//   sera del 15%
//
// - Si se encuentra en la categoria 2, el aumento sera del 10%
//
// - Si esta en la categoria 3, el aumento sera del 8%
//
// - Si es de la categoria 4, el aumento sera del 7%

Proceso aumentoTrabajador
	Definir categoria Como Entero;
	Definir sueldo Como Real;
	Definir mensaje Como Caracter;
	
	mensaje = "No hay aumento";
	
	Escribir Sin Saltar "Ingrese el sueldo fijo del trabajador: ";
	Leer sueldo;
	
	Escribir Sin Saltar "Ingrese la categoria en la que se encuentra el trabajador (1 - 4): ";
	Leer categoria;
	
	Si (categoria == 1) Entonces
		sueldo = sueldo + (sueldo * 0.15);
		mensaje = "El aumento del sueldo es del 15%";
	Fin Si
	
	Si (categoria == 2) Entonces
		sueldo = sueldo + (sueldo * 0.10);
		mensaje = "El aumento del sueldo es del 10%";
	Fin Si
	
	Si (categoria == 3) Entonces
		sueldo = sueldo + (sueldo * 0.08);
		mensaje = "El aumento del sueldo es del 8%";
	Fin Si
	
	Si (categoria == 4) Entonces
		sueldo = sueldo + (sueldo * 0.07);
		mensaje = "El aumento del sueldo es del 7%";
	Fin Si
	
	Escribir "El porcentaje del aumento es: ", mensaje;
	Escribir "El sueldo + el aumento (si lo hay) es: ", sueldo;
FinProceso	