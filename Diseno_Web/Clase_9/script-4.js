const n1 = parseInt(prompt("Ingrese un número"));
const n2 = parseInt(prompt("Ingrese otro número"));

const nPow = Math.pow(n2, n2);

alert(
  `Potencia de ${n2}: ${nPow}\n${n1} elevado a ${nPow}: ${Math.pow(n1, nPow)}`
);
