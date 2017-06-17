using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGameFramework
{
    [XLua.Hotfix]
    public class GameManager
    {
        private static GameManager _instance;
        public static GameManager getInstance() {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }

        public GameManager()
        {
           LoggerManager.Debug("Init","GameManager init");
        }

    }
}
