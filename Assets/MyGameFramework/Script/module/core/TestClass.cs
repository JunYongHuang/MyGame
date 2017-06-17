using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameFramework
{
    [XLua.Hotfix]
    public class TestClass
    {
        public void hello()
        {
            UnityEngine.Debug.Log("hello");
        }
    }
}
