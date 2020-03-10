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

        #region Static validations
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

        public static ValidationResult<string> ValidateDni(string dniNumber)
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


            if (tempIdSubject.ValidationSuccesful == true)
            {
                tempIdSubject.ValidatedResult = dniNumber;
            }

            return tempIdSubject;
        }

        #endregion

        #region Domain Validations
        public void ValidateName(ValidationResult valResult)
        {
            var nameValidation = ValidateName(this.Name);
            if (!nameValidation.ValidationSuccesful)
            {
                valResult.ValidationSuccesful = false;
                valResult.Messages.AddRange(nameValidation.Messages);
            }
        }
        public void ValidateLockerKey(ValidationResult valResult)
        {
            var lockerValidation = ValidateLockerkeyNumber(this.LockerKeyNumber.ToString());
            if (!lockerValidation.ValidationSuccesful)
            {
                valResult.ValidationSuccesful = false;
                valResult.Messages.AddRange(lockerValidation.Messages);
            }
        }

        public void ValidateDni(ValidationResult valResult)
        {
            var dniValidation = ValidateDni(this.Dni);
            if (dniValidation.ValidationSuccesful == false)
            {
                valResult.ValidationSuccesful = false;
                valResult.Messages.AddRange(dniValidation.Messages);
            }
        }
        public void ValidateMail(ValidationResult valResult)
        {
            var mailValidation = ValidateMail(this.Mail);
            if (mailValidation.ValidationSuccesful == false)
            {
                valResult.ValidationSuccesful = false;
                valResult.Messages.AddRange(mailValidation.Messages);
            }
        }
        #endregion

        public SaveValidation<Student> Save()
        {
            var saveResult = base.Save<Student>();
            return saveResult;
        }


        public override ValidationResult Validate()
        {
            var output = base.Validate();
            // check if guid is available. 
            //If not, it means that the Id we are checking is used by this subject, so we need to update the info
            ValidateDni(output);
            ValidateLockerKey(output);
            ValidateMail(output);
            ValidateName(output);

            return output;
        }

        public override StudentRepository GetRepo<Student>() 
        {
            var output = new StudentRepository();

            return output;
        }
    }
}
