Algoritmo AproximacionPi
    Definir n, i Como Entero;
    Definir aproximacion, termino Como Real;
    aproximacion = 0;
    i = 1;
    Escribir "Ingrese el número de términos: ";
    Leer n;
	
    Repetir
        termino = 4 * ( ( -1 ) ^ ( i + 1 ) ) / ( 2 * i - 1 );
        aproximacion = aproximacion + termino;
        i = i + 1;
    Hasta Que i > n;
	
    Escribir "Aproximación de ?: ", aproximacion;
FinAlgoritmo
