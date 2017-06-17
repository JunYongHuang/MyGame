using Assets.MyGameFramework.Script.mvc.mymvc;
using MyGameFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyGameFramework
{
    public class InitAppCommand:EasyCommand
    {
        public void init()
        {
            initManager();
        }

        private void initManager()
        {
            LuaManager.getInstance();
            GameManager.getInstance();
            LuaManager.getInstance().DoString("require 'lua.main'");
        }

    }
}
