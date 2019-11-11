using Dapper;
using SMILtest.entitites;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMILtest.db
{
    class ONPDRepo
    {

        public static void SaveQuestion(String text)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var param = new DynamicParameters();
                param.Add("text", "%" + text + "%");
                cnn.Execute("insert into onpd_questions (question) values (@text)", param);
            }
        }

        public static List<string> GetQuestions()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var param = new DynamicParameters();

                return cnn.Query<string>("select question from onpd_questions", param).ToList();
            }
        }

        public static List<Person> GetPersons()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<Person>("select * from person", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<RecordsOnpd> LoadRecords()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<RecordsOnpd>("select * from onpd_records order by date desc", new DynamicParameters());
                return output.ToList();
            }
        }

        public static Person GetPersonById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var param = new DynamicParameters();
                param.Add("Id", id);
                return cnn.Query<Person>("select * from person where id = @Id", param).First(); ;
            }
        }

        public static List<RecordsOnpd> GetRecordsByName(string name)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var param = new DynamicParameters();
                param.Add("Name", "%" + name + "%");
                var p = cnn.Query<Person>("select id from person where name like @Name", param).ToList();
                StringBuilder stringBuilder = new StringBuilder();

                if (p.Count != 0)
                {
                    stringBuilder.Append(p[0].Id);

                    for (int i = 1; i < p.Count; i++)
                    {
                        stringBuilder.Append("," + p[i].Id);

                    }
                }
                return cnn.Query<RecordsOnpd>("select * from onpd_records where person_id in (" + stringBuilder.ToString() + ")", param).ToList();
            }
        }

        public static List<RecordsOnpd> GetRecordsByNameAndDate(string name, string date)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var param = new DynamicParameters();
                param.Add("Name", "%" + name + "%");
                var p = cnn.Query<Person>("select id from person where name like @Name", param).ToList();
                StringBuilder stringBuilder = new StringBuilder();

                if (p.Count != 0)
                {
                    stringBuilder.Append(p[0].Id);

                    for (int i = 1; i < p.Count; i++)
                    {
                        stringBuilder.Append("," + p[i].Id);

                    }
                }
                param.Add("Date", "%" + date + "%");

                return cnn.Query<RecordsOnpd>("select * from onpd_records where person_id in (" + stringBuilder.ToString() + ") and date like @Date", param).ToList();
            }
        }

        public static List<RecordsOnpd> GetRecordsByDate(string date)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var param = new DynamicParameters();
                param.Add("Date", "%" + date + "%");

                return cnn.Query<RecordsOnpd>("select * from onpd_records where date like @Date", param).ToList();
            }
        }

        public static int GetLastPerson()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var param = new DynamicParameters();

                return cnn.Query<int>("select id from person order by id desc limit 1", param).ToList().First();
            }
        }
        public static void SaveRecord(RecordsOnpd record)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into onpd_records (person_id, date, first, second, a, d, dp) values (@Person_id, @Date, @First, @Second, " +
                    "@A, @D, @DP)", record);
            }
        }



        public static void SavePerson(Person person)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into person (name, sex, age) values (@Name, @Sex, @Age)", person);
            }
        }

        private static string loadConnectionString(string id = "Default")
        {
            var bla = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Test Application/db.db");
            return $"Data Source={bla};Version=3;";
            //return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
