// Dada la matrícula y 5 calificaciones de un alumno obtenidas a lo largo del semestre,
// construya un pseudocódigo que imprima la matrícula del alumno y el promedio de sus
// calificaciones.

Proceso matricula
	Definir alumnoMatricula Como Entero;
	Definir calificacion1, calificacion2, calificacion3, calificacion4, calificacion5 Como Real;
	Definir resultado Como Real;
	
	Escribir "Ingrese la matricula: ";
	Leer alumnoMatricula;
	
	Escribir "Ingrese las calificaciones: ";
	Leer calificacion1, calificacion2, calificacion3, calificacion4, calificacion5;
	
	resultado = (calificacion1 + calificacion2 + calificacion3 + calificacion4 + calificacion5) / 5;
	
	Escribir "La matricula del usuario es: ", alumnoMatricula;
	Escribir "El promedio de sus notas es: ", resultado;
FinProceso
