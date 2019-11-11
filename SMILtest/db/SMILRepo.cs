using System;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using SMILtest.entitites;
using System.Text;
using System.IO;

namespace SMILtest.db
{
    class SMILRepo
    {
        public static void SaveQuestion(String text)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var param = new DynamicParameters();
                param.Add("text", "%" + text + "%");
                cnn.Execute("insert into smil_questions (question) values (@text)", param);
            }
        }

        public static List<string> GetQuestionByIdRange(int id_begind, int id_end)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var param = new DynamicParameters();
                param.Add("ID1", "%" + id_begind + "%");
                param.Add("ID2", "%" + id_end + "%");

                return cnn.Query<string>("select * from smil_questions where id>= @ID1 and id< @ID2", param).ToList();
            }
        }

        public static List<string> GetAllQuestions()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var param = new DynamicParameters();

                return cnn.Query<string>("select question from smil_questions", param).ToList();
            }
        }
        public static List<RecordsSmil> GetRecordsByName(string name)
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
                return cnn.Query<RecordsSmil>("select * from smil_records where person_id in (" + stringBuilder.ToString() + ")", param).ToList();
            }
        }

        public static List<RecordsSmil> GetRecordsByNameAndDate(string name, string date)
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

                return cnn.Query<RecordsSmil>("select * from smil_records where person_id in (" + stringBuilder.ToString() + ") and date like @Date", param).ToList();
            }
        }

        public static List<RecordsSmil> GetRecordsByDate(string date)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var param = new DynamicParameters();
                param.Add("Date", "%" + date + "%");

                return cnn.Query<RecordsSmil>("select * from smil_records where date like @Date", param).ToList();
            }
        }
        public static List<RecordsSmil> GetAllRecords()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var param = new DynamicParameters();

                return cnn.Query<RecordsSmil>("select * from smil_records order by date desc", param).ToList();
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

        public static void AddPerson(string name, string sex, int age)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Query<string>($"insert into person (name, sex, age) values ('{name}', '{sex}', {age})");
            }
        }

        public static Person GetPersonById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                return cnn.Query<Person>($"select * from person where id = {id}").First();
            }
        }

        public static void AddSmilResult(int personId, int sc1, int sc2, int sc3, int sc4, int sc5, int sc6, int sc7, int sc8, int sc9, int sc10, int sc11, int sc12, int sc13)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Query<string>($"insert into smil_records (person_id, date, L, F, K, Hs, D, Hy, Pd, Mf, Pa,Pt, Sc,Ma, Si) " +
                    $"values ({personId},'{DateTime.Now}',{sc1},{sc2},{sc3},{sc4},{sc5},{sc6},{sc7},{sc8},{sc9},{sc10},{sc11},{sc12},{sc13})");
            }
        }

        public static Dictionary<int, int> GetAllTempAnswers()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var param = new DynamicParameters();

                return cnn.Query("select id_question, answer from temp_answers where source='smil'", param).ToDictionary(
                    row => (int)row.id_question,
                    row => (int)row.answer
                    );
            }
        }

        public static Person GetTempPerson()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var param = new DynamicParameters();

                return cnn.Query<Person>("select name, age, sex from temp_client where source='smil'", param).First();
            }
        }

        public static void SaveTemporaryAnswer(int answer, int id, string source, int client_id)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute($"insert into temp_answers (id_question, answer, source) values ({id}, {answer}, '{source}') " +
                    $"ON CONFLICT(id_question) DO UPDATE SET answer = {answer}");
            }
        }

        public static void DeleteTemporaryAnswer(string source)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute($"delete from temp_answers where source='{source}'");
            }
        }

        public static void DeleteTemporaryClient(string source)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute($"delete from temp_client where source='{source}'");
            }
        }

        public static void UpdateAgeTemporaryUser(int value, string source)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute($"insert into temp_client (source, name, age, sex) values ('{source}', 'test', {value}, 'test') " +
                    $"ON CONFLICT(source) DO UPDATE SET age = {value}");
            }
        }
        public static void UpdateNameTemporaryUser(string value, string source)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute($"insert into temp_client (source, name, age, sex) values ('{source}', '{value}', 123, 'test') " +
                    $"ON CONFLICT(source) DO UPDATE SET name = '{value}'");
            }
        }

        public static void UpdateGenderTemporaryUser(string value, string source)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute($"insert into temp_client (source, name, age, sex) values ('{source}', 'test', 123, '{value}') " +
                    $"ON CONFLICT(source) DO UPDATE SET sex = '{value}'");
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
