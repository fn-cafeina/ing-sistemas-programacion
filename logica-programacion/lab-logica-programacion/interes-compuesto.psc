Proceso InteresCompuesto
    Definir capitalI, capitalT, tasaI Como Real;
    Definir años, añoA, mesA Como Entero;
    
    Escribir "Introduce el capital inicial:";
    Leer capitalI;
    
    Escribir "Introduce la tasa de interés anual (en porcentaje):";
    Leer tasaI;
    
    Escribir "Introduce el número de años de la inversión:";
    Leer años;
    
    tasaI = tasaI / 100;
    
    capitalT = capitalI;
    
    añoA = 0;
    
    Mientras añoA < años Hacer
        mesA = 0;
        
        Mientras mesA < 12 Hacer
            capitalT = capitalT * (1 + tasaI / 12);
            mesA = mesA + 1;
        FinMientras
        
        Escribir "Capital al final del año ", añoA + 1, ": ", capitalT;
        añoA = añoA + 1;
        
    FinMientras
    
    Escribir "El capital total después de ", años, " años es: ", capitalT, "$";
FinProceso