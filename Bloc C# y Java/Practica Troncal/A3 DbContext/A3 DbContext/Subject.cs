using System;


namespace A3_DbContext
{

    public class Subject : Entity
    {
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }

        public Subject()
        {

        }
        public Subject(string SubjectCode, string subjectName)
        {
            this.SubjectCode = SubjectCode;
            this.SubjectName = subjectName;

        }


        public static ValidationResult<string> ValidateSubjectName(string subjectname)
        {
            ValidationResult<string> tempsubjectName = new ValidationResult<string>();

            tempsubjectName.ValidationSuccesful = true;
            Console.WriteLine(subjectname);
            #region Check null or empty
            if (string.IsNullOrEmpty(subjectname))
            {
                tempsubjectName.ValidationSuccesful = false;
                tempsubjectName.Messages.Add("subjectName null or empty.");
            }
            #endregion

            if (tempsubjectName.ValidationSuccesful == true)
            {
                tempsubjectName.ValidatedResult = subjectname;
            }

            return tempsubjectName;
        }

        public static ValidationResult<int> ValidateIdSubject(string subjectCode)
        {
            ValidationResult<int> tempIdSubject = new ValidationResult<int>();

            tempIdSubject.ValidationSuccesful = true;

            int subjectCodeNumber;
            bool parsedConversion = Int32.TryParse(subjectCode, out subjectCodeNumber);

            if (!parsedConversion)
            {
                
                tempIdSubject.ValidationSuccesful = false;
                tempIdSubject.Messages.Add("SubjectCode conversion failed");
            }



            if (tempIdSubject.ValidationSuccesful == true)
            {
                tempIdSubject.ValidatedResult = subjectCodeNumber;
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
                DbContext.UpdateSubject(this);
            }
            return true;
        }
    }
}