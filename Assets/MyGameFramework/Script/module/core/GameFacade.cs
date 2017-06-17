using Assets.MyGameFramework.Script.module.core.command;
using MyGameFramework;

public class GameFacade: EasyFacade
{

    public GameFacade() : base()
    {

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
        LuaManager.getInstance().tick();
    }
}