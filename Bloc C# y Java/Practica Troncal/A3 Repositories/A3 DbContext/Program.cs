using System;
using System.Collections.Generic;

namespace A3_DbContext
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            bool looping = true;

            Console.WriteLine("Hola Profesor! Esta es una aplicación para ayudarte a analizar las notas de tus alumnos.");
            
            while (looping)
            {
                ShowMainMenu();
                option = Input.InputInt();

                if (option == 1)
                {
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
                Console.WriteLine("5. Mostrar todos los alumnos.");
                Console.WriteLine("Cualquier otra teca para volver al menú");

                option = Input.InputInt();
                if (option == 1)
                {
                    #region Input DNI
                    Console.WriteLine("Escribe el DNI");
                    string inputDni = Console.ReadLine();

                    ValidationResult<string> valResultDni;
                    while (!(valResultDni = Student.ValidateDni(inputDni)).ValidationSuccesful)
                    {
                        inputDni = Console.ReadLine();
                        valResultDni = Student.ValidateDni(inputDni);
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

                        var sr = student.Save<Student>();
                        if (sr.SaveValidationSuccesful)
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
                    Student st =StudentRepository.GetStudentByDni(strInput);
                    Console.WriteLine(st.Name);
                    Console.WriteLine(st.Mail);


                }
                else if (option == 3)
                {
                    Console.WriteLine("Escribe el dni del alumno.");
                    string strInput = Console.ReadLine();
                    
                    if (StudentRepository.studentByDni.ContainsKey(strInput))
                    {
                        Student studentClone = StudentRepository.studentByDni[strInput];
                       
                        #region Input DNI


                        ValidationResult<string> valResultDni = Student.ValidateDni(strInput);

                        while (!valResultDni.ValidationSuccesful)
                        {
                            foreach (var msg in valResultDni.Messages)
                            {
                                Console.WriteLine(msg);
                            }

                            strInput = Console.ReadLine();
                            valResultDni = Student.ValidateDni(strInput);
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
                            studentClone.Dni = valResultDni.ValidatedResult;
                            studentClone.Name = valResultName.ValidatedResult;
                            studentClone.Mail = valResultMail.ValidatedResult;
                            studentClone.LockerKeyNumber = valResultLocker.ValidatedResult;



                            var sr = studentClone.Save<Student>();
                            if (sr.SaveValidationSuccesful)
                            {
                                Console.WriteLine("Guardado!");
                            }
                            else
                            {
                                Console.WriteLine("Alumno no guardado debido a errores.");
                            }
                        }
                    }

                }
                else if (option == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Escribe el DNI");
                    string inputDni = Console.ReadLine();
                    if (StudentRepository.studentByDni.ContainsKey(inputDni))
                    {
                        Student studentClone = StudentRepository.studentByDni[inputDni];

                        var sr = studentClone.Delete<Student>();
                        if (sr.DeleteValidationSuccesful)
                        {
                            Console.WriteLine("Borrado");
                        }
                        else
                        {
                            Console.WriteLine("No Borrado debido a errores");
                        }
                    }
                    

                }
                else if (option == 5)
                {
                    foreach(Student s in StudentRepository.studentByDni.Values)
                    {
                        Console.WriteLine(s.Name);
                        Console.WriteLine(s.Dni);
                        Console.WriteLine(s.Mail);
                        Console.WriteLine(s.LockerKeyNumber);
                    }
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

                    ValidationResult<string> valResultSubjectCode = Subject.ValidateIdSubject(inputCodeNumber);

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

                        var sr = subject.Save<Subject>();
                        if (sr.SaveValidationSuccesful)
                        {
                            Console.WriteLine("Guardado!");
                        }
                        else
                        {
                            Console.WriteLine("Asignatura no guardada debido a errores.");
                        }
                    }
                }
                else if (option == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Escribe el nombre de la asignatura que quieras buscar");
                    string subjectCode = Console.ReadLine();

                    foreach (String subjCode in SubjectRepository.subjectByCode.Keys)
                    {
                        if (subjectCode == subjCode)
                        {
                            Console.WriteLine(SubjectRepository.subjectByCode[subjCode].SubjectName + "\n" +
                                SubjectRepository.subjectByCode[subjCode].SubjectCode + "\n"
                                + SubjectRepository.subjectByCode[subjCode].Id);
                        }
                    }
                }
                else if (option == 3)
                {
                    Console.WriteLine("Escribe el codigo de la asignatura que quieras buscar");
                    string subjectCode = Console.ReadLine();
                    if (SubjectRepository.subjectByCode.ContainsKey(subjectCode))
                    {
                        Subject subjectClone = SubjectRepository.subjectByCode[subjectCode];
                        subjectClone.Id = SubjectRepository.subjectByCode[subjectCode].Id;

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

                        ValidationResult<string> valResultSubjectCode = Subject.ValidateIdSubject(inputCodeNumber);

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
                            subjectClone.SubjectName = valResultSubjectname.ValidatedResult;
                            subjectClone.SubjectCode = valResultSubjectCode.ValidatedResult;

                            var sr = subjectClone.Save<Subject>();
                            if (sr.SaveValidationSuccesful)
                            {
                                Console.WriteLine("Guardado!");
                            }
                            else
                            {
                                Console.WriteLine("Alumno no guardado debido a errores.");
                            }
                        }
                    }
                    else if (option == 4)
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
                    }

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

                    #region Input Title
                    Console.WriteLine("Escribe el título de este examen. Ejemplo: AA1. El formato final será: DNIAlumno_SubjectNAme_Titulo");
                    string inputTitle = Console.ReadLine();

                    ValidationResult<String> valResultTitle = Exam.ValidateTitle(inputStudentDni +"_" + inputSubjectName + "_" +inputTitle);

                    while (!valResultTitle.ValidationSuccesful)
                    {
                        foreach (var msg in valResultTitle.Messages)
                        {
                            Console.WriteLine(msg);
                        }
                        inputTitle = Console.ReadLine();
                        valResultTitle = Exam.ValidateTitle(inputTitle);
                    }
                    #endregion

                    if (valResultStudent.ValidationSuccesful && valResultFinalMark.ValidationSuccesful && valResultSubject.ValidationSuccesful && valResultTitle.ValidationSuccesful)
                    {
                        var exam = new Exam(valResultFinalMark.ValidatedResult, valResultStudent.ValidatedResult, valResultSubject.ValidatedResult, valResultTitle.ValidatedResult);

                        var er = exam.Save<Exam>();
                        if (er.SaveValidationSuccesful)
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
                    Console.WriteLine("Escribe el título del examen");
                    string examTitle = Console.ReadLine();
                   

                    IEnumerable<Exam> ex= ExamRepository.GetExamByTitle(examTitle);

                    foreach(Exam exam in ex)
                    {
                        Console.WriteLine("Nota Final:" + exam.FinalMark + " en el examen con el siguiente comentario:" + exam.Title);
                    }
                    

                }
                else if (option == 3)
                {
                    Console.WriteLine("Escribe el dni de alumno");
                    string studentDni = Console.ReadLine();
                    Console.WriteLine("Escribe el título del examen");
                    string examName = Console.ReadLine();
                    Console.WriteLine("Escribe el nombre de la asignatura que quieras buscar");
                    string subjectname = Console.ReadLine();

                    if (ExamRepository.ExamByTitle.ContainsKey(studentDni + "_" + subjectname + "_" + examName))
                    {
                        Exam examClone = ExamRepository.ExamByTitle[studentDni + "_" + subjectname + "_" + examName];
                        examClone.Id = ExamRepository.ExamByTitle[studentDni + "_" + subjectname + "_" + examName].Id;

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

                        #region Input Title
                        Console.WriteLine("Escribe un título para el examen.");
                        string inputTitle = Console.ReadLine();

                        ValidationResult<String> valResultTitle = Exam.ValidateTitle(inputTitle);

                        while (!valResultTitle.ValidationSuccesful)
                        {
                            foreach (var msg in valResultTitle.Messages)
                            {
                                Console.WriteLine(msg);
                            }
                            inputTitle = Console.ReadLine();
                            valResultTitle = Exam.ValidateTitle(inputTitle);
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

                        if (valResultStudent.ValidationSuccesful && valResultFinalMark.ValidationSuccesful && valResultSubject.ValidationSuccesful && valResultTitle.ValidationSuccesful)
                        {
                            examClone.FinalMark = valResultFinalMark.ValidatedResult;
                            examClone.Title = valResultTitle.ValidatedResult;
                            examClone.Student = valResultStudent.ValidatedResult;
                            examClone.Subject = valResultSubject.ValidatedResult;

                            var er = examClone.Save<Exam>();
                            if (er.SaveValidationSuccesful)
                            {
                                Console.WriteLine("Guardado!");
                            }
                            else
                            {
                                Console.WriteLine("Asgnatrua no guardada debido a errores.");
                            }
                        }
                    }

                }
                else if (option == 4)
                 {
                        //TODO DeleteExam()
                }

                else
                {
                    looping = false;
                    break;
                }

                }
            }
            static void ShowAnalisisMenu()
            {
                Console.WriteLine("Elige una opción de las siguientes: ");

                Console.WriteLine("1. Ver la nota media de todos los alumnos.");
                Console.WriteLine("2. Ver el alumno con la nota mínima.");
                Console.WriteLine("3. Ver el alumno con la nota máxima.");
                

            }
        }

    }
