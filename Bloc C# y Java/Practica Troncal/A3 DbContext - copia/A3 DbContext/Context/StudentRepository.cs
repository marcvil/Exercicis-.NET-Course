using System;
using System.Collections.Generic;

namespace A3_DbContext
{
	public class StudentRepository: Repository<Student>
	{
		public static Dictionary<string, Student> studentRepo = new Dictionary<string, Student>();

        public override SaveValidation<Student> Add(Student entity)
        {
            var output = new SaveValidation<Student>();

            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            if (DbSet.ContainsKey(entity.Id))
            {
                output.SaveValidationSuccesful = false;
                output.SaveValidationMessages.Add("Ya existe con este GUID");
            }

            if (output.SaveValidationSuccesful)
            {
                DbSet.Add(entity.Id, entity);
            }

            return output;
        }

        public override SaveValidation<Student> Update(Student entity)
        {
            var output = new SaveValidation<Student>();

            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            if (DbSet.ContainsKey(entity.Id))
            {
                output.SaveValidationSuccesful = false;
                output.SaveValidationMessages.Add("Ya existe con este GUID");
            }

            if (output.SaveValidationSuccesful)
            {
                DbSet.Add(entity.Id, entity);
            }

            return output;
        }
    }
}
