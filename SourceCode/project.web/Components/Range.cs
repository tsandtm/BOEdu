using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.web.Utils
{
    public class Range
    {
        public static List<int> GetYears(int intRange)
        {
            List<int> ltIntOutput = new List<int>();

            for (int i = 0; i < intRange; i++)
                ltIntOutput.Add(i);

            return ltIntOutput;
        }

        public static List<int> GetYears(int intLowerRange, int intUpperRange)
        {
            List<int> ltIntOutput = new List<int>();

            for (int i = intLowerRange; i < intUpperRange; i++)
                ltIntOutput.Add(i);

            return ltIntOutput;
        }

        public static List<int> GetYears(int intLowerRange, int intUpperRange, int intStep)
        {
            List<int> ltIntOutput = new List<int>();

            if (intLowerRange < intUpperRange && intStep > 0)
            {
                for (int i = intLowerRange; i < intUpperRange; i += intStep)
                    ltIntOutput.Add(i);
            }
            else
                if (intLowerRange > intUpperRange && intStep < 0)
                {
                    for (int i = intLowerRange; i > intUpperRange; i += intStep)
                        ltIntOutput.Add(i);
                }

            return ltIntOutput;
        }

        public static List<NamHoc> GetDSNamHoc(int intLowerRange, int intUpperRange, int intStep)
        {
            List<NamHoc> listOutput = new List<NamHoc>();

            if (intLowerRange < intUpperRange && intStep > 0)
            {
                for (int i = intLowerRange; i < intUpperRange; i += intStep)
                {
                    NamHoc namHoc = new NamHoc() { Ten = GetNamHoc(i), Nam = i };
                    listOutput.Add(namHoc);
                }
            }
            else
                if (intLowerRange > intUpperRange && intStep < 0)
                {
                    for (int i = intLowerRange; i > intUpperRange; i += intStep)
                    {
                        NamHoc namHoc = new NamHoc() { Ten = GetNamHoc(i), Nam = i };
                        listOutput.Add(namHoc);
                    }
                }

            return listOutput;
        }

        public static string GetNamHoc(int selectYear)
        {
            return String.Format("{0}-{1}", selectYear, (selectYear + 1));
        }
    }


    public struct NamHoc
    {
        public string Ten { get; set; }
        public int Nam { get; set; }
    }
}
