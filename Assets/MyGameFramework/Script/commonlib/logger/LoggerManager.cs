using System.Text;
using UnityEngine;




    public class LoggerManager
    {
        public enum LogLevel
        {
            Debug = 0,
            Warn = 1,
            Error = 2
        }

        public static LogLevel logLevel = LogLevel.Debug;

        private const int kTrimStrBufferSize = 4096;
        private const int kStrBufferInitSize = 128;
        private static StringBuilder StrBuffer = new StringBuilder(kStrBufferInitSize);

        #region Log routine
        static public void Warning<T1>(string tag, T1 arg1)
        {
            if (LogLevel.Warn < logLevel)
            {
                return;
            }

            WriteLog(LogLevel.Warn, tag, arg1);
        }

        static public void Warning<T1, T2>(string tag, T1 arg1, T2 arg2)
        {
            if (LogLevel.Warn < logLevel)
            {
                return;
            }

            WriteLog(LogLevel.Warn, tag, arg1, arg2);
        }

        static public void Warning<T1, T2, T3>(string tag, T1 arg1, T2 arg2, T3 arg3)
        {
            if (LogLevel.Warn < logLevel)
            {
                return;
            }

            WriteLog(LogLevel.Warn, tag, arg1, arg2, arg3);
        }

        static public void Warning<T1, T2, T3, T4>(string tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (LogLevel.Warn < logLevel)
            {
                return;
            }

            WriteLog(LogLevel.Warn, tag, arg1, arg2, arg3);
        }

        static public void Debug<T1>(string tag, T1 arg1)
        {
            if (LogLevel.Debug < logLevel)
            {
                return;
            }

            WriteLog(LogLevel.Debug, tag, arg1);
        }

        static public void Debug<T1, T2>(string tag, T1 arg1, T2 arg2)
        {
            if (LogLevel.Debug < logLevel)
            {
                return;
            }

            WriteLog(LogLevel.Debug, tag, arg1, arg2);
        }

        static public void Debug<T1, T2, T3>(string tag, T1 arg1, T2 arg2, T3 arg3)
        {
            if (LogLevel.Debug < logLevel)
            {
                return;
            }

            WriteLog(LogLevel.Debug, tag, arg1, arg2, arg3);
        }

        static public void Debug<T1, T2, T3, T4>(string tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (LogLevel.Debug < logLevel)
            {
                return;
            }

            WriteLog(LogLevel.Debug, tag, arg1, arg2, arg3, arg4);
        }

        static public void Error<T1>(string tag, T1 arg1)
        {
            if (LogLevel.Error < logLevel)
            {
                return;
            }

            WriteLog(LogLevel.Error, tag, arg1);
        }

        static public void Error<T1, T2>(string tag, T1 arg1, T2 arg2)
        {
            if (LogLevel.Error < logLevel)
            {
                return;
            }

            WriteLog(LogLevel.Error, tag, arg1, arg2);
        }

        static public void Error<T1, T2, T3>(string tag, T1 arg1, T2 arg2, T3 arg3)
        {
            if (LogLevel.Error < logLevel)
            {
                return;
            }

            WriteLog(LogLevel.Error, tag, arg1, arg2, arg3);
        }

        static public void Error<T1, T2, T3, T4>(string tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (LogLevel.Error < logLevel)
            {
                return;
            }

            WriteLog(LogLevel.Error, tag, arg1, arg2, arg3, arg4);
        }

        #endregion

        static private void TrimStringBuffer()
        {
            if (StrBuffer.Length >= kTrimStrBufferSize)
            {
                StrBuffer.Length = 0;
                StrBuffer.Capacity = kStrBufferInitSize;
            }
            else if (StrBuffer.Length != 0)
            {
                StrBuffer.Length = 0;
            }
        }

        static private void WriteLog<T1>(LogLevel level, string tag, T1 arg1)
        {
            TrimStringBuffer();

            StrBuffer.Append(tag);
            StrBuffer.Append(":");
            StrBuffer.Append(arg1);

            switch (level)
            {
                case LogLevel.Debug:
                    UnityEngine.Debug.Log(StrBuffer.ToString());
                    break;
                case LogLevel.Error:
                    UnityEngine.Debug.LogError(StrBuffer.ToString());
                    break;
                case LogLevel.Warn:
                    UnityEngine.Debug.LogWarning(StrBuffer.ToString());
                    break;
                default:
                    return;
            }
        }

        static private void WriteLog<T1, T2>(LogLevel level, string tag, T1 arg1, T2 arg2)
        {
            TrimStringBuffer();

            StrBuffer.Append(tag);
            StrBuffer.Append(":");
            StrBuffer.Append(arg1);
            StrBuffer.Append(arg2);

            switch (level)
            {
                case LogLevel.Debug:
                    UnityEngine.Debug.Log(StrBuffer.ToString());
                    break;
                case LogLevel.Error:
                    UnityEngine.Debug.LogError(StrBuffer.ToString());
                    break;
                case LogLevel.Warn:
                    UnityEngine.Debug.LogWarning(StrBuffer.ToString());
                    break;
                default:
                    return;
            }
        }

        static private void WriteLog<T1, T2, T3>(LogLevel level, string tag, T1 arg1, T2 arg2, T3 arg3)
        {
            TrimStringBuffer();

            StrBuffer.Append(tag);
            StrBuffer.Append(":");
            StrBuffer.Append(arg1);
            StrBuffer.Append(arg2);
            StrBuffer.Append(arg3);

            switch (level)
            {
                case LogLevel.Debug:
                    UnityEngine.Debug.Log(StrBuffer.ToString());
                    break;
                case LogLevel.Error:
                    UnityEngine.Debug.LogError(StrBuffer.ToString());
                    break;
                case LogLevel.Warn:
                    UnityEngine.Debug.LogWarning(StrBuffer.ToString());
                    break;
                default:
                    return;
            }
        }

        static private void WriteLog<T1, T2, T3, T4>(LogLevel level, string tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            TrimStringBuffer();

            StrBuffer.Append(tag);
            StrBuffer.Append(":");
            StrBuffer.Append(arg1);
            StrBuffer.Append(arg2);
            StrBuffer.Append(arg3);
            StrBuffer.Append(arg4);

            switch (level)
            {
                case LogLevel.Debug:
                    UnityEngine.Debug.Log(StrBuffer.ToString());
                    break;
                case LogLevel.Error:
                    UnityEngine.Debug.LogError(StrBuffer.ToString());
                    break;
                case LogLevel.Warn:
                    UnityEngine.Debug.LogWarning(StrBuffer.ToString());
                    break;
                default:
                    return;
            }
        }

        //static public void TestLog()
        //{
        //    logLevel = LogLevel.Error;

        //    LoggerManager.Debug("SimpleLog", "Debug");
        //    LoggerManager.Debug("SimpleLog", "Debug", 1);
        //    LoggerManager.Debug("SimpleLog", "Debug", 1, "2");
        //    LoggerManager.Debug("SimpleLog", "Debug", 1, "2", '3');

        //    LoggerManager.Warning("SimpleLog", "Warning");
        //    LoggerManager.Warning("SimpleLog", "Warning", 1);
        //    LoggerManager.Warning("SimpleLog", "Warning", 1, "2");
        //    LoggerManager.Warning("SimpleLog", "Warning", 1, "2", '3');

        //    LoggerManager.Error("SimpleLog", "Error");
        //    LoggerManager.Error("SimpleLog", "Error", 1);
        //    LoggerManager.Error("SimpleLog", "Error", 1, "2");
        //    LoggerManager.Error("SimpleLog", "Error", 1, "2", '3');
        //}

    }

