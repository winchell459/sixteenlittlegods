using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    public class StoryTrigger : DisplayHandlerTrigger
    {
        [SerializeField] private string[] Messages;
        private bool messageComplete = true;
        protected int messageIndex = 0;
        protected new string message
        {
            get
            {
                return getMessage();
            }
        }
        virtual protected string getMessage()
        {
            
            string storyMessage = Messages.Length > 0? Messages[messageIndex]: defaultMessage;
            if (storyMessage == "Default Message") return defaultMessage;
            else return storyMessage;
        }
        virtual protected bool messageEnd()
        {
            return messageIndex >= Messages.Length;
        }
        virtual protected void messageIncrement()
        {
            messageIndex += 1;
        }
        virtual protected void messageStart()
        {

            messageIndex = 0;
            
        }
        
        protected override void handlePlayerTagCollisionEnter(Collision2D collision)
        {
            if (messageComplete)
            {
                Debug.Log("StoryTrigger " + gameObject.name);

                
                messaging = true;
                messageComplete = false;
                messageStart();
                displayMessage(message);
            }
            
        }

        private void Update()
        {
            if(!messageComplete)
            {
                if (Input.anyKeyDown)
                {
                    messageIncrement();
                    if(!messageEnd())
                    {
                        displayMessage(message);
                    }
                    else
                    {
                        messaging = false;
                        displayClose();
                        messageComplete = true;
                    }
                }
            }
        }
    }
}

