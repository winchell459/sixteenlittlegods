using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    public class StoryTrigger : DisplayHandlerTrigger
    {
        [SerializeField] string[] message;
        private int messageIndex = 0;
        
        private bool messageComplete = true;
        protected override void handlePlayerTagCollisionEnter(Collision2D collision)
        {
            if (messageComplete)
            {
                messageIndex = 0;
                messaging = true;
                messageComplete = false;
                displayMessage(message[messageIndex]);
                
            }
            
        }

        private void Update()
        {
            if(!messageComplete)
            {
                if (Input.anyKeyDown)
                {
                    messageIndex += 1;
                    if(messageIndex < message.Length)
                    {
                        displayMessage(message[messageIndex]);
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

