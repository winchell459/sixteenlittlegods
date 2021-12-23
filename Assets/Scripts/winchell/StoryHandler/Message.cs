using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    public abstract class Message : ScriptableObject
    {

        public string message { get { return getMessage(); } }
        protected abstract string getMessage();
        public abstract void messageIncrement();
        public abstract bool messageEnd();
        public abstract void messageStart();
    }

    
}