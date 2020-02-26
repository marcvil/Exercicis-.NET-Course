using System;

namespace Blo_5__Práctica_Troncal_A2_v2
{

    public class Exam
    {
        int examId;
        public int ExamId { get => examId; set => examId = value; }


        float finalMark;
        public float FinalMark { get => finalMark; set => finalMark = value; }

        public Exam()
        {

        }
        public Exam(int examId, float finalMark)
        {
            this.ExamId = ExamId;
            this.FinalMark = finalMark;
        }
    }

}