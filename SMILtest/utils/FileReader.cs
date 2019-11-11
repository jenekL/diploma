using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMILtest
{
    class FileReader
    {
        public static List<string> readFileByLines(string path)
        {
            List<string> lines = new List<string>();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                sr.Close();
            }
            return lines;
        }
        public static string readFileInLine(string path)
        {
            string line;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(path, System.Text.Encoding.Default))
            {
                line = sr.ReadToEnd();
                sr.Close();
            }
            return line;
        }


    }
}
