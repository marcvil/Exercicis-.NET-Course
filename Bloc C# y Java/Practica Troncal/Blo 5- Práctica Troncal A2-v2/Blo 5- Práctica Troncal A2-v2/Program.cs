using System;
using System.Collections.Generic;

namespace Blo_5__Práctica_Troncal_A2_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            bool looping = true;
           
            Dictionary<int, Persona> listaStudent = new Dictionary<int, Persona>();
            

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
                    
                    AñadirSubjectyNotas(listaStudent);
                   
                    ShowMainMenu();
                }
                else if (option == 4)
                {
                    MuestraNotas(listaStudent);
                    Console.ReadKey();
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

        #region Añadir y mostrar alumnos - ListStudent
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
        #endregion

        #region Añadir Subject y notas de examen

        static void AñadirSubjectyNotas(Dictionary<int, Persona> listaStudent)
        {
            Persona alumno = BuscarAlumnoPorDni(listaStudent);
            Dictionary<Subject, List<Exam>> listaSubjectExam = new Dictionary<Subject, List<Exam>>();
            if (alumno != null)
            {
                int option = 1;
                while(option == 1)
                {
                    listaSubjectExam.Add(CrearAsignatura(), CrearListaExamenes());

                    Console.WriteLine("Quieres añadir más ASIGNATURAS? Pulsa 1 para añadir o 0 para salir.");
                    option = EntradaIntPorConsola();
                }
                alumno.ListaExam = listaSubjectExam;
            }
            else
            {
                Console.WriteLine("No existe ningún alumno con este Id.");
            }
            

        }

        private static Subject CrearAsignatura()
        {
            Subject subj = new Subject();
            Console.WriteLine("Entra el nombre de una asignatura que esta cursando el alumno");
            subj.SubjectName = ReadIsString();
            Console.WriteLine("Entra el id de esta asignatura");
            subj.IdSubject = EntradaIntPorConsola();

            return subj;
        }

        private static List<Exam> CrearListaExamenes()
        {
            int option = 1;
            int numExam = 1;
            List<Exam> listaNotasExamen = new List<Exam>();
            while (option == 1)
            {
                Exam exam = new Exam();
                Console.WriteLine("Añade la nota del examen número: " + numExam);
                exam.FinalMark = EntradaFloatPorConsola();
                Console.WriteLine("Añade el Id del examen");
                exam.ExamId = EntradaIntPorConsola();
                listaNotasExamen.Add(exam);

                Console.WriteLine("Quieres añadir más EXAMENES? Pulsa 1 para añadir o 0 para salir.");
                option = EntradaIntPorConsola();

            }

            return listaNotasExamen;

        }
        private static void MuestraNotas(Dictionary<int, Persona>  listaStudent)
        {
            Persona alumno = BuscarAlumnoPorDni(listaStudent);

            Console.WriteLine("El alumno esta cursando las siguientes asignaturas.");

            foreach(Subject s in alumno.ListaExam.Keys)
            {
                Console.WriteLine("Nombre Asignatura = {0}, Id Asignatura = {1}", s.SubjectName, s.IdSubject);
            }

            Console.WriteLine("Entra el nombre de la asignatura que quieres mirar las notas.");
            string str = Console.ReadLine();
            
            foreach (KeyValuePair<Subject,List < Exam >> c in alumno.ListaExam)
            {
                if(c.Key.SubjectName == str)
                {
                    foreach(Exam ex in c.Value)
                    {
                        Console.WriteLine("Nota examen = {0}, Id Examen = {1}", ex.FinalMark, ex.ExamId);
                    }
                }
            }

        }

        #endregion

        #region TextMenus
        static void ShowMainMenu()
        {
            Console.WriteLine("Elige una opción de las siguientes: ");

            Console.WriteLine("1. Añadir alumno.");
            Console.WriteLine("2. Mostrar alumnos.");
            Console.WriteLine("3. Añadir subjects a alumno.");
            Console.WriteLine("4. Muestra Notas de un alumno.");

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

        #region Input

        static Persona BuscarAlumnoPorDni(Dictionary<int, Persona> listaStudent)
        {
            Console.WriteLine("Buscar alumno por DNI");
            int dniId = EntradaIntDNIPorConsola();
            
            if (listaStudent.ContainsKey(dniId))
            {
                return listaStudent[dniId];
            }
           
            else
            {
                MuestraAlumnos(listaStudent);
                Console.WriteLine("El dni no existe. Vuelve a entrarlo.");
                BuscarAlumnoPorDni(listaStudent);
                return null;

            }
        }

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
            if (parseCheck is true)
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
    


