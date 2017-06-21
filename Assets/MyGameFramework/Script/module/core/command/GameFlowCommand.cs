using MyGameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.MyGameFramework.Script.module.core.command
{
    public class GameFlowCommand:EasyCommand
    {
        public void gotoLogin()
        {
            GameSceneManage.getInstance().switchScene((int)GameConst.SceneName.Login);
        }
    }
}
