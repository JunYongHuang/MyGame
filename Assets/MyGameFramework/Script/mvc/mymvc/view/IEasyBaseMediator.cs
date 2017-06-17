using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XLua;

[CSharpCallLua]
public interface IEasyBaseMediator
{
    IEasyBaseMediator create();
    void init();

}

