using SMILtest.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMILtest.entitites
{
    class RecordsSmil : Records
    {
        public int Id { get; set; }
        public int Person_id { get; set; }
        public int L { get; set; }
        public int F { get; set; }
        public int K { get; set; }
        public int Hs { get; set; }
        public int D { get; set; }
        public int Hy { get; set; }
        public int Pd { get; set; }
        public int Mf { get; set; }
        public int Pa { get; set; }
        public int Pt { get; set; }
        public int Sc { get; set; }
        public int Ma { get; set; }
        public int Si { get; set; }
        public string Date { get; set; }

        public override string Type => "SMIL";

        public RecordsSmil(int id, int person_id, int l, int f, int k, int hs, int d, int hy, int pd, int mf, int pa, int pt, int sc, int ma, int si, string date)
        {
            Id = id;
            Person_id = person_id;
            L = l;
            F = f;
            K = k;
            Hs = hs;
            D = d;
            Hy = hy;
            Pd = pd;
            Mf = mf;
            Pa = pa;
            Pt = pt;
            Sc = sc;
            Ma = ma;
            Si = si;
            Date = date;
        }

        public RecordsSmil() { }

        public override string ToString()
        {
            var person = SMILRepo.GetPersonById(Person_id);
            return $"Имя: {person.Name}\nПол: {person.Sex}\tВозраст: {person.Age}"
                + $"\nДата прохождения: {Date} \nL = {L} \nF = {F}\nK = {K}\nHs = {Hs}\nD = {D}\nHy = {Hy}\nPd = {Pd}"
                + $"\nMf = {Mf}\nPa = {Pa}\nPt = {Pt}\nSc = {Sc}\nMa = {Ma}\nSi = {Si}";
        }
    }
}
