using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Assets.MyGameFramework.Editor.GenerateCmd
{
    public class CSFunction
    {
        public string content;
        public string returnType;
        public string functionParams;
        public string name;
        private List<KeyValuePair<string, string>> functionParamsList;

        public CSFunction(string content, string returnType, string name, string functionParams)
        {
            this.content = content;
            this.returnType = returnType;
            this.name = name;
            Regex reg = new Regex(@"(\w+)\s(\w+)");
            MatchCollection list = reg.Matches(functionParams);
            int len = list.Count;
            functionParamsList = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < len; i++)
            {
                Match functionMatch = list[i];
                KeyValuePair<string, string> paramValue = new KeyValuePair<string, string>(functionMatch.Groups[1].ToString(), functionMatch.Groups[2].ToString());
                functionParamsList.Add(paramValue);
            }
        }

        public List<KeyValuePair<string, string>> getParamList()
        {
            return functionParamsList;
        }
    }

}
