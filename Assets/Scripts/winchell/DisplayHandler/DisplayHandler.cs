using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    public class DisplayHandler : MonoBehaviour
    {
        [SerializeField] DisplayTextHandler[] display;
        public bool DisplayMessage(string message)
        {
            display[0].DisplayMessage(message);
            return true;
        }

        public bool CloseDisplay()
        {
            display[0].CloseDisplay();
            return true;
        }
    }
}
