// Un alumno desea saber cuál será su promedio general en las tres materias más difíciles
// que cursa y cuál será el promedio que obtendrá en cada una de ellas. Estas materias se
// evalúan como se muestra a continuación:
//
// La calificación de Matemáticas se obtiene de la siguiente manera:
// Examen 90%
// Promedio de tareas 10%
// En esta materia se pidió un total de tres tareas.
//
// La calificación de Física se obtiene de la sig. manera:
// Examen 80%
// Promedio de tareas 20%
// En esta materia se pidió un total de dos tareas.
//
// La calificación de Química se obtiene de la sig. manera:
// Examen 85%
// Promedio de tareas 15%
// En esta materia se pidió un promedio de tres tareas.

Proceso promedioMaterias
	Definir examenMatematicas, tareaMatematica1, tareaMatematica2, tareaMatematica3 Como Real;
	Definir examenFisica, tareaFisica1, tareaFisica2 Como Real;
	Definir examenQuimica, tareaQuimica1, tareaQuimica2, tareaQuimica3 Como Real;
	Definir promedioTareasMatematicas, promedioTareasFisica, promedioTareasQuimica Como Real;
	Definir promedioMatematicas, promedioFisica, promedioQuimica, promedioGeneral Como Real;
	
	Escribir "Ingrese la calificación del examen de Matemáticas (0-10): ";
	Leer examenMatematicas;
	Escribir "Ingrese la calificación de la tarea 1 de Matemáticas (0-10): ";
	Leer tareaMatematica1;
	Escribir "Ingrese la calificación de la tarea 2 de Matemáticas (0-10): ";
	Leer tareaMatematica2;
	Escribir "Ingrese la calificación de la tarea 3 de Matemáticas (0-10): ";
	Leer tareaMatematica3;
	
	promedioTareasMatematicas = (tareaMatematica1 + tareaMatematica2 + tareaMatematica3) / 3;
	promedioMatematicas = (examenMatematicas * 0.90) + (promedioTareasMatematicas * 0.10);
	
	Escribir "Ingrese la calificación del examen de Física (0-10): ";
	Leer examenFisica;
	Escribir "Ingrese la calificación de la tarea 1 de Física (0-10): ";
	Leer tareaFisica1;
	Escribir "Ingrese la calificación de la tarea 2 de Física (0-10): ";
	Leer tareaFisica2;
	
	promedioTareasFisica = (tareaFisica1 + tareaFisica2) / 2;
	promedioFisica = (examenFisica * 0.80) + (promedioTareasFisica * 0.20);
	
	Escribir "Ingrese la calificación del examen de Química (0-10): ";
	Leer examenQuimica;
	Escribir "Ingrese la calificación de la tarea 1 de Química (0-10): ";
	Leer tareaQuimica1;
	Escribir "Ingrese la calificación de la tarea 2 de Química (0-10): ";
	Leer tareaQuimica2;
	Escribir "Ingrese la calificación de la tarea 3 de Química (0-10): ";
	Leer tareaQuimica3;
	
	promedioTareasQuimica = (tareaQuimica1 + tareaQuimica2 + tareaQuimica3) / 3;
	promedioQuimica = (examenQuimica * 0.85) + (promedioTareasQuimica * 0.15);
	
	promedioGeneral = (promedioMatematicas + promedioFisica + promedioQuimica) / 3;
	
	Escribir "";
	Escribir "El promedio de Matemáticas es: ", promedioMatematicas;
	Escribir "El promedio de Física es: ", promedioFisica;
	Escribir "El promedio de Química es: ", promedioQuimica;
	Escribir "El promedio general en las tres materias es: ", promedioGeneral;
FinProceso
