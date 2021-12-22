using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    public class DisplayHandlerTrigger : CollisionTrigger
    {
        [SerializeField] private string defaultMessage = "Defualt Message";

        protected static bool messaging = false;
        public static bool Messaging { get { return messaging; } }

        private string message
        {
            get
            {
                string storyMessage = FindObjectOfType<StoryHandler>().GetMessage(this);
                if (storyMessage == "Default Message") return defaultMessage;
                else return storyMessage;
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }


        protected override void handlePlayerTagCollisionEnter(Collision2D collision)
        {
            displayMessage(message);
        }
        protected override void handlePlayerTagCollisionExit(Collision2D collision)
        {
            displayClose();
        }

        protected void displayMessage(string message)
        {
            Debug.Log(message);
            FindObjectOfType<DisplayHandler>().DisplayMessage(message);
        }
        protected void displayClose()
        {
            FindObjectOfType<DisplayHandler>().CloseDisplay();
        }

        
    }
}

