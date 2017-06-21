using PureMVC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MyGameFramework;
using System.Reflection;
using System.Collections;

public class EasyBaseView : MonoBehaviour, IEasyDisposable
{
    private IEasyBaseMediator mediator;
    public string luaMediatorName;
    private bool _isLuaMediator;


    public EasyBaseView()
    {
        init();
    }

    protected void init()
    {
        _isLuaMediator = false;
    }

    protected void initMediator()
    {
        if (mediator == null)
        {
            if (luaMediatorName != null)
            {
                _isLuaMediator = true;
                mediator = LuaManager.getInstance().getLuaTable<string, IEasyBaseMediator>(luaMediatorName);
                if (mediator == null)
                {
                    LoggerManager.Error<String>("core", luaMediatorName + " mediator lua not find");
                }
            }
            mediator = mediator.create();
        }
    }

    public void setMediator(IEasyBaseMediator mediator)
    {
        this.mediator = mediator;
    }

    public bool HasDisposed { get; private set; }

    public virtual bool Dispose(float t = 0)
    {
        if (t == 0 ||
            (!gameObject.activeSelf))
        {
            mediator = null;
            HasDisposed = true;
            Destroy(gameObject);
            return true;
        }
        else
        {
            StartCoroutine(DisposeDelay(t));
            return false;
        }
    }

    IEnumerator DisposeDelay(float t)
    {
        yield return new WaitForSeconds(t);
        Dispose();
    }

    protected void initSubComponentProp()
    {
        Type type = this.GetType();
        PropertyInfo[] props = type.GetProperties();
        FieldInfo[] fields = type.GetFields();

        Dictionary<string, PropertyInfo> childrenForProp = new Dictionary<string, PropertyInfo>();
        Dictionary<string, FieldInfo> childrenForField = new Dictionary<string, FieldInfo>();

        foreach (PropertyInfo prop in props)
        {
            object[] injections = prop.GetCustomAttributes(typeof(SubComponent), true);
            if (injections.Length != 0)
                childrenForProp[prop.Name] = prop;
        }

        foreach (FieldInfo field in fields)
        {
            object[] injections = field.GetCustomAttributes(typeof(SubComponent), true);
            if (injections.Length != 0)
                childrenForField[field.Name] = field;
        }

        foreach (Transform t in this.GetComponentsInChildren<Transform>())
        {
            if (childrenForProp.Keys.Contains(t.name))
            {
                Type childType = childrenForProp[t.name].PropertyType;
                if (childType == typeof(GameObject))
                    childrenForProp[t.name].SetValue(this, t.gameObject, null);
                else
                {
                    Component childComp = t.GetComponent(childType);
                    childrenForProp[t.name].SetValue(this, childComp, null);
                }

                childrenForProp.Remove(t.name);
            }
            else if (childrenForField.Keys.Contains(t.name))
            {
                Type childType = childrenForField[t.name].FieldType;
                if (childType == typeof(GameObject))
                    childrenForField[t.name].SetValue(this, t.gameObject);
                else
                {
                    Component childComp = t.GetComponent(childType);
                    childrenForField[t.name].SetValue(this, childComp);
                }

                childrenForField.Remove(t.name);
            }
        }

        foreach (KeyValuePair<string, PropertyInfo> pair in childrenForProp)
        {
            Transform t = this.transform.Find(pair.Key);
            if (t != null)
            {
                Type childType = childrenForProp[t.name].PropertyType;
                if (childType == typeof(GameObject))
                    childrenForProp[t.name].SetValue(this, t.gameObject, null);
                else
                {
                    Component childComp = t.GetComponent(childType);
                    childrenForProp[t.name].SetValue(this, childComp, null);
                }
            }
        }


        foreach (KeyValuePair<string, FieldInfo> pair in childrenForField)
        {
            Transform t = this.transform.Find(pair.Key);
            if (t != null)
            {
                Type childType = childrenForField[t.name].FieldType;
                if (childType == typeof(GameObject))
                    childrenForField[t.name].SetValue(this, t.gameObject);
                else
                {
                    Component childComp = t.GetComponent(childType);
                    childrenForField[t.name].SetValue(this, childComp);
                }
            }
        }
    }

    IEnumerator runInited()
    {
        yield return 1;
        if (mediator != null)
        {
            mediator.inited();
        }

    }

    void Awake()
    {
        initSubComponentProp();
        initMediator();
        if (mediator != null)
        {
            mediator.init(this);
            StartCoroutine(runInited());
        }

    }

    public void Update()
    {
        if (mediator != null)
        {
            mediator.update();
        }
    }
}
