using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    [CreateAssetMenu(fileName = "MessageText", menuName = "ScriptableObject/Message/MessageText")]
    public class MessageText : Message
    {
        [SerializeField] string text;
        protected override string getMessage()
        {
            return text;
        }
    }
}