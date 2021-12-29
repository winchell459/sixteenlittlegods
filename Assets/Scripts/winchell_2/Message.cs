using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell_2
{
    [CreateAssetMenu(fileName = "Message", menuName = "ScriptableObjects/Message_winchell_2")]
    public class Message : ScriptableObject
    {

        public bool active { get { return GetActive(); } }
        public string message { get { return GetMessage(); } }

        [SerializeField] protected bool _active;
        [SerializeField] protected string _message;

        virtual public bool GetActive()
        {
            return _active;
        }

        virtual public string GetMessage()
        {
            return _message;
        }
        
    }
}

