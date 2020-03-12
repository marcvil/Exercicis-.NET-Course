using System;
using System.Collections.Generic;
using System.Linq;

namespace A3_DbContext
{
    public class ExamRepository : Repository<Exam>
    {
        public static Dictionary<String, Exam> ExamByTitle = new Dictionary<String, Exam>();

        public override SaveValidation<Exam> Add(Exam entity)
        {
            var output = base.Add(entity);

            if (output.SaveValidationSuccesful)
            {
                ExamByTitle.Add(entity.Title, entity);
            }

            return output;
        }

        public override SaveValidation<Exam> Update(Exam entity)
        {

            var output = base.Update(entity);

            if (output.SaveValidationSuccesful)
            {
                ExamByTitle[output.Entity.Title] = output.Entity;
            }

            return output;
        }

        public static IEnumerable<Exam> GetExamByTitle(string examTitle)
        {
            if (ExamByTitle.ContainsKey(examTitle))
            {
                return ExamByTitle.Values.Where(x => x.Title == examTitle).ToList(); ;
            }
            return null;
        }
    }
}
