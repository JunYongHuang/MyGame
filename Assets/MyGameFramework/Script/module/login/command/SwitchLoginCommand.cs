using Assets.MyGameFramework.Script.module.login.view;
using MyGameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

namespace Assets.MyGameFramework.Script.module.login.command
{
    public class SwitchLoginCommand : ISceneSwitchCommand
    {
        public void enterScene(object param)
        {
            SceneManager.LoadScene((int)GameConst.SceneName.Login);
        }

        public void leaveScene(object param)
        {

        }

    }
}
