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

        #region static validations
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
        #endregion


        #region Domain Validations
        public void ValidateSubjectName(ValidationResult valResult)
        {
            var subjectNamevalidation = ValidateSubjectName(this.SubjectName);
            if (subjectNamevalidation.ValidationSuccesful == false)
            {
                valResult.ValidationSuccesful = false;
                valResult.Messages.AddRange(subjectNamevalidation.Messages);
            }
        }

        public void ValidateIdSubject(ValidationResult valResult)
        {
            var idSubjectvalidation = ValidateIdSubject(this.SubjectCode);
            if (idSubjectvalidation.ValidationSuccesful == false)
            {
                valResult.ValidationSuccesful = false;
                valResult.Messages.AddRange(idSubjectvalidation.Messages);
            }
        }

        public SaveValidation<Subject> Save()
        {
            var saveResult = base.Save<Subject>();
            return saveResult;
        }
        #endregion

        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateIdSubject(this.SubjectCode);
            ValidateSubjectName(this.SubjectName);

            return output;
        }
        
    }
}