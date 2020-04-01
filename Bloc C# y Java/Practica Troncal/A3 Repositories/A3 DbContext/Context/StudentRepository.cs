using System;
using System.Collections.Generic;
using System.Linq;

namespace A3_DbContext
{
	public class StudentRepository: Repository<Student>
	{
		public static Dictionary<string, Student> studentByDni = new Dictionary<string, Student>();

        public override SaveValidation<Student> Add(Student entity)
        {
            var output = base.Add(entity);

            if (output.SaveValidationSuccesful)
            {
                studentByDni.Add(entity.Dni, entity);
            }

            return output;
        }

        public override SaveValidation<Student> Update(Student entity)
        {
            var output = base.Update(entity);

            if (output.SaveValidationSuccesful)
            {
                studentByDni[output.Entity.Dni] = output.Entity;
            }

            return output;
        }

        public override DeleteValidation<Student> Delete(Student entity)
        {
            var output = base.Delete(entity);

            if (output.DeleteValidationSuccesful)
            {
                studentByDni.Remove(output.Entity.Dni);
            }

            return output;
        }


        public static Student GetStudentByDni(string strDni)
        {
            if (studentByDni.ContainsKey(strDni))
            {
                return studentByDni[strDni];
            }
            return null;
        }
    }
}
