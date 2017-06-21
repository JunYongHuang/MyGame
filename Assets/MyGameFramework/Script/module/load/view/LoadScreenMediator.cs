using MyGameFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.MyGameFramework.Script.module.load.view
{
    public class LoadScreenMediator : EasyBaseMediator
    {
        private LoadScreen _view;
        private CircleProcess _updateProgress;
        private AsyncOperation _mAsyncOperation;

        override protected void initComponent()
        {
            _view = (LoadScreen)_baseView;

            _updateProgress = _view.progressCircle.GetComponent<CircleProcess>();
        }


        override public void inited()
        {
            _view.StartCoroutine(LoadScene());
        }

        private IEnumerator LoadScene()
        {
            _mAsyncOperation = SceneManager.LoadSceneAsync(GameSceneManage.getInstance().getNextSceneID());
            LoggerManager.Debug<int>("load", 1);
            while (!_mAsyncOperation.isDone && _mAsyncOperation.progress < 0.8f)
            {
                _updateProgress.currentAmout = (int)(_mAsyncOperation.progress * 100);
                yield return _mAsyncOperation;
            }
            _updateProgress.currentAmout = 100;
        }
    }
}
