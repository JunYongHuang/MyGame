using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class EasyBaseMediator:IEasyBaseMediator
{
    protected EasyBaseView _baseView;



    public EasyBaseMediator()
    {
    }

    public void dispose()
    {
        _baseView = null;
    }

    public IEasyBaseMediator create()
    {
        return this;
    }

    public void init(EasyBaseView view)
    {
        _baseView = view;
        initComponent();
    }


    virtual protected void initComponent()
    {

    }

    virtual public void inited()
    {

    }

    virtual public void update()
    {

    }
}
