using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Assets.MyGameFramework.Editor.GenerateCmd
{
    public class CSClass
    {
        public bool isCheckOk;

        public string nameSpace;
        public string className;
        public List<CSFunction> functionsList = new List<CSFunction>();

        public CSClass()
        {
            isCheckOk = false;
        }

        public void Load(string content)
        {
            string code = CCodeUtils.GetCleanCode(content);
            isCheckOk = Parse(content);
        }

        private bool Parse(string code)
        {
            if (code == null) return false;
            if (code.IndexOf("class") == -1)
                return false;

            //get namespace
            Regex reg = new Regex(@"namespace (.*)");
            Match match = reg.Match(code);
            if (match.Success)
            {
                nameSpace = match.Groups[1].ToString().TrimEnd();
            }
            else
            {
                nameSpace = "";
            }

            //get classname
            reg = new Regex(@"class (\w+):(.*)");
            match = reg.Match(code);
            if (match.Success)
            {
                className = match.Groups[1].ToString().Trim();
                string inheritCommandName= match.Groups[2].ToString().Trim();
                if(inheritCommandName!= "EasyCommand")
                {
                    return false;
                }
            }
            else
            {
                LoggerManager.Debug<string>("not find classname", code);
                return false;
            }

            reg = new Regex(@"public\s+(\w+)\s+[\*,&]*\s*(\w+)\s*\((.*)\)");
            MatchCollection list = reg.Matches(code);
            int len = list.Count;
            for (int i=0;i<len;i++)
            {
                Match functionMatch = list[i];
                CSFunction function = new CSFunction(functionMatch.Groups[0].ToString(),functionMatch.Groups[1].ToString(), functionMatch.Groups[2].ToString(), functionMatch.Groups[3].ToString());
                functionsList.Add(function);
            }

            return true;
        }

    }


}
