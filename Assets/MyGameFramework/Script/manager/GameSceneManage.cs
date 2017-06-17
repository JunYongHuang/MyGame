using Assets.MyGameFramework.Script.module.login.command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGameFramework
{
    public class GameSceneManage
    {
        private static GameSceneManage _instance;
        public delegate void SwitchFunc(object obj =null);
        private int _curSceneID;
        private Dictionary<int, ISceneSwitchCommand> _map;

        public static GameSceneManage getInstance()
        {
            if (_instance == null)
            {
                _instance = new GameSceneManage();
            }
            return _instance;
        }

        public GameSceneManage()
        {
            _curSceneID = 0;
            _map = new Dictionary<int, ISceneSwitchCommand>();
            addSceneFunc((int)GameConst.SceneName.Login, new SwitchLoginCommand());
        }



        private void addSceneFunc(int scene, ISceneSwitchCommand command)
        {
            _map[scene] = command;
        }

        public void switchScene(GameConst.SceneName scene,Object param=null)
        {
            int sceneID = (int)scene;
            if (_curSceneID == sceneID) return;
            ISceneSwitchCommand command;
            //old scene
            if (_map.ContainsKey(_curSceneID))
            {
                command = _map[_curSceneID];
                if (command != null)
                {
                    command.leaveScene(param);
                }
            }
            //new scene
            command = _map[sceneID];
            if (command != null)
            {
                command.enterScene(param);
            }
            _curSceneID = sceneID;
        }

    }
}
