using Assets.MyGameFramework.Script.module.core.command;
using MyGameFramework;
using UnityEngine;

public class GameFacade: EasyFacade
{
    private float _lastGCTime;
    internal const float GCInterval = 1;//1 second 

    public GameFacade() : base()
    {
        _lastGCTime = 0;
    }

    /// <summary>
    /// 启动框架
    /// </summary>
    public void startUp() {
        InitAppCmd.init();
        GameFlowCmd.gotoLogin();
    }

    public void update()
    {
        if (Time.time - LuaBehaviour.lastGCTime > GCInterval)
        {
            LuaManager.getInstance().tick();
            _lastGCTime = Time.time;
        }
    }
}