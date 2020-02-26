using System;


namespace A3_DbContext
{

    public class Subject : Entity
    {
        public string SubjectName { get; set; }
        public int SubjectCode { get; set; }

        public Subject()
        {

        }
        public Subject(int SubjectCode, string subjectName)
        {
            this.SubjectCode = SubjectCode;
            this.SubjectName = subjectName;

        }


        public static ValidationResult<string> ValidateSubjectName(string subjectname)
        {
            ValidationResult<string> tempsubjectName = new ValidationResult<string>();

            tempsubjectName.ValidationSuccesful = true;

            #region Check null or empty
            if (string.IsNullOrEmpty(subjectname))
            {
                tempsubjectName.ValidationSuccesful = false;
            }
            #endregion

            if (tempsubjectName.ValidationSuccesful == true)
            {
                tempsubjectName.ValidatedResult = subjectname;
            }

            return tempsubjectName;
        }

        public static ValidationResult<int> ValidateIdSubject(int subjectCode)
        {
            ValidationResult<int> tempIdSubject = new ValidationResult<int>();

            tempIdSubject.ValidationSuccesful = true;

            #region Check format
            // Ya se checkea el Input en los helper methods de Input
            #endregion

            if (tempIdSubject.ValidationSuccesful == true)
            {
                tempIdSubject.ValidatedResult = subjectCode;
            }

            return tempIdSubject;
        }


        public bool Save()
        {
            //Creo el objeto para guardar los valores de las validaciones
            var stringvalidation = ValidateSubjectName(this.SubjectName);
            if (stringvalidation.ValidationSuccesful == false)
            {
                return false;
            }

            var intvalidation = ValidateIdSubject(this.SubjectCode);
            if (intvalidation.ValidationSuccesful == false)
            {
                return false;
            }

            // check if guid is available. 
            //If not, it means that the Id we are checking is used by this subject, so we need to update the info
            if (this.Id == Guid.Empty)
            {
                DbContext.CreateSubject(this);
            }
            else
            {
                DbContext.CreateSubject(this);
            }
            return true;
        }
    }
}