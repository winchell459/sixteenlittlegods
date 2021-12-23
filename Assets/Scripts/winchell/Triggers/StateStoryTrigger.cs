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
            return messageIndex < Messages2.Length;
        }
    }
}

