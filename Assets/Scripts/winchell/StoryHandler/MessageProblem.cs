using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    [CreateAssetMenu(fileName = "MessageProblem", menuName = "ScriptableObject/Message/MessageProblem")]
    public class MessageProblem : MessageQuest
    {
        protected override string getMessage()
        {
            string message = translateKeys( text[messageIndex]);
            messageIncrement();
            return message;
        }
        

        public override void messageStart()
        {
            Problem problem = (Problem)quest;
            questKeys["<operand1>"] = problem.operand1.ToString();
            questKeys["<operand2>"] = problem.operand2.ToString();
            questKeys["<oper>"] = problem.oper.ToString();
            base.messageStart();
        }
    }
}
