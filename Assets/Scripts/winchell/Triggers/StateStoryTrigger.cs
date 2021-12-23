using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    public class StateStoryTrigger : StoryTrigger
    {
        [SerializeField] protected Message[] Messages2;

        protected override string getMessage()
        {
            if (Messages2[messageIndex].messageEnd())
            {
                messageIncrement();
            }
            return (Messages2[messageIndex]).message;
        }

        protected override bool messageEnd()
        {
            return messageIndex >= Messages2.Length - 1 &&  Messages2[Messages2.Length-1].messageEnd();
        }

        protected override void messageIncrement()
        {
            base.messageIncrement();
            nextMessageStart();
        }

        protected override void messageStart()
        {
            base.messageStart();
            nextMessageStart();
            //displayMessage(message);
        }

        protected void nextMessageStart()
        {
            if (messageIndex < Messages2.Length) Messages2[messageIndex].messageStart();
        }
    }
}

