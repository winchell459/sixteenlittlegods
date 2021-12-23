using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    [System.Serializable]
    public class Problem : Quest
    {
        public int operand1, operand2;
        public Operators oper;
            
        public enum Operators
        {
           add,
           sub,
           mult,
           div
        }
    }
}
