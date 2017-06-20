using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UI
{
    public class CircleProcess : MonoBehaviour
    {

        [SerializeField]
        float speed;

        [SerializeField]
        Transform process;

        [SerializeField]
        Transform indicator;
        private Text text_indicator;
        private Image img_process;

        public int targetProcess { get; set; }
        public int currentAmout {
            set
            {
                if (value != _currentAmout)
                {
                    _currentAmout = value;
                    refreshProcess();
                }
            }
        }
        private float _currentAmout = 0;

        // Use this for initialization
        void Start()
        {
            targetProcess = 100;
            text_indicator = indicator.GetComponent<Text>();
            img_process = process.GetComponent<Image>();
        }


        private void refreshProcess()
        {
            if (_currentAmout < targetProcess)
            {
                if (_currentAmout > targetProcess)
                    _currentAmout = targetProcess;
                if (text_indicator != null)
                {
                    indicator.GetComponent<Text>().text = ((int)_currentAmout).ToString() + "%";
                }
                if (img_process != null)
                {
                    process.GetComponent<Image>().fillAmount = _currentAmout / 100.0f;
                }

            }
        }


        public void SetTargetProcess(int target)
        {
            if (target >= 0 && target <= 100)
                targetProcess = target;
        }
    }
}

