using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace winchell
{
    public class DisplayTextHandler : MonoBehaviour
    {
        [SerializeField] GameObject displayWindow;
        [SerializeField] Text displayText;
        // Start is called before the first frame update
        void Start()
        {
            closeDisplayWindow();
        }

        public void DisplayMessage(string message)
        {
            setDisplayText(message);
            openDisplayWindow();
        }

        public void CloseDisplay()
        {
            closeDisplayWindow();
        }

        private void closeDisplayWindow()
        {
            displayWindow.SetActive(false);
        }
        private void openDisplayWindow()
        {
            displayWindow.SetActive(true);
        }

        private void setDisplayWindowVisiblity(bool isVisible)
        {
            displayWindow.SetActive(isVisible);
        }

        private void setDisplayText(string message)
        {
            displayText.text = message;
        }
    }
}