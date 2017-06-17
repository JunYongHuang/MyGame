
using MyGameFramework;
using UnityEngine;

public class StartRoot : MonoBehaviour
{
    private GameFacade _facade;

    public StartRoot() : base()
    {

    }

    void Awake()
    {
        _facade = new GameFacade();
        _facade.startUp();
    }

    void Update()
    {
        LuaManager.getInstance().tick();
    }
}
