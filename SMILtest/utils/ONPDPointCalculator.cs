using SMILtest.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMILtest.utils
{
    class ONPDPointCalculator
    {
        private static readonly int[] T_FIRST_SCALE = { 21, 23, 24, 26, 27, 29, 30, 32,
            33, 35, 36, 37, 39, 40, 42, 43, 45, 46, 48, 49, 51, 52, 54, 55, 57, 58, 60 };
        private static readonly int[] T_SECOND_SCALE = { 17, 19, 21, 23, 25, 26, 28,
            30, 32, 33, 35, 37, 39, 41, 42, 44, 46, 48, 49, 51, 53, 55, 56, 58 };
        private static readonly int[] T_D_SCALE = { 39, 40, 42, 44, 46, 47, 49, 51, 53,
            54, 56, 58, 60, 61, 63, 65, 66, 68, 70, 72, 73, 75, 77, 79, 80, 82, 84, 86, 87, 89, 91, 93, 94, 96, 98, 100 };
        private static readonly int[] T_A_SCALE = { 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 56, 58, 60, 62, 64, 66, 68, 70, 72, 74, 76, 78 };
        private static readonly int[] T_DP_SCALE = { 38, 40, 41, 43, 45, 46, 48, 50, 51,
            53, 55, 56, 58, 60, 61, 63, 65, 67, 68, 70, 71, 73, 75, 77, 78, 80, 81, 83, 85, 88, 90 };


        private static Dictionary<string, int> scales = new Dictionary<string, int>
        {
            {"First",0 },
            {"Second",0 },
            {"D",0 },
            {"A",0 },
            {"DP",0 },
        };
       
        public static List<int> GetResultsBoolean(List<QuestionElement> panelElements)
        {
            var results = new List<int>();
            foreach (QuestionElement panelElement in panelElements)
            {
                if (panelElement.Cb1.Checked)
                {
                    results.Add(1);
                }
                else
                {
                    results.Add(0);
                }
            }
            return results;
        }
        public static Dictionary<string, int> GetResult(List<QuestionElement> panelElements)
        {
            countPoints(panelElements);
            return convertPointsToT();
        }

        private static void countPoints(List<QuestionElement> panelElements)
        {
            int num = 1;
            foreach (QuestionElement panelElement in panelElements)
            {
                switch (num)
                {
                    case 1:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["First"] += 6;
                        }
                        break;
                    case 2:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["DP"] += 6;
                        }
                        break;
                    case 3:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["First"] += 3;
                        }
                        break;
                    case 4:
                        if (panelElement.Cb1.Checked)
                        {
                            scales["A"] += 5;
                        }
                        break;
                    case 5:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["Second"] += 1;
                        }
                        else
                        {
                            scales["D"] += 2;
                        }
                        break;
                    case 6:
                        if (panelElement.Cb1.Checked)
                        {
                            scales["DP"] += 2;
                        }
                        break;
                    case 7:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["Second"] += 8;
                        }
                        else
                        {
                            scales["DP"] += 1;
                        }
                        break;
                    case 8:
                        if (panelElement.Cb1.Checked)
                        {
                            scales["First"] += 1;
                        }
                        break;
                    case 9:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["D"] += 6;
                        }
                        break;
                    case 10:
                        if (panelElement.Cb1.Checked)
                        {
                            scales["DP"] += 1;
                        }
                        break;
                    case 11:
                        if (panelElement.Cb1.Checked)
                        {
                            scales["A"] += 1;
                        }
                        break;
                    case 12:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["D"] += 4;
                        }
                        break;
                    case 13:
                        if (panelElement.Cb1.Checked)
                        {
                            scales["A"] += 2;
                            scales["D"] += 1;
                        }
                        break;
                    case 14:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["First"] += 7;
                        }
                        break;
                    case 15:
                        if (panelElement.Cb1.Checked)
                        {
                            scales["D"] += 1;
                            scales["DP"] += 2;
                        }
                        else
                        {
                            scales["A"] += 1;
                        }
                        break;
                    case 16:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["First"] += 3;
                        }
                        else
                        {
                            scales["D"] += 1;
                        }
                        break;
                    case 17:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["Second"] += 3;
                        }
                        else
                        {
                            scales["DP"] += 6;
                        }
                        break;
                    case 18:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["D"] += 5;
                        }
                        break;
                    case 19:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["A"] += 7;
                        }
                        break;
                    case 20:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["A"] += 1;
                        }
                        else
                        {
                            scales["D"] += 4;
                        }
                        break;
                    case 21:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["Second"] += 3;
                        }
                        break;
                    case 22:
                        //nothing
                        break;
                    case 23:
                        if (panelElement.Cb1.Checked)
                        {
                            scales["D"] += 6;
                        }
                        else
                        {
                            scales["A"] += 3;
                        }
                        break;
                    case 24:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["First"] += 4;
                        }
                        break;
                    case 25:
                        if (panelElement.Cb1.Checked)
                        {
                            scales["D"] += 6;
                        }
                        else
                        {
                            scales["DP"] += 5;
                        }
                        break;
                    case 26:
                        if (panelElement.Cb2.Checked)
                        {
                            scales["Second"] += 6;
                        }
                        else
                        {
                            scales["DP"] += 3;
                        }
                        break;
                    case 27:
                        if (panelElement.Cb1.Checked)
                        {
                            scales["DP"] += 1;
                        }
                        break;
                    case 28:
                        if (panelElement.Cb1.Checked)
                        {
                            scales["First"] += 1;
                            scales["DP"] += 1;
                        }
                        break;
                    case 29:
                        if (panelElement.Cb1.Checked)
                        {
                            scales["A"] += 2;
                        }
                        break;
                    case 30:
                        if (panelElement.Cb1.Checked)
                        {
                            scales["First"] += 1;
                            scales["DP"] += 3;
                        }
                        else
                        {
                            scales["Second"] += 2;
                        }
                        break;
                }
                num++;
            }
        }

        private static Dictionary<string, int> convertPointsToT()
        {
            scales["First"] = T_FIRST_SCALE[scales["First"]];
            scales["Second"] = T_SECOND_SCALE[scales["Second"]];
            scales["A"] = T_A_SCALE[scales["A"]];
            scales["D"] = T_D_SCALE[scales["D"]];
            scales["DP"] = T_DP_SCALE[scales["DP"]];
            return scales;
        }
    }
}
