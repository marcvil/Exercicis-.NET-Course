using System;
using System.Collections.Generic;
using System.Linq;

namespace A3_DbContext
{

    public class Student : User
    {
        public int LockerKeyNumber { get; set; }

        public string Dni { get; set; }

        public List<Exam> Exams
        {
            get
            {
                return DbContext.examList.Values.Where(e => e.Student.Id == this.Id).ToList();
            }
        }

        public Student(int lockerKeyNumber, string dni, string name, string mail)
        {
            this.LockerKeyNumber = lockerKeyNumber;
            this.Dni = dni;
            this.Name = name;
            this.Mail = mail;
        }


        public static ValidationResult<int> ValidateLockerkeyNumber(string lockerKeyNumber)
        {
            ValidationResult<int> tempLockerkeyNumber = new ValidationResult<int>();

            tempLockerkeyNumber.ValidationSuccesful = true;

            #region Check null or empty
            if (string.IsNullOrEmpty(lockerKeyNumber))
            {
                tempLockerkeyNumber.ValidationSuccesful = false;
                tempLockerkeyNumber.Messages.Add("Locker key null or empty.");
            }
            #endregion

            #region Parse string to Int

            int lockerKeyInt;
            bool parsedConversion = int.TryParse(lockerKeyNumber, out lockerKeyInt);

            if (!parsedConversion)
            {
                tempLockerkeyNumber.ValidationSuccesful = false;
                tempLockerkeyNumber.Messages.Add("Locker key conversion failed");
            }
            #endregion

            if (tempLockerkeyNumber.ValidationSuccesful == true)
            {
                tempLockerkeyNumber.ValidatedResult = lockerKeyInt;
            }

            return tempLockerkeyNumber;
        }

        public static ValidationResult<string> ValidateDni(string dniNumber, bool checkifExists)
        {
            ValidationResult<string> tempIdSubject = new ValidationResult<string>();

            tempIdSubject.ValidationSuccesful = true;

            #region Check null or empty
            if (string.IsNullOrEmpty(dniNumber))
            {
                tempIdSubject.ValidationSuccesful = false;
                tempIdSubject.Messages.Add("dninumber null or empty.");
            }
            #endregion

            /*
            #region Check duplicated
            if (checkifExists && DbContext.studentByDni.ContainsKey(dniNumber))
            {
                tempIdSubject.ValidationSuccesful = false;
                Console.WriteLine("Ya existe el dni.");
            }
            #endregion
            */
            if (tempIdSubject.ValidationSuccesful == true)
            {
                tempIdSubject.ValidatedResult = dniNumber;
            }

            return tempIdSubject;
        }


        public bool Save()
        {
            //Creo el objeto para guardar los valores de las validaciones
            var lockerValidation = ValidateLockerkeyNumber(this.LockerKeyNumber.ToString());
            if (lockerValidation.ValidationSuccesful == false)
            {

                return false;
            }

            var dniValidation = ValidateDni(this.Dni, true);
            if (dniValidation.ValidationSuccesful == false)
            {

                return false;
            }

            var nameValidation = ValidateName(this.Name);
            if (nameValidation.ValidationSuccesful == false)
            {
                return false;
            }
            var mailValidation = ValidateMail(this.Mail);
            if (mailValidation.ValidationSuccesful == false)
            {

                return false;
            }

            // check if guid is available. 
            //If not, it means that the Id we are checking is used by this subject, so we need to update the info
            if (this.Id == Guid.Empty)
            {
                DbContext.CreateStudent(this);
            }
            else
            {
                DbContext.UpdateStudent(this);
            }
            return true;
        }
    }
}

