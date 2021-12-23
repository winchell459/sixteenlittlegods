using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    [CreateAssetMenu(fileName = "MessageQuest", menuName = "ScriptableObject/Message/MessageQuest")]
    public abstract class MessageTextQuest : Message
    {
        [SerializeField] Quest quest;
        protected override string getMessage()
        {
            return quest.text;
        }
    }
}
