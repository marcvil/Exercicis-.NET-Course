using System;

namespace Blo_5__Práctica_Troncal_A2
{

    public class Subject
    {
        int idSubject { get; set; }
        public string subjectName;

        public Subject()
        {

        }
        public Subject( int idSubject, string subjectName)
        {
            this.idSubject = idSubject;
            this.subjectName = subjectName;
        }
    }

}
