using Assets.MyGameFramework.Script.module.login.command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

namespace MyGameFramework
{
    public class GameSceneManage
    {
        private static GameSceneManage _instance;
        public delegate void SwitchFunc(object obj =null);
        private int _curSceneID;
        private Dictionary<int, ISceneSwitchCommand> _extralCommandMap;

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
            _extralCommandMap = new Dictionary<int, ISceneSwitchCommand>();
        }



        public void addExtralSceneFunc(int scene, ISceneSwitchCommand command)
        {
            _extralCommandMap[scene] = command;
        }

        public void switchScene(GameConst.SceneName scene,Object param=null)
        {
            int sceneID = (int)scene;
            if (_curSceneID == sceneID) return;
            ISceneSwitchCommand command;
            //old scene
            if (_extralCommandMap.ContainsKey(_curSceneID))
            {
                command = _extralCommandMap[_curSceneID];
                if (command != null)
                {
                    command.leaveScene(param);
                }
            }
            //new scene
            if (_extralCommandMap.ContainsKey(sceneID))
            {
                command = _extralCommandMap[sceneID];
                if (command != null)
                {
                    command.enterScene(param);
                }
            }
            _curSceneID = sceneID;
            loadNextScene(_curSceneID);
        }

        public int getNextSceneID()
        {
            return _curSceneID;
        }

        private void loadNextScene(int sceneID)
        {
            SceneManager.LoadScene((int)GameConst.SceneName.Load);
        }

    }
}
