using System;
using System.Collections.Generic;

namespace Blo_5__Práctica_Troncal_A2
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            bool looping = true;
            Dictionary<string, float> listaNotas = new Dictionary<string, float>();
           
            Dictionary<int, Persona> listaStudent = new Dictionary<int, Persona>();
            Dictionary<Persona,List<Subject>> listaSubject;

            Dictionary<Subject, Exam> listaExam;

            List<Dictionary<Persona, List<Subject>>> listaSubjectList = new List<Dictionary<Persona, List<Subject>>>();

            Console.WriteLine("Hola Profesor! Esta es una aplicación para ayudarte a analizar las notas de tus alumnos.");

            ShowMainMenu();

            while (looping)
            {
                option = EntradaIntPorConsola();

                if (option == 1)
                {
                    AñadirStudent(listaStudent);
                    Console.Clear();
                    ShowMainMenu();

                }
                else if (option == 2)
                {

                    MuestraAlumnos(listaStudent);
                    ShowMainMenu();
                }
                else if (option == 3)
                {
                    // AñadirSubjectAStudent(listaStudent);
                    // Dictionary<Persona, List<Subject>> listaSubjectTemporary = new Dictionary<Persona, List<Subject>>();
                    // listaSubjectTemporary= AñadirSubjectAStudent(listaStudent);
                    listaSubjectList.Add(AñadirSubjectAStudent(listaStudent));
                    ShowMainMenu();
                }
                else if (option == 4)
                {
                    MuestraAsignaturasdeAlumno(listaStudent,listaSubjectList);
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
            bool loopAnalisis = true;
            int option2;
            ShowAnalisisMenu();

            while (loopAnalisis)
            {
                option2 = EntradaIntPorConsola();

                if (option2 == 1)
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
        static Dictionary<int, Persona> AñadirStudent(Dictionary<int, Persona> listaStudent)
        {
            Console.Clear();
            int studentNumber = listaStudent.Count;
            int option2 = 1;
            while (option2 == 1)
            {

                Console.WriteLine("Entra el nombre del alumno " + (studentNumber + 1));
                string nombreAlumno = ReadIsString();
                Console.WriteLine("Entra la edad de " + nombreAlumno);
                int age = EntradaIntPorConsola();
                Console.WriteLine("Entra su DNI. NO Hace falta letra.");
                int dni = EntradaIntDNIPorConsola();
                Persona student = new Persona(nombreAlumno, age, dni);
                listaStudent.Add(dni, student);
                studentNumber++;

                Console.WriteLine("¿Quieres seguir añadiendo notas? Pulsa 1 para seguir y 0 para salir.");
                option2 = EntradaIntPorConsola();
                Console.Clear();
            }
            return listaStudent;
        }

        static Dictionary<Persona, List<Subject>> AñadirSubjectAStudent(Dictionary<int, Persona> listaStudent)
        {
            Console.WriteLine("Entra el dni del alumno. Si quieres salir escribe 0");
            int dniId = EntradaIntDNIPorConsola();
            Dictionary<Persona, List<Subject>> listaSubject = new Dictionary<Persona, List<Subject>>();
            Persona student = new Persona();
           if (listaStudent.ContainsKey(dniId))
            {
                student = listaStudent[dniId];
            }else if (dniId == 0)
            {
                return listaSubject ;
            }
            else
            {
                MuestraAlumnos(listaStudent);
                Console.WriteLine("El dni no existe. Vuelve a entrarlo.");
                AñadirSubjectAStudent(listaStudent);
                
            }
          
            int option = 1;
            List<Subject> subjectList = new List<Subject>();
            listaSubject.Add(student, subjectList);
            while (option == 1)
            {
                Console.WriteLine("Escribe el nombre de la asignatura que cursa el alumno.");
                string subjectName = Console.ReadLine();
                Console.WriteLine("Escribe el Id de la asignatura.");
                int subjectId = EntradaIntPorConsola();
                Subject subject = new Subject(subjectId, subjectName);
                
                subjectList.Add(subject);
                Console.WriteLine("Quieres añadir más asignaturas? Pulsa 1 o, en el caso contrario, pulsa 0 para salir.");
                option = EntradaIntPorConsola();
                Console.Clear();
            }
            return listaSubject;

        }

         static void MuestraAlumnos(Dictionary<int, Persona> listaStudent)
         {
         Console.WriteLine("Esta es la lista alumnos en el sistema");
         foreach (KeyValuePair<int, Persona> student in listaStudent)
         {
               Console.WriteLine(student.Key);
               Console.WriteLine(student.Value.ShowPersonInfo());
         }
               Console.WriteLine("Pulsa cualquier tecla para continuar");
               Console.ReadKey();
               Console.Clear();
         }
        static void MuestraAsignaturasdeAlumno(Dictionary<int, Persona> listaStudent , List<Dictionary<Persona, List<Subject>>> listaSubjectList)
        {
            Console.WriteLine("Entra el dni del alumno. Si quieres salir escribe 00000000");
            int dniId = EntradaIntDNIPorConsola();

            Persona persona = new Persona();
            if( listaStudent.ContainsKey(dniId)){
                persona = listaStudent[dniId];
            }
            else
            {
                Console.WriteLine("El dni no existe. Vuelve a entrarlo.");
                
                return;
            }

            for (int i = 0; i<listaSubjectList.Count; i++)
            {
                if (listaSubjectList[i].ContainsKey(persona))
                {
                    Dictionary<Persona, List<Subject>> listaSubjectTemp = new Dictionary<Persona, List<Subject>>();
                    listaSubjectTemp = listaSubjectList[i];

                    List<Subject> Templist = listaSubjectTemp[persona];
                    foreach( Subject s in Templist) 
                    {
                        Console.WriteLine(s.subjectName);
                    }
                }
            }

            Console.ReadKey();

               
        }
        #endregion

        #region Text Menus
        static void ShowMainMenu()
        {
            Console.WriteLine("Elige una opción de las siguientes: ");

            Console.WriteLine("1. Añadir alumno.");
            Console.WriteLine("2. Mostrar alumnos.");
            Console.WriteLine("3. Añadir subjects a alumno.");
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
            Console.WriteLine("La nota media de los alumnos de este curso es de: " + (notaMedia / listaNotas.Count));
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
                if (maxNota < notaAlumno.Value)
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

        static int EntradaIntDNIPorConsola()
        {
            int input;
            bool parseCheck = Int32.TryParse(Console.ReadLine(), out input);


            //Clause to see if it's really an int and 8 digits, else repeat the function
            if (parseCheck is true && input.ToString().Length == 8)
            {
                return input;
            }
            else
            {
                Console.WriteLine("No es un número o no tiene 8 dígitos. Vuelve a introducir");
                EntradaIntPorConsola();
                return input;
            }

        }
        static int EntradaIntPorConsola()
        {
            int input;
            bool parseCheck = Int32.TryParse(Console.ReadLine(), out input);


            //Clause to see if it's really an int, else repeat the function
            if (parseCheck is true ) 
            {
                return input;
            }
            else
            {
                Console.WriteLine("No es un número. Vuelve a introducir el dato.");
                EntradaIntPorConsola();
                return 0;
            }
            
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
