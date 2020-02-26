using System;

namespace A3_DbContext
{
    public class User : Entity
    {
        public string Name { get; set; }

        public string Mail { get; set; }

        //Constructors

        public User()
        {

        }
        public User(string name, string mail)
        {

            this.Name = name;
            this.Mail = mail;
        }

        public static ValidationResult<string> ValidateName(string name)
        {

            ValidationResult<string> tempName = new ValidationResult<string>();

            tempName.ValidationSuccesful = true;

            #region Check null or empty
            if (string.IsNullOrEmpty(name))
            {
                tempName.ValidationSuccesful = false;
                Console.WriteLine("name null or empty");
            }
            #endregion

            if (tempName.ValidationSuccesful == true)
            {
                tempName.ValidatedResult = name;
            }

            return tempName;
        }

        public static ValidationResult<string> ValidateMail(string mail)
        {
            ValidationResult<string> tempMail = new ValidationResult<string>();

            tempMail.ValidationSuccesful = true;

            #region Check null or empty
            if (string.IsNullOrEmpty(mail))
            {
                tempMail.ValidationSuccesful = false;
                Console.WriteLine("mail null or empty");
            }
            #endregion

            if (tempMail.ValidationSuccesful == true)
            {
                tempMail.ValidatedResult = mail;
            }

            return tempMail;
        }

    }
}
