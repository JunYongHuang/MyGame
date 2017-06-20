using MyGameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.MyGameFramework.Script.module.load.view
{
    public class LoadScreen:EasyBaseView
    {
        [SubComponent]
        public GameObject progressCircle;

        public LoadScreen():base()
        {
            setMediator(new LoadScreenMediator());
            LoggerManager.Debug<int>("load screen", (int)GameSceneManage.getInstance().getNextSceneID());
        }


    }
}
