using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell_2
{
    [CreateAssetMenu(fileName = "MessageQuest", menuName = "ScriptableObjects/MessageQuest_winchell_2")]
    public class MessageQuest : Message
    {
        [SerializeField] private Quest quest;

        [SerializeField] protected Quest.QuestState[] activeOnStates;
        [SerializeField] protected Quest.QuestState[] triggerOnStates;

        [SerializeField] private Quest triggerQuest;
        [SerializeField] private Quest.QuestState triggerState;


        override public bool GetActive()
        {
            if (_active) return _active;
            else
            {
                return checkOnStates(activeOnStates);
            }
            
        }

        override public string GetMessage()
        {
            if (checkOnStates(triggerOnStates))
            {
                triggerQuest.State = triggerState;
            }
            return _message;
        }

        protected bool checkOnStates(Quest.QuestState[] questStates)
        {
            foreach (Quest.QuestState questState in questStates)
            {
                if (quest.State == questState) return true;
            }
            return false;
        }
    }
}
