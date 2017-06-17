using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.MyGameFramework.Script.mvc.mymvc
{


    public class EasyCommandUtil
    {
        private static EasyCommandUtil _intance;
        private Dictionary<string, EasyCommand> _cache;
        private Queue<string> _keyList;
        private int max = 3;

        public static EasyCommandUtil getInstance()
        {
            if (_intance == null)
            {
                _intance = new EasyCommandUtil();
            }
            return _intance;
        }

        public EasyCommandUtil(){
            _cache = new Dictionary<string, EasyCommand>();
            _keyList = new Queue<string>();
        }
        

        public EasyCommand getCacheEasyCommand(string key)
        {
            foreach (var item in _cache)
            {
                if (item.Key == key)
                {
                    return item.Value;
                }
            }
            return null;
        }

        public void setCacheEasyCommand(string key,EasyCommand cmd)
        {
            _cache[key] = cmd;
            if (!_keyList.Contains(key))
            {
                _keyList.Enqueue(key);
            }
            if(_keyList.Count> max)
            {
                string removeKey=_keyList.Dequeue();
                _cache.Remove(removeKey);
            }
        }
            
    }


}
