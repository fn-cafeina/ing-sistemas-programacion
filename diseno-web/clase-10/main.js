function ejercicio1() {
  const num = parseInt(prompt("Ingrese un número:"));
  alert(num > 100 ? "Es mayor que 100" : "No es mayor que 100");
}

function ejercicio2() {
  const a = parseFloat(prompt("Nota 1:"));
  const b = parseFloat(prompt("Nota 2:"));
  const c = parseFloat(prompt("Nota 3:"));
  const promedio = (a + b + c) / 3;
  alert(promedio >= 60 ? "Aprobado" : "Reprobado");
}

function ejercicio3() {
  const cantidad = parseInt(prompt("Cantidad de camisetas:"));
  const precio = 10;
  const descuento = cantidad >= 12 ? 0.2 : 0.1;
  const total = cantidad * precio * (1 - descuento);
  alert(`Total a pagar: $${total.toFixed(2)}`);
}

function ejercicio4() {
  const horas = parseInt(prompt("Horas trabajadas:"));
  const salario = horas <= 40
    ? horas * 20
    : 40 * 20 + (horas - 40) * 25;
  alert(`Salario: $${salario}`);
}

function ejercicio5() {
  let suma = 0, count = 0;
  while (count < 5) {
    const num = parseInt(prompt("Ingrese número positivo:"));
    if (num > 0) {
      suma += num;
      count++;
    }
  }
  alert(`Suma: ${suma}`);
}

function ejercicio6() {
  let suma = 0;
  for (let i = 2; i <= 100; i += 2) suma += i;
  alert(`Suma de pares: ${suma}`);
}

function ejercicio7() {
  const num = parseInt(prompt("Número para tabla:"));
  let salida = "";
  for (let i = 1; i <= 10; i++) {
    salida += `${num} x ${i} = ${num * i}\n`;
  }
  alert(salida);
}

function ejercicio8() {
  let num = parseInt(prompt("Número inicial:"));
  let secuencia = "";
  while (num !== 1) {
    secuencia += num + ", ";
    num = num % 2 === 0 ? num / 2 : num * 3 + 1;
  }
  secuencia += "1";
  alert(secuencia);
}

function ejercicio9() {
  let salida = "";
  for (let n = 1; n <= 5; n++) {
    let f = 1;
    for (let i = 1; i <= n; i++) f *= i;
    salida += `!${n} = ${f}\n`;
  }
  alert(salida);
}

function ejercicio10() {
  const fib = [0, 1];
  for (let i = 2; i < 50; i++) {
    fib.push(fib[i - 1] + fib[i - 2]);
  }
  alert(fib.join(", "));
}
