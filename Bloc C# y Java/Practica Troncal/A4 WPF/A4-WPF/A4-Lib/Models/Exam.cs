using Common.Lib.Core;
using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4_WPF.Lib.Models
{
    public class Exam : Entity
    {
        public double FinalMark { get; set; }

        public string Title { get; set; }
        public Student Student { get; set; }

        public Subject Subject { get; set; }

        public Exam()
        {

        }
        public Exam(double finalMark, Student student, Subject subject, String title)
        {

            this.FinalMark = finalMark;
            this.Student = student;
            this.Subject = subject;
            this.Title = title;
        }

        #region static Validations
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

        public static ValidationResult<string> ValidateTitle(string title)
        {
            ValidationResult<string> tempTitle = new ValidationResult<string>();

            tempTitle.ValidationSuccesful = true;

            #region Check null or empty
            if (string.IsNullOrEmpty(title))
            {
                tempTitle.ValidationSuccesful = false;
                tempTitle.Messages.Add("dninumber null or empty.");
            }
            #endregion



            if (tempTitle.ValidationSuccesful == true)
            {
                tempTitle.ValidatedResult = title;
            }

            return tempTitle;
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
                //tempIdStudent.ValidatedResult = StudentRepository.GetStudentByDni(dniNumber);
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
                foreach (Subject s in SubjectRepository.subjectByCode.Values)
                {
                    if (s.SubjectName == subjectName)
                    {
                        tempSubject.ValidatedResult = s;
                    }
                }

            }

            return tempSubject;
        }
        #endregion

        #region Domain Validations
        public void ValidateFinalMark(ValidationResult valResult)
        {
            var finalMarkvalidation = ValidateFinalMark(this.FinalMark.ToString());
            if (finalMarkvalidation.ValidationSuccesful == false)
            {
                valResult.ValidationSuccesful = false;
                valResult.Messages.AddRange(finalMarkvalidation.Messages);
            }
        }
        public void ValidateTitle(ValidationResult valResult)
        {
            var titlevalidation = ValidateTitle(this.Title);
            if (titlevalidation.ValidationSuccesful == false)
            {
                valResult.ValidationSuccesful = false;
                valResult.Messages.AddRange(titlevalidation.Messages);
            }
        }

        public void ValidateStudent(ValidationResult valResult)
        {
            var studentValidation = ValidateStudent(this.Student.Dni);
            if (studentValidation.ValidationSuccesful == false)
            {
                valResult.ValidationSuccesful = false;
                valResult.Messages.AddRange(studentValidation.Messages);
            }
        }
        public void ValidateSubject(ValidationResult valResult)
        {
            var subjectValidation = ValidateSubject(this.Subject.SubjectName);
            if (subjectValidation.ValidationSuccesful == false)
            {
                valResult.ValidationSuccesful = false;
                valResult.Messages.AddRange(subjectValidation.Messages);
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
            ValidateFinalMark(output);
            ValidateTitle(output);
            ValidateStudent(output);
            ValidateSubject(output);

            return output;
        }
        /*
        public override Repository<T> GetRepo<T>()
        {
            var output = new ExamRepository();

            return output as Repository<T>;
        }
        public ExamRepository GetExamRepo()
        {

            return GetRepo<Exam>() as ExamRepository;
        }
        */
    }
}