using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    [CreateAssetMenu(fileName = "MessageQuest", menuName = "ScriptableObject/Message/MessageQuest")]
    public abstract class MessageQuest : Message
    {
        [SerializeField] Quest quest;
        protected override string getMessage()
        {
            return quest.text;
        }
        public override bool messageEnd()
        {
            throw new System.NotImplementedException();
        }

        public override void messageStart()
        {
            throw new System.NotImplementedException();
        }
        public override void messageIncrement()
        {

        }
    }
}
