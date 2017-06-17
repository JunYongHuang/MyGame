using PureMVC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MyGameFramework;

public class EasyBaseView: MonoBehaviour
{
    private IEasyBaseMediator mediator;
    public string luaMediatorName;
    public EasyBaseView()
    {


    }

    void Awake()
    {
        LoggerManager.Error<String>("core", "run");
        if (luaMediatorName != null)
        {
            mediator = LuaManager.getInstance().getLuaTable<string, IEasyBaseMediator>(luaMediatorName);
            if (mediator == null)
            {
                LoggerManager.Error<String>("core", luaMediatorName + " mediator lua not find");
            }
            else
            {
                mediator=mediator.create();
                mediator.init();
            }
        }
    }
}
