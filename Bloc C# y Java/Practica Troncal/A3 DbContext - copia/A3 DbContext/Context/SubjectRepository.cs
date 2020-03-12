using System;
using System.Collections.Generic;
using System.Linq;

namespace A3_DbContext
{
    public class SubjectRepository : Repository<Subject>
    {
        public static Dictionary<string, Subject> subjectByCode = new Dictionary<string, Subject>();

        public override SaveValidation<Subject> Add(Subject entity)
        {
            var output = base.Add(entity);

            if (output.SaveValidationSuccesful)
            {
                subjectByCode.Add(entity.SubjectCode, entity);
            }

            return output;
        }

        public override SaveValidation<Subject> Update(Subject entity)
        {

            var output = base.Update(entity);

            if (output.SaveValidationSuccesful)
            {
                subjectByCode[output.Entity.SubjectCode] = output.Entity;
            }

            return output;
        }

        public static Subject GetSubjectByCode(string strCode)
        {
            if (subjectByCode.ContainsKey(strCode))
            {
                return subjectByCode[strCode];
            }
            return null;
        }
    }
}
