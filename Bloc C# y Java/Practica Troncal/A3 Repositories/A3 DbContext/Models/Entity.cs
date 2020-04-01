using System;
using System.Collections.Generic;
namespace A3_DbContext
{
    public class Entity
    {
        private Guid id;
        public Guid Id { get => id; set => id = value; }

        public ValidationResult CurrentValidation { get; set; }

        public virtual SaveValidation<T> Save<T>() where T : Entity
        {
            var result = new SaveValidation<T>();
            CurrentValidation = Validate();
            var repo = GetRepo<T>();

            if (CurrentValidation.ValidationSuccesful)
            {
                if (this.Id == Guid.Empty)
                {
                    this.Id = Guid.NewGuid();
                    result = repo.Add(this as T);
                }
                else
                {
                    result = repo.Update(this as T);
                }
            }

            result.Validation = CurrentValidation;
            return result;
        }
        public virtual DeleteValidation<T> Delete<T>() where T : Entity
        {
            var result = new DeleteValidation<T>();
            CurrentValidation = Validate();
            var repo = GetRepo<T>();

            if (CurrentValidation.ValidationSuccesful)
            {
                result = repo.Delete(this as T);
            }

            result.Validation = CurrentValidation;
            return result;
        }

        public virtual ValidationResult Validate()
        {
            var result = new ValidationResult();

            result.ValidationSuccesful = true;

            return result;
        }
        public virtual Repository<T> GetRepo<T>() where T : Entity
        {
            var output = new Repository<T>();

            return output;
            
        }

    }
}

