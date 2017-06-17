using Assets.MyGameFramework.Script.mvc.mymvc;

namespace MyGameFramework{
	public class InitAppCmd
	{
		
			public static void init(){
				InitAppCommand cmd =EasyCommandUtil.getInstance().getCacheEasyCommand("MyGameFramework.InitAppCommand") as InitAppCommand ;
				if(cmd==null){
					cmd=new InitAppCommand();
					EasyCommandUtil.getInstance().setCacheEasyCommand("MyGameFramework.InitAppCommand",cmd);
				}
				cmd.init();
			}

	}
}
