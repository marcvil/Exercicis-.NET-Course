using System;

namespace A3_DbContext
{
    public class Exam : Entity
    {
        public double FinalMark { get; set; }
        public DateTime ExamDate { get; set; }

        public Exam()
        {

        }
        public Exam(double finalMark)
        {

            this.FinalMark = finalMark;
        }


        public static ValidationResult<double> ValidateFinalMark(string finalmark)
        {
            ValidationResult<double> tempfinalMark = new ValidationResult<double>();

            tempfinalMark.ValidationSuccesful = true;

            #region Check null or empty
            if (string.IsNullOrEmpty(finalmark))
            {
                tempfinalMark.ValidationSuccesful = false;
            }
            #endregion

            #region format

            double doublevar;
            bool conversionvalid = double.TryParse(Console.ReadLine(), out doublevar);
            if (!conversionvalid)
            {
                tempfinalMark.ValidationSuccesful = false;
            }
            #endregion

            if (tempfinalMark.ValidationSuccesful == true)
            {
                tempfinalMark.ValidatedResult = doublevar;
            }

            return tempfinalMark;
        }

        public static ValidationResult<DateTime> ValidateDateTime(int year, int month, int day)
        {
            ValidationResult<DateTime> tempDateTime = new ValidationResult<DateTime>();

            tempDateTime.ValidationSuccesful = true;

            #region Check format  
            // We check if they added another number(missclick), which will result in a year larger than 10000
            if (year > 10000)
            {
                tempDateTime.ValidationSuccesful = false;
            }
            if (month! >= 0 || month! <= 12)
            {
                tempDateTime.ValidationSuccesful = false;
            }
            if (day! >= 0 || day! <= 31)
            {
                tempDateTime.ValidationSuccesful = false;
            }
            #endregion

            if (tempDateTime.ValidationSuccesful == true)
            {
                tempDateTime.ValidatedResult = new DateTime(year, month, day);
            }

            return tempDateTime;
        }


        public bool Save()
        {
            //Creo el objeto para guardar los valores de las validaciones
            var stringvalidation = ValidateFinalMark(this.FinalMark.ToString());
            if (stringvalidation.ValidationSuccesful == false)
            {
                return false;
            }

            var datevalidation = ValidateDateTime(this.ExamDate.Year, this.ExamDate.Month, this.ExamDate.Day);
            if (datevalidation.ValidationSuccesful == false)
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