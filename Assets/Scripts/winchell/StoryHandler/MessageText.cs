using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    [CreateAssetMenu(fileName = "MessageText", menuName = "ScriptableObject/Message/MessageText")]
    public class MessageText : Message
    {
        [SerializeField] protected string[] text;
        protected int messageIndex = 0;
        protected override string getMessage()
        {
            string message = text[messageIndex];
            messageIncrement();
            return message;
        }

        public override bool messageEnd()
        {
            return messageIndex >= text.Length;
        }

        public override void messageIncrement()
        {
            messageIndex += 1;
        }

        public override void messageStart()
        {
            messageIndex = 0 ;
        }
    }
}