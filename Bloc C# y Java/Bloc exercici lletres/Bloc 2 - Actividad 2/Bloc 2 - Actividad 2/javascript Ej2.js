// JavaScript source code

function GetTextandSeparateByletters() {
    
        var x = document.getElementById("myText").value;

        var vocals = ["a", "e", "i", "o", "u"];


        for (i = 0; i <= x.length; i++) {
            if (x.charAt(i) != null) {

                for (var j = 0; j <= vocals.length; j++) {
                    if (x.charAt(i) == vocals[j])  //Si es vocal...?
                    {
                        console.log(x.charAt(i));
                        console.log(" ");
                        document.write(x.charAt(i) + " es una vocal." + "<br>");
                        break;
                    }
                    if (x.charAt(i) != vocals[j] && j >= vocals.length)  //Si no es vocal...?
                    {
                        console.log(x.charAt(i));
                        console.log(" ");
                        document.write(x.charAt(i) + " no es una vocal." + "<br>");
                        break;
                    }
                }
            }
            else {
                return;
            }
        }
    


}