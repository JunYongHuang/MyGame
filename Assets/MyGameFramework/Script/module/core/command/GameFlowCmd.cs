using Assets.MyGameFramework.Script.mvc.mymvc;

namespace Assets.MyGameFramework.Script.module.core.command{
	public class GameFlowCmd
	{
		
			public static void gotoLogin(){
				GameFlowCommand cmd =EasyCommandUtil.getInstance().getCacheEasyCommand("Assets.MyGameFramework.Script.module.core.command.GameFlowCommand") as GameFlowCommand ;
				if(cmd==null){
					cmd=new GameFlowCommand();
					EasyCommandUtil.getInstance().setCacheEasyCommand("Assets.MyGameFramework.Script.module.core.command.GameFlowCommand",cmd);
				}
				cmd.gotoLogin();
			}

	}
}
