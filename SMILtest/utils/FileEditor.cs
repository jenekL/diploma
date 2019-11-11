using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace SMILtest.utils
{
    class FileEditor
    {
        private static Word.Bookmarks wBookmarks;
        private static Word.Range wRange;

        FileEditor()
        {
        }

        private static void typeInBookMark(string nameBookMark, string data)
        {
            wRange = wBookmarks[nameBookMark].Range;
            wRange.Text = data;
        }

        public static void loadShortFile(string name, string age, string sex, string date,
        int first, int second, int A, int D, int DP)
        {
            try
            {
                var app = new Word.Application();
                var doc = new Word.Document();

                var path = AppDomain.CurrentDomain.BaseDirectory + "/res/text/templateShort.docx";

                doc = app.Documents.Add(Template: path);
                app.Visible = true;

                wBookmarks = doc.Bookmarks;

                typeInBookMark("фио", name);
                typeInBookMark("возраст", age);
                typeInBookMark("пол", sex);
                typeInBookMark("дата_теста", date);
                typeInBookMark("шкала_1", first.ToString());
                typeInBookMark("шкала_2", second.ToString());
                typeInBookMark("шкала_а", A.ToString());
                typeInBookMark("шкала_д", D.ToString());
                typeInBookMark("шкала_др", DP.ToString());
                typeInBookMark("шкала_1_2", (first + second).ToString());
                typeInBookMark("шкала_д_а_др", (D + A + DP).ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.ToString());
            }
        }

        public static void loadShortFileSMIL(string name, string age, string sex, string date,
       int F, int L, int K, int Hs, int D, int Hy, int Ma, int Mf, int Pa, int Pt, int Si, int Sc, int Pd)
        {
            try
            {
                var app = new Word.Application();
                var doc = new Word.Document();

                var path = AppDomain.CurrentDomain.BaseDirectory + "/res/text/templateShortSMIL.docx";

                doc = app.Documents.Add(Template: path);
                app.Visible = true;

                wBookmarks = doc.Bookmarks;

                typeInBookMark("фио", name);
                typeInBookMark("возраст", age);
                typeInBookMark("пол", sex);
                typeInBookMark("дата_теста", date);
                typeInBookMark("F", F.ToString());
                typeInBookMark("L", L.ToString());
                typeInBookMark("K", K.ToString());
                typeInBookMark("Hs", Hs.ToString());
                typeInBookMark("D", D.ToString());
                typeInBookMark("Hy", Hy.ToString());
                typeInBookMark("Ma", Ma.ToString());
                typeInBookMark("Mf", Mf.ToString());
                typeInBookMark("Pa", Pa.ToString());
                typeInBookMark("Pt", Pt.ToString());
                typeInBookMark("Sc", Sc.ToString());
                typeInBookMark("Si", Si.ToString());
                typeInBookMark("Pd", Si.ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.ToString());
            }
        }

        public static void loadFile(string name, string age, string sex, string date,
            List<int> results, int first, int second, int A, int D, int DP)
        {
            try
            {
                var app = new Word.Application();
                var doc = new Word.Document();

                var path = AppDomain.CurrentDomain.BaseDirectory + "/res/text/template.docx";

                doc = app.Documents.Add(Template: path);
                app.Visible = true;

                wBookmarks = doc.Bookmarks;

                typeInBookMark("фио", name);
                typeInBookMark("возраст", age);
                typeInBookMark("пол", sex);
                typeInBookMark("дата_теста", date);
                typeInBookMark("шкала_1", first.ToString());
                typeInBookMark("шкала_2", second.ToString());
                typeInBookMark("шкала_а", A.ToString());
                typeInBookMark("шкала_д", D.ToString());
                typeInBookMark("шкала_др", DP.ToString());
                typeInBookMark("шкала_1_2", (first + second).ToString());
                typeInBookMark("шкала_д_а_др", (D + A + DP).ToString());

                int j = 1;
                foreach (int i in results)
                {
                    if (i == 1)
                    {
                        typeInBookMark("да_" + j, "+");

                    }
                    else
                    {
                        typeInBookMark("нет_" + j, "+");

                    }
                    j++;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.ToString());
            }
        }
    }
}
