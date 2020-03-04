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
                    foreach (string s in DbContext.studentByDni.Keys)
                    {
                        Console.WriteLine(s);
                        Console.WriteLine("Hola");
                    }
                    ShowStudentsManagementMenu();

                }
                else if (option == 2)
                {

                    ShowSubjectsManagementMenu();


                }
                else if (option == 3)
                {

                    ShowExamManagementMenu();


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
                Console.WriteLine("5. Volver al menu.");

                option = Input.InputInt();
                if (option == 1)
                {
                    #region Input DNI
                    Console.WriteLine("Escribe el DNI");
                    string inputDni = Console.ReadLine();

                    ValidationResult<string> valResultDni = Student.ValidateDni(inputDni, true);

                    while (!valResultDni.ValidationSuccesful)
                    {
                        foreach (var msg in valResultDni.Messages)
                        {
                            Console.WriteLine(msg);
                        }

                        inputDni = Console.ReadLine();
                        valResultDni = Student.ValidateDni(inputDni, true);
                    }
                    #endregion

                    #region Input name
                    Console.WriteLine("Escribe el Nombre");
                    string inputName = Console.ReadLine();

                    ValidationResult<string> valResultName = Student.ValidateName(inputName);

                    while (!valResultName.ValidationSuccesful)
                    {
                        foreach (var msg in valResultName.Messages)
                        {
                            Console.WriteLine(msg);
                        }
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
                        foreach (var msg in valResultMail.Messages)
                        {
                            Console.WriteLine(msg);
                        }
                        inputMail = Console.ReadLine();
                        valResultMail = Student.ValidateMail(inputMail);
                    }
                    #endregion

                    #region Validate Locker Key
                    Console.WriteLine("Escribe el numero de taquilla.");

                    string inputLockerKey = Console.ReadLine();

                    ValidationResult<int> valResultLocker = Student.ValidateLockerkeyNumber(inputLockerKey);

                    while (!valResultLocker.ValidationSuccesful)
                    {

                        foreach (var msg in valResultLocker.Messages)
                        {
                            Console.WriteLine(msg);
                        }

                        inputLockerKey = Console.ReadLine();
                        valResultLocker = Student.ValidateLockerkeyNumber(inputLockerKey);
                    }
                    #endregion

                    if (valResultDni.ValidationSuccesful && valResultLocker.ValidationSuccesful && valResultName.ValidationSuccesful && valResultMail.ValidationSuccesful)
                    {
                        Student student = new Student(valResultLocker.ValidatedResult, valResultDni.ValidatedResult, valResultName.ValidatedResult, valResultMail.ValidatedResult);


                        if (student.Save())
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
                    Console.WriteLine("Escribe el dni del alumno.");
                    string strInput = Console.ReadLine();
                    DbContext.ReadStudent(strInput);
                }
                else if (option == 3)
                {
                    Console.WriteLine("Escribe el dni del alumno.");
                    string strInput = Console.ReadLine();
                    if (DbContext.studentByDni.ContainsKey(strInput))
                    {
                        #region Input DNI


                        ValidationResult<string> valResultDni = Student.ValidateDni(strInput, false);

                        while (!valResultDni.ValidationSuccesful)
                        {
                            foreach (var msg in valResultDni.Messages)
                            {
                                Console.WriteLine(msg);
                            }

                            strInput = Console.ReadLine();
                            valResultDni = Student.ValidateDni(strInput, true);
                        }
                        #endregion

                        #region Input name
                        Console.WriteLine("Escribe el Nombre");
                        string inputName = Console.ReadLine();

                        ValidationResult<string> valResultName = Student.ValidateName(inputName);

                        while (!valResultName.ValidationSuccesful)
                        {
                            foreach (var msg in valResultName.Messages)
                            {
                                Console.WriteLine(msg);
                            }
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
                            foreach (var msg in valResultMail.Messages)
                            {
                                Console.WriteLine(msg);
                            }
                            inputMail = Console.ReadLine();
                            valResultMail = Student.ValidateMail(inputMail);
                        }
                        #endregion

                        #region Validate Locker Key
                        Console.WriteLine("Escribe el numero de taquilla.");

                        string inputLockerKey = Console.ReadLine();

                        ValidationResult<int> valResultLocker = Student.ValidateLockerkeyNumber(inputLockerKey);

                        while (!valResultLocker.ValidationSuccesful)
                        {

                            foreach (var msg in valResultLocker.Messages)
                            {
                                Console.WriteLine(msg);
                            }

                            inputLockerKey = Console.ReadLine();
                            valResultLocker = Student.ValidateLockerkeyNumber(inputLockerKey);
                        }
                        #endregion

                        if (valResultDni.ValidationSuccesful && valResultLocker.ValidationSuccesful && valResultName.ValidationSuccesful && valResultMail.ValidationSuccesful)
                        {
                            Student student = new Student(valResultLocker.ValidatedResult, valResultDni.ValidatedResult, valResultName.ValidatedResult, valResultMail.ValidatedResult);

                            DbContext.UpdateStudent(student);
                        }
                    }

                }
                else if (option == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Escribe el DNI");
                    string inputDni = Console.ReadLine();

                    DbContext.DeleteStudent(DbContext.studentByDni[inputDni]);
                    Console.WriteLine("Borrado!");

                }
                else if (option == 5)
                {
                    looping = false;

                    break;
                }
                else
                {
                    looping = false;
                    break;

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
                Console.WriteLine("5. Volver al Menú principal.");
                option = Input.InputInt();

                if (option == 1)
                {
                    Console.Clear();

                    #region Input Subject Name
                    Console.WriteLine("Escribe el nombre de la asignatura");
                    string inputSubjectName = Console.ReadLine();

                    ValidationResult<string> valResultSubjectname = Subject.ValidateSubjectName(inputSubjectName);

                    while (!valResultSubjectname.ValidationSuccesful)
                    {
                        foreach (var msg in valResultSubjectname.Messages)
                        {
                            Console.WriteLine(msg);
                        }
                        inputSubjectName = Console.ReadLine();
                        valResultSubjectname = Subject.ValidateSubjectName(inputSubjectName);
                    }
                    #endregion

                    #region Input SubjectCode
                    Console.WriteLine("Escribe el codigo numerico de la asignatura");
                    string inputCodeNumber = Console.ReadLine();

                    ValidationResult<int> valResultSubjectCode = Subject.ValidateIdSubject(inputCodeNumber);

                    while (!valResultSubjectCode.ValidationSuccesful)
                    {
                        foreach (var msg in valResultSubjectCode.Messages)
                        {
                            Console.WriteLine(msg);
                        }
                        Console.WriteLine("Entra de nuevo un valor numérico");
                        inputCodeNumber = Console.ReadLine();
                        valResultSubjectCode = Subject.ValidateIdSubject(inputCodeNumber);

                    }
                    #endregion

                    if (valResultSubjectname.ValidationSuccesful && valResultSubjectCode.ValidationSuccesful)
                    {
                        var subject = new Subject(valResultSubjectCode.ValidatedResult.ToString(), valResultSubjectname.ValidatedResult);


                        if (subject.Save() == true)
                        {
                            Console.WriteLine("Guardado!");
                        }
                        else
                        {
                            Console.WriteLine("Asignatrua no guardada debido a errores.");
                        }
                    }
                }
                else if (option == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Escribe el nombre de la asignatura que quieras buscar");
                    string subject = Console.ReadLine();

                    foreach (Subject subj in DbContext.subjectList.Values)
                    {
                        if (subject == subj.SubjectName)
                        {
                            Console.WriteLine(subj.SubjectName + "\n" +
                                subj.SubjectCode + "\n"
                                + subj.Id);
                        }
                    }
                }
                else if (option == 3)
                {
                    Console.WriteLine("Escribe el nombre de la asignatura que quieras buscar");
                    string subjectName = Console.ReadLine();
                    Guid id = new Guid();
                    foreach (Subject s in DbContext.subjectList.Values)
                    {
                        if (s.SubjectName == subjectName)
                        {
                            id = s.Id;
                        }
                    }
                    #region Input Subject Name
                    Console.WriteLine("Escribe el nuevo nombre de la asignatura");
                    string inputSubjectName = Console.ReadLine();

                    ValidationResult<string> valResultSubjectname = Subject.ValidateSubjectName(inputSubjectName);

                    while (!valResultSubjectname.ValidationSuccesful)
                    {
                        foreach (var msg in valResultSubjectname.Messages)
                        {
                            Console.WriteLine(msg);
                        }
                        inputSubjectName = Console.ReadLine();
                        valResultSubjectname = Subject.ValidateSubjectName(inputSubjectName);
                    }
                    #endregion

                    #region Input SubjectCode
                    Console.WriteLine("Escribe el nuevo codigo numerico de la asignatura");
                    string inputCodeNumber = Console.ReadLine();

                    ValidationResult<int> valResultSubjectCode = Subject.ValidateIdSubject(inputCodeNumber);

                    while (!valResultSubjectCode.ValidationSuccesful)
                    {
                        foreach (var msg in valResultSubjectCode.Messages)
                        {
                            Console.WriteLine(msg);
                        }
                        Console.WriteLine("Entra de nuevo un valor numérico");
                        inputCodeNumber = Console.ReadLine();
                        valResultSubjectCode = Subject.ValidateIdSubject(inputCodeNumber);

                    }
                    #endregion

                    if (valResultSubjectname.ValidationSuccesful && valResultSubjectCode.ValidationSuccesful)
                    {
                        var subject = new Subject(valResultSubjectCode.ValidatedResult.ToString(), valResultSubjectname.ValidatedResult);
                        subject.Id = id;
                        DbContext.UpdateSubject(subject);

                    }
                    else if (option == 4)
                    {
                        //TODO DeleteAsignatura()
                    }

                    else
                    {
                        looping = false;
                    }

                }
                else if(option == 4)
                {
                    Console.WriteLine("Escribe el nombre de la asignaturA");
                    string inputName = Console.ReadLine();
                    var subj = new Subject();
                    foreach (Subject s in DbContext.subjectList.Values)
                    {
                        if (s.SubjectName == inputName)
                        {
                            subj = s;
                        }
                    }
                    DbContext.DeleteSubject(subj);
                    Console.WriteLine("Borrado!");
                }
                else
                {
                    looping = false;
                    break;
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

                    Console.WriteLine("5. Volver al Menú principal.");
                    option = Input.InputInt();
                if (option == 1)
                {
                    #region Input FInalMArk
                    Console.WriteLine("Escribe la nota del examen");
                    string inputFinalmark = Console.ReadLine();

                    ValidationResult<double> valResultFinalMark = Exam.ValidateFinalMark(inputFinalmark);

                    while (!valResultFinalMark.ValidationSuccesful)
                    {
                        foreach (var msg in valResultFinalMark.Messages)
                        {
                            Console.WriteLine(msg);
                        }
                        inputFinalmark = Console.ReadLine();
                        valResultFinalMark = Exam.ValidateFinalMark(inputFinalmark);
                    }
                    #endregion

                    #region Input StudentDNi
                    Console.WriteLine("Escribe el dni del alumno que ha realizado ele xamen");
                    string inputStudentDni = Console.ReadLine();

                    ValidationResult<Student> valResultStudent = Exam.ValidateStudent(inputStudentDni);

                    while (!valResultStudent.ValidationSuccesful)
                    {
                        foreach (var msg in valResultStudent.Messages)
                        {
                            Console.WriteLine(msg);
                        }
                        inputStudentDni = Console.ReadLine();
                        valResultStudent = Exam.ValidateStudent(inputStudentDni);
                    }
                    #endregion

                    #region Input SubjectName
                    Console.WriteLine("Escribe el el nombre de la asignatura dele xamen");
                    string inputSubjectName = Console.ReadLine();

                    ValidationResult<Subject> valResultSubject = Exam.ValidateSubject(inputSubjectName);

                    while (!valResultSubject.ValidationSuccesful)
                    {
                        foreach (var msg in valResultSubject.Messages)
                        {
                            Console.WriteLine(msg);
                        }
                        inputStudentDni = Console.ReadLine();
                        valResultSubject = Exam.ValidateSubject(inputSubjectName);
                    }
                    #endregion

                    if (valResultStudent.ValidationSuccesful && valResultFinalMark.ValidationSuccesful && valResultSubject.ValidationSuccesful)
                    {
                        var exam = new Exam(valResultFinalMark.ValidatedResult, valResultStudent.ValidatedResult, valResultSubject.ValidatedResult);


                        if (exam.Save() == true)
                        {
                            Console.WriteLine("Guardado!");
                        }
                        else
                        {
                            Console.WriteLine("Asgnatrua no guardada debido a errores.");
                        }
                    }
                }
                else if (option == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Escribe el nombre del estudiante que quieras buscar");
                    string studentName = Console.ReadLine();
                    Console.WriteLine("Escribe el nombre de la asignatura que quieras buscar");
                    string subjectname = Console.ReadLine();

                    foreach (Exam ex in DbContext.examList.Values)
                    {
                        if (studentName == ex.Student.Name && subjectname == ex.Subject.SubjectName)
                        {
                            Console.WriteLine("La nota es " + ex.FinalMark + " con id " + ex.Id);
                        }
                    }

                }
                else if (option == 3)
                {
                    Console.WriteLine("Escribe el nombre del estudiante que quieras buscar");
                    string studentName = Console.ReadLine();
                    Console.WriteLine("Escribe el nombre de la asignatura que quieras buscar");
                    string subjectname = Console.ReadLine();

                    var exam = new Exam();
                    foreach (Exam e in DbContext.examList.Values)
                    {
                        if (e.Subject.SubjectName == subjectname && e.Student.Name == studentName)
                        {
                            exam = e;
                        }
                    }
                    #region Input FInalMArk
                    Console.WriteLine("Escribe la nota del examen");
                    string inputFinalmark = Console.ReadLine();

                    ValidationResult<double> valResultFinalMark = Exam.ValidateFinalMark(inputFinalmark);

                    while (!valResultFinalMark.ValidationSuccesful)
                    {
                        foreach (var msg in valResultFinalMark.Messages)
                        {
                            Console.WriteLine(msg);
                        }
                        inputFinalmark = Console.ReadLine();
                        valResultFinalMark = Exam.ValidateFinalMark(inputFinalmark);
                    }
                    #endregion

                    #region Input StudentDNi
                    Console.WriteLine("Escribe el dni del alumno que ha realizado ele xamen");
                    string inputStudentDni = Console.ReadLine();

                    ValidationResult<Student> valResultStudent = Exam.ValidateStudent(inputStudentDni);

                    while (!valResultStudent.ValidationSuccesful)
                    {
                        foreach (var msg in valResultStudent.Messages)
                        {
                            Console.WriteLine(msg);
                        }
                        inputStudentDni = Console.ReadLine();
                        valResultStudent = Exam.ValidateStudent(inputStudentDni);
                    }
                    #endregion

                    #region Input SubjectName
                    Console.WriteLine("Escribe el el nombre de la asignatura dele xamen");
                    string inputSubjectName = Console.ReadLine();

                    ValidationResult<Subject> valResultSubject = Exam.ValidateSubject(inputSubjectName);

                    while (!valResultSubject.ValidationSuccesful)
                    {
                        foreach (var msg in valResultSubject.Messages)
                        {
                            Console.WriteLine(msg);
                        }
                        inputStudentDni = Console.ReadLine();
                        valResultSubject = Exam.ValidateSubject(inputSubjectName);
                    }
                    #endregion

                    if (valResultStudent.ValidationSuccesful && valResultFinalMark.ValidationSuccesful && valResultSubject.ValidationSuccesful)
                    {
                        exam.FinalMark = valResultFinalMark.ValidatedResult;
                        exam.Student = valResultStudent.ValidatedResult;
                        exam.Subject = valResultSubject.ValidatedResult;

                        DbContext.UpdateExam(exam);
                    }

                }
                else if (option == 4)
                    {
                        //TODO DeleteExam()
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
