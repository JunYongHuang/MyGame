using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Text;

namespace Assets.MyGameFramework.Editor.GenerateCmd { 
    public class GenerateCmd
    {
        [MenuItem("Tool/导出Cmd")]
        private static void generateCmd()
        {
            LoggerManager.Debug("GenerateCmd", "开始生成EasyCommand");

 
            string classTemplate=FileStaticAPI.Read(Application.dataPath+"/MyGameFramework/Editor/GenerateCmd/CommandTemplate.txt");
            string functionTemplate= FileStaticAPI.Read(Application.dataPath + "/MyGameFramework/Editor/GenerateCmd/FunctionTemplate.txt");

            List<string> findResultList = new List<string>();
            FileStaticAPI.FindFileByExt(Application.dataPath+ "/MyGameFramework/Script/module/", "*Command.cs",ref findResultList);

            int generateCount = 0;
            foreach (string findFileUrl in findResultList)
            {
                string commandFileContent= FileStaticAPI.Read(findFileUrl);
                CSClass fileClass = new CSClass();
                fileClass.Load(commandFileContent);
                if (fileClass.isCheckOk)
                {
                    StringBuilder sb = new StringBuilder();
                    int len = fileClass.functionsList.Count;
                    for (int i = 0; i < len; i++)
                    {
                        CSFunction function = fileClass.functionsList[i];
                        string functionContent = functionTemplate.Replace(@"%ReturnName%", function.returnType);
                        functionContent = functionContent.Replace(@"%FunctionName%", function.name);
                        functionContent = functionContent.Replace(@"%Namespace%", fileClass.nameSpace);
                        functionContent = functionContent.Replace(@"%ClassName%", fileClass.className);
                        StringBuilder paramEntranceStr = new StringBuilder();
                        StringBuilder paramTransferStr = new StringBuilder();
                        List<KeyValuePair<string, string>> paramList = function.getParamList();
                        int paramNum = paramList.Count;
                        for (var j = 0; j < paramNum; j++)
                        {
                            KeyValuePair<string, string> info = paramList[i];
                            paramEntranceStr.Append(info.Key);
                            paramEntranceStr.Append(" ");
                            paramEntranceStr.Append(info.Value);
                            paramTransferStr.Append(info.Value);
                            if (j + 1 < paramNum)
                            {
                                paramEntranceStr.Append(",");
                                paramTransferStr.Append(",");
                            }

                        }
                        functionContent = functionContent.Replace(@"%Param%", paramEntranceStr.ToString());
                        functionContent = functionContent.Replace(@"%Param2%", paramTransferStr.ToString());
                        sb.Append(functionContent);
                    }

                    string fileStr = classTemplate.Replace(@"%Namespace%", fileClass.nameSpace);
                    string newClassName = fileClass.className.Replace(@"Command", "Cmd");
                    fileStr = fileStr.Replace(@"%ClassName%", newClassName);


                    fileStr = fileStr.Replace(@"%Functions%", sb.ToString());
                    string outputFile = findFileUrl.Replace(@"Command.cs", "Cmd.cs");
                    FileStaticAPI.Write(outputFile, fileStr);
                    generateCount++;

                    LoggerManager.Debug<string>("生成文件：", fileClass.className);
                }            
            }

            LoggerManager.Debug<int>("共生成文件数：", generateCount);
        }

    }
}
