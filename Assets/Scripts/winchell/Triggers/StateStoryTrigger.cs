using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    public class StateStoryTrigger : StoryTrigger
    {
        [SerializeField] private Message[] Messages2;

        protected override string getMessage()
        {
            return Messages2[messageIndex].message;
        }

        protected override bool messageEnd()
        {
            return messageIndex < Messages2.Length && Messages2[Messages2.Length-1].messageEnd();
        }

        protected override void messageIncrement()
        {
            base.messageIncrement();
        }

        protected override void messageStart()
        {
            Messages2[messageIndex].messageStart();
            //displayMessage(message);
        }
    }
}

