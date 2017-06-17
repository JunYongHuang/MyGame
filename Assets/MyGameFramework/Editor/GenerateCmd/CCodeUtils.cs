using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.MyGameFramework.Editor.GenerateCmd
{
    class CCodeUtils
    {
        public static string GetCleanCode(string code)
        {
            string sData = code;
            string sNew = "";

            sData = sData.Replace("\t", "");

            while (sData.IndexOf("/*") != -1)
            {
                int nStart = sData.IndexOf("/*");
                int nEnd = sData.IndexOf("*/", nStart);
                sData = sData.Remove(nStart, nEnd - nStart + 2);
            }

            string[] lines = sData.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                string sUsed = line.Trim().Split(new string[] { "//" }, StringSplitOptions.None)[0];
                if (sUsed.Length > 0)
                    sNew += sUsed + "\r\n";
            }

            return sNew;
        }
    }
}
