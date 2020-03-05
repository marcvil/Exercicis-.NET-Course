using System;

namespace A3_DbContext
{
    public class Exam : Entity
    {
        public double FinalMark { get; set; }
        
        public string Comment { get; set; }
        public Student Student { get; set; }

        public Subject Subject { get; set; }

        public Exam()
        {

        }
        public Exam(double finalMark, Student student,Subject subject, String comment)
        {

            this.FinalMark = finalMark;
            this.Student = student;
            this.Subject = subject;
            this.Comment = comment;
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

        public static ValidationResult<string> ValidateComment(string comment)
        {
            ValidationResult<string> tempComment = new ValidationResult<string>();

            tempComment.ValidationSuccesful = true;

            #region Check null or empty
            if (string.IsNullOrEmpty(comment))
            {
                tempComment.ValidationSuccesful = false;
                tempComment.Messages.Add("dninumber null or empty.");
            }
            #endregion



            if (tempComment.ValidationSuccesful == true)
            {
                tempComment.ValidatedResult = comment;
            }

            return tempComment;
        }



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

        public static ValidationResult<Subject> ValidateSubject(string subjectName)
        {
            ValidationResult<Subject> tempSubject = new ValidationResult<Subject>();

            tempSubject.ValidationSuccesful = true;

            #region Check null or empty
            if (string.IsNullOrEmpty(subjectName))
            {
                tempSubject.ValidationSuccesful = false;
                tempSubject.Messages.Add("dninumber null or empty.");
            }
            #endregion

            if (tempSubject.ValidationSuccesful == true)
            {
                foreach(Subject s in DbContext.subjectList.Values)
                {
                    if (s.SubjectName == subjectName)
                    {
                        tempSubject.ValidatedResult = s;
                    }
                }
               
            }

            return tempSubject;
        }

        public bool Save()
        {
            //Creo el objeto para guardar los valores de las validaciones
            var stringvalidation = ValidateFinalMark(this.FinalMark.ToString());
            if (stringvalidation.ValidationSuccesful == false)
            {
                return false;
            }
            
            var commentvalidation = ValidateComment(this.Comment);
            if (commentvalidation.ValidationSuccesful == false)
            {
                return false;
            }
            
            var studentValidation = ValidateStudent(this.Student.Dni);
            if (studentValidation.ValidationSuccesful == false)
            {
                return false;
            }
            var subjectValidation = ValidateSubject(this.Subject.SubjectName);
            if (subjectValidation.ValidationSuccesful == false)
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