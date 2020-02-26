using System;
using System.Collections.Generic;

namespace Blo_5__Práctica_Troncal_A1
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            bool looping = true;
            Dictionary<string, float> listaNotas = new Dictionary<string, float>();

            Console.WriteLine("Hola Profesor! Esta es una aplicación para ayudarte a analizar las notas de tus alumnos.");

            ShowMainMenu();

            while (looping)
            {
                option = EntradaIntPorConsola();

                if (option == 1)
                {
                    AñadirNotas(listaNotas);
                    Console.Clear();
                    ShowMainMenu();
                    
                }
                else if (option == 2)
                {
                     MuestraNotas(listaNotas);
                     
                     ShowMainMenu();
                }
                else if(option == 3)
                {
                    AnalisisDatos(listaNotas);
                }
                else if (option == 4)
                {
                    Console.Clear();
                    ShowMainMenu();
                }
                else
                {
                    Console.WriteLine("El número no es valido. Vuelve a introducir los datos.");
                    ShowMainMenu();
                }
            }

            Console.ReadKey();
        }


        #region funciones del Menu

        static void AnalisisDatos(Dictionary<string, float> listaNotas)
        {
            Console.Clear();
            Dictionary<string, float> listaNotasTemporal = new Dictionary<string, float>();
            listaNotasTemporal = listaNotas;
            bool loopAnalisis =true;
            int option2;
            ShowAnalisisMenu();

            while (loopAnalisis)
            {
                option2 = EntradaIntPorConsola();

                if(option2 == 1)
                {
                    AverageNotas(listaNotasTemporal);
                    
                    ShowAnalisisMenu();
                }
                else if (option2 == 2)
                {
                    MinNota(listaNotasTemporal);
                    
                    ShowAnalisisMenu();
                }
                else if (option2 == 3)
                {
                    MaxNota(listaNotasTemporal);
                    
                    ShowAnalisisMenu();
                }
                else if (option2 == 4)
                {
                    loopAnalisis = false;
                }
            }
            ShowMainMenu();
        }
        static Dictionary<string,float> AñadirNotas(Dictionary<string, float> listaNotas)
        {
            Console.Clear();
            Dictionary<string, float> listaNotasTemporal = new Dictionary<string, float>();
            listaNotasTemporal = listaNotas;
            int studentNumber = 1;
            int option2 = 1;
            while(option2 == 1)
            {
                Console.WriteLine("Entra el nombre del alumno " + studentNumber);
                string nombreAlumno = ReadIsString();
                Console.WriteLine("Entra la nota del alumno. Utiliza una coma para los decimales!!");
                float nota = EntradaFloatPorConsola();
                listaNotasTemporal.Add(nombreAlumno, nota);
                studentNumber++;

                Console.WriteLine("¿Quieres seguir añadiendo notas? Pulsa 1 para seguir y 0 para salir.");
                option2 = EntradaIntPorConsola();
                Console.Clear();
            }

            return listaNotasTemporal;
        }

        static void MuestraNotas(Dictionary<string, float> listaNotas)
        {
            
            Console.WriteLine("Esta es la lista de las notas hasta el momento.");
            foreach (KeyValuePair<string, float> notaAlumno in listaNotas)
            {
                Console.WriteLine("Nombre: {0}, Nota: {1}", notaAlumno.Key, notaAlumno.Value);
            }
            Console.WriteLine("Pulsa cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion

        #region Text Menus
        static void ShowMainMenu()
        {
            Console.WriteLine("Elige una opción de las siguientes: ");

            Console.WriteLine("1. Añadir las notas de los alumnos.");
            Console.WriteLine("2. Mostrar la lista de notas actual.");
            Console.WriteLine("3. Análisis estadístico de las notas.");
            Console.WriteLine("4. Limpiar la consola.");

        }
        static void ShowAnalisisMenu()
        {
            Console.WriteLine("Elige una opción de las siguientes: ");

            Console.WriteLine("1. Ver la nota media de todos los alumnos.");
            Console.WriteLine("2. Ver el alumno con la nota mínima.");
            Console.WriteLine("3. Ver el alumno con la nota máxima.");
            Console.WriteLine("4. Volver al menú principal");

        }

        #endregion 

        #region funciones estadísticas

        static void AverageNotas(Dictionary<string, float> listaNotas)
        {
            Console.Clear();
            float notaMedia = 0;
            foreach (KeyValuePair<string, float> notaAlumno in listaNotas)
            {
                notaMedia += notaAlumno.Value;
            }
            Console.WriteLine("La nota media de los alumnos de este curso es de: " + (notaMedia/listaNotas.Count));
            Console.WriteLine("");
            Console.WriteLine("Pulsa cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        static void MaxNota(Dictionary<string, float> listaNotas)
        {
            Console.Clear();
            float maxNota = 0;
            string nombreNotaMax = "";
            foreach (KeyValuePair<string, float> notaAlumno in listaNotas)
            {
                if ( maxNota< notaAlumno.Value)
                {
                    maxNota = notaAlumno.Value;
                    nombreNotaMax = notaAlumno.Key;
                }
            }
            Console.WriteLine("El alumno con la nota máxima es: " + nombreNotaMax + " con una nota de " + maxNota);
            Console.WriteLine("");
            Console.WriteLine("Pulsa cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();

        }
        static void MinNota(Dictionary<string, float> listaNotas)
        {
            Console.Clear();
            float minNota = 10;
            string nombreNotaMin = "";
            foreach (KeyValuePair<string, float> notaAlumno in listaNotas)
            {
                if (minNota > notaAlumno.Value)
                {
                    minNota = notaAlumno.Value;
                    nombreNotaMin = notaAlumno.Key;
                }
            }
            Console.WriteLine("El alumno con la nota máxima es: " + nombreNotaMin + " con una nota de " + minNota);
            Console.WriteLine("");
            Console.WriteLine("Pulsa cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();

        }

        #endregion

        #region funciones Input 


        static int EntradaIntPorConsola()
        {
            int input =Int32.Parse(Console.ReadLine());


            return input;
        }
        static float EntradaFloatPorConsola()
        {
            float input = float.Parse(Console.ReadLine());
            
                
            return input;
        }

        static string ReadIsString()
        {
            string str = Console.ReadLine();
            if (str != null && str is string)
            {
                return str;
            }
            else
            {
                return "undefined";
            }
        }
        #endregion
    }
}