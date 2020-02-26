// JavaScript source code

function GetTextandSeparateByletters() {
    var x = document.getElementById("myText").value;
    for (i = 0; i <= x.length; i++) {
        if (x.charAt(i) != null) {
            console.log(x.charAt(i));
            console.log(" ");
            document.write(x.charAt(i) + "<br>");

        }

        else {
            return;
        }
    }



}
