using SMILtest.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMILtest.entitites
{
    class RecordsOnpd : Records
    {
        public int Id { get; set; }
        public int Person_id { get; set; }
        public int A { get; set; }
        public int D { get; set; }
        public int DP { get; set; }
        public int First { get; set; }
        public int Second { get; set; }
        public string Date { get; set; }
        public override string Type { get => "ONPD";}

        public RecordsOnpd(int personId, int scaleA, int scaleD, int scaleDP, int scaleFirst, int scaleSecond, string passDate)
        {
            Person_id = personId;
            A = scaleA;
            D = scaleD;
            DP = scaleDP;
            First = scaleFirst;
            Second = scaleSecond;
            Date = passDate;
        }

        public RecordsOnpd()
        {
        }

        public override string ToString()
        {
            Person person = ONPDRepo.GetPersonById(Person_id);
            return "Имя: " + person.Name + "\nПол: " + (person.Sex) + "\tВозраст: " + person.Age
                + "\nДата прохождения: " + Date + "\n1 = " + First + "\n2 = " + Second + "\nA = " + A + "\nД = " + D
                + "\nДР = " + DP;
        }
    }
}
