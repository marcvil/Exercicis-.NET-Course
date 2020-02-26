// JavaScript source code

var name = "Marc";
var surname1 = "Vilà";
var surname2 = "Espuña";

var birthDay = 07;
var birthMonth = 09;
var birthYear = 1994;

var yearModulus4 = birthYear % 4;

document.write("Em dic " + name + " " + surname1 + " " + surname2 + ".");
document.write("Vaig neixer el dia " + birthDay + "/" + birthMonth + "/" + birthYear + ".");
if (yearModulus4 == 0) {
    document.write("El meu any de naixement va ser un any de traspàs.");
}
else {
    document.write("El meu any de naixement no va ser un any de traspàs.");
}


