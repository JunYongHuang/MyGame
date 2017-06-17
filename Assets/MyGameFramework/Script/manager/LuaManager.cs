using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XLua;

namespace MyGameFramework
{
    public class LuaManager
    {
        private static LuaManager _instance;
        private LuaEnv _env;
        public static LuaManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new LuaManager();
            }
            return _instance;
        }

        public LuaManager()
        {
            _env = new LuaEnv();
            LoggerManager.Debug("Init","LuaManager init");
        }

        public TValue getLuaTable<TKey, TValue>(TKey key)
        {
            TValue table;
            _env.Global.Get<TKey, TValue>(key,out table);
            return table;
        }

        public TValue getLuaValue<TValue>(string key)
        {
            return _env.Global.GetInPath<TValue>(key);
        }

        public void tick()
        {
            _env.Tick();
        }

        public object[] DoString(string script)
        {
            return _env.DoString(script);
        }




    }
}
