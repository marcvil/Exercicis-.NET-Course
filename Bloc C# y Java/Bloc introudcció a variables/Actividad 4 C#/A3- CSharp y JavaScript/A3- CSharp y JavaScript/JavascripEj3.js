// JavaScript source code


    var startYear = 1948;
    var birthYear = 1994;

    var i = 1948;

    Console.Log("Los años bisiestos entre el 1948 y el año de mi nacimiento (1994) son los siguinetes: \n");
    document.write("Los años bisiestos entre el 1948 y el año de mi nacimiento (1994) son los siguinetes: <br>");
   

    for (i = 1948; i <= birthYear; i++)
        {
        var modulus4 = (i - startYear) % 4;

        if (modulus4 == 0) {

            Console.Log(i);
            document.write(i);
              

            }
        }
