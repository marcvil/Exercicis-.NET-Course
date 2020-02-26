// JavaScript source code

function GetTextandSeparateByletters() {
    var x = document.getElementById("myText").value;

    var vocals = ["a", "e", "i", "o", "u"];

    //Convertir a lista 
    const Set = new Set(x);
    for (i = 0; i <= x.length; i++) {
        if (set.charAt[i] != null) {

            for (var j = 0; j <= vocals.length; j++) {
                if (set.charAt[i] == vocals[j])  //Si es vocal...?
                {
                    console.log(set.charAt[i]));
                    console.log(" ");
                    document.write(set.charAt[i] + " es una vocal." + "<br>");
                    break;
                }
                if (set.charAt[i] != vocals[j] && j >= vocals.length)  //Si no es vocal...?
                {
                    console.log(set.charAt[i]);
                    console.log(" ");
                    document.write(set.charAt[i] + " no es una vocal." + "<br>");
                    break;
                }
            }
        }
        else {
            return;
        }
    }
     
 }

