using System;

namespace A3_DbContext
{
    public class Exam : Entity
    {
        public double FinalMark { get; set; }
        //public DateTime ExamDate { get; set; }

        public Student Student { get; set; }

        public Subject Subject { get; set; }

        public Exam()
        {

        }
        public Exam(double finalMark, Student student)
        {

            this.FinalMark = finalMark;
            this.Student = student;
        }


        public static ValidationResult<double> ValidateFinalMark(string finalmark)
        {
            ValidationResult<double> tempfinalMark = new ValidationResult<double>();

            tempfinalMark.ValidationSuccesful = true;

            #region Check null or empty
            if (string.IsNullOrEmpty(finalmark))
            {
                tempfinalMark.ValidationSuccesful = false;
                tempfinalMark.Messages.Add("finalmark null or empty.");
            }
            #endregion

            #region format

            double doublevar;
            bool conversionvalid = double.TryParse(finalmark, out doublevar);
            if (!conversionvalid)
            {
                tempfinalMark.ValidationSuccesful = false;
                tempfinalMark.Messages.Add("finalmark conversion failed");
            }
            #endregion

            if (tempfinalMark.ValidationSuccesful == true)
            {
                tempfinalMark.ValidatedResult = doublevar;
            }

            return tempfinalMark;
        }
        /*
        public static ValidationResult<DateTime> ValidateDateTime(DateTime dateTime)
        {
            ValidationResult<DateTime> tempDateTime = new ValidationResult<DateTime>();

            tempDateTime.ValidationSuccesful = true;

            if (tempDateTime.ValidationSuccesful == true)
            {
                tempDateTime.ValidatedResult = dateTime;
            }

            return tempDateTime;
        }
        */
        public static ValidationResult<Student> ValidateStudent(string dniNumber)
        {
            ValidationResult<Student> tempIdStudent = new ValidationResult<Student>();

            tempIdStudent.ValidationSuccesful = true;

            #region Check null or empty
            if (string.IsNullOrEmpty(dniNumber))
            {
                tempIdStudent.ValidationSuccesful = false;
                tempIdStudent.Messages.Add("dninumber null or empty.");
            }
            #endregion

            if (tempIdStudent.ValidationSuccesful == true)
            {
                tempIdStudent.ValidatedResult = DbContext.studentByDni[dniNumber];
            }

            return tempIdStudent;
        }

        public bool Save()
        {
            //Creo el objeto para guardar los valores de las validaciones
            var stringvalidation = ValidateFinalMark(this.FinalMark.ToString());
            if (stringvalidation.ValidationSuccesful == false)
            {
                return false;
            }
            /*
            var datevalidation = ValidateDateTime(this.ExamDate);
            if (datevalidation.ValidationSuccesful == false)
            {
                return false;
            }
            */
            var studentValidation = ValidateStudent(this.Student.Dni);
            if (studentValidation.ValidationSuccesful == false)
            {
                return false;
            }

            // check if guid is available. 
            //If not, it means that the Id we are checking is used by this subject, so we need to update the info
            if (this.Id == Guid.Empty)
            {
                DbContext.CreateExam(this);
            }
            else
            {
                DbContext.UpdateExam(this);
            }
            return true;
        }
    }
}