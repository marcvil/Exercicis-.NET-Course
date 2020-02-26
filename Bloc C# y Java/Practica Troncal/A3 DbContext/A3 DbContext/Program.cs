using System;

namespace A3_DbContext
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            bool looping = true;

            Console.WriteLine("Hola Profesor! Esta es una aplicación para ayudarte a analizar las notas de tus alumnos.");
            ShowMainMenu();
            while (looping)
            {
                option = Input.InputInt();

                if (option == 1)
                {
                    ShowStudentsManagementMenu();

                }
                else if (option == 2)
                {
                    Console.Clear();
                    ShowSubjectsManagementMenu();
                    Console.Clear();
                    ShowMainMenu();
                }
                else if (option == 3)
                {
                    Console.Clear();
                    ShowExamManagementMenu();
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
        static void ShowMainMenu()
        {
            Console.WriteLine("Elige una opción de las siguientes: ");

            Console.WriteLine("1. Gestión de alumnos.");
            Console.WriteLine("2. Gestión asignaturas.");
            Console.WriteLine("3. Gestión Notas.");
            Console.WriteLine("4. Salir de la aplicación.");

        }

        static void ShowStudentsManagementMenu()
        {
            int option;
            bool looping = true;
            while (looping)
            {

                Console.WriteLine("Elige una opción de las siguientes: ");

                Console.WriteLine("1. Crear alumno.");
                Console.WriteLine("2. Mostrar alumno.");
                Console.WriteLine("3. Modificar alumno.");
                Console.WriteLine("4. Borrar alumno.");
                Console.WriteLine("5. Muestra todos los alumnos.");
                Console.WriteLine("6. Volver al menu.");

                option = Input.InputInt();
                if (option == 1)
                {
                    #region Input DNI
                    Console.WriteLine("Escribe el DNI");
                    string inputDni = Console.ReadLine();

                    ValidationResult<string> valResultDni = Student.ValidateDni(inputDni, true);

                    while (!valResultDni.ValidationSuccesful)
                    {
                        inputDni = Console.ReadLine();
                        Student.ValidateDni(inputDni, true);
                    }
                    #endregion

                    #region Input name
                    Console.WriteLine("Escribe el Nombre");
                    string inputName = Console.ReadLine();

                    ValidationResult<string> valResultName = Student.ValidateName(inputName);

                    while (!valResultName.ValidationSuccesful)
                    {
                        inputName = Console.ReadLine();
                        Student.ValidateName(inputName);
                    }
                    #endregion

                    #region Input mail
                    Console.WriteLine("Escribe el mail");
                    string inputMail = Console.ReadLine();

                    ValidationResult<string> valResultMail = Student.ValidateMail(inputMail);

                    while (!valResultMail.ValidationSuccesful)
                    {
                        inputMail = Console.ReadLine();
                        Student.ValidateMail(inputMail);
                    }
                    #endregion

                    #region Validate Locker Key
                    Console.WriteLine("Escribe el numero de taquilla.");

                    string inputLockerKey = Console.ReadLine();

                    ValidationResult<int> valResultLocker = Student.ValidateLockerkeyNumber(inputLockerKey);

                    while (!valResultLocker.ValidationSuccesful)
                    {
                        inputLockerKey = Console.ReadLine();
                        Student.ValidateLockerkeyNumber(inputLockerKey);
                    }
                    #endregion

                    if (valResultDni.ValidationSuccesful && valResultLocker.ValidationSuccesful && valResultName.ValidationSuccesful && valResultMail.ValidationSuccesful)
                    {
                        Student student = new Student(valResultLocker.ValidatedResult, valResultDni.ValidatedResult, valResultName.ValidatedResult, valResultMail.ValidatedResult);

                        student.Save();

                        if (student.Save() == true)
                        {
                            Console.WriteLine("Guardado!");
                        }
                        else
                        {
                            Console.WriteLine("Alumno no guardado debido a errores.");
                        }
                    }
                }
                else if (option == 2)
                {
                    DbContext.ReadStudent();
                }
                else if (option == 3)
                {

                }
                else if (option == 4)
                {
                    Console.Clear();

                }
                else if (option == 5)
                {

                }
                else
                {
                    looping = false;
                }

            }
        }
        static void ShowSubjectsManagementMenu()
        {
            int option = 0;
            bool looping = true;
            while (looping)
            {
                Console.WriteLine("Elige una opción de las siguientes: ");

                Console.WriteLine("1. Crear Asignatura.");
                Console.WriteLine("2. Mostrar Asignatura.");
                Console.WriteLine("3. Modificar Asignatura.");
                Console.WriteLine("4. Borrar Asignatura.");
                Console.WriteLine("5. Muestra todas las Asignatura de un alumno.");
                Console.WriteLine("6. Volver al Menú principal.");

                if (option == 1)
                {
                    Console.Clear();
                    //TODO CreateAsignatura()
                }
                else if (option == 2)
                {
                    Console.Clear();
                    //TODO ReadAsignatura()
                }
                else if (option == 3)
                {
                    //TODO UpdateAsignatura()
                }
                else if (option == 4)
                {
                    //TODO DeleteAsignatura()
                }
                else if (option == 5)
                {

                }
                else
                {
                    looping = false;
                }

            }
        }
        static void ShowExamManagementMenu()
        {
            int option = 0;
            bool looping = true;
            while (looping)
            {
                Console.WriteLine("Elige una opción de las siguientes: ");

                Console.WriteLine("1. Crear Examen.");
                Console.WriteLine("2. Mostrar Examen.");
                Console.WriteLine("3. Modificar Examen.");
                Console.WriteLine("4. Borrar Examen.");
                Console.WriteLine("5. Muestra todos los Examenes de un alumno.");
                Console.WriteLine("6. Volver al Menú principal.");

                if (option == 1)
                {
                    Console.Clear();
                    //TODO CreateExam()
                }
                else if (option == 2)
                {
                    //TODO ReadExam()
                }
                else if (option == 3)
                {
                    //TODO UpdateExam()
                }
                else if (option == 4)
                {
                    //TODO DeleteExam()
                }
                else if (option == 5)
                {

                }
                else
                {
                    looping = false;
                }

            }
        }
        static void ShowAnalisisMenu()
        {
            Console.WriteLine("Elige una opción de las siguientes: ");

            Console.WriteLine("1. Ver la nota media de todos los alumnos.");
            Console.WriteLine("2. Ver el alumno con la nota mínima.");
            Console.WriteLine("3. Ver el alumno con la nota máxima.");
            Console.WriteLine("4. Volver al menú principal");

        }
    }

}