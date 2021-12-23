using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    [System.Serializable]
    public class Quest 
    {
        virtual public string questName { get { return _questName; } }
        virtual public string questID { get { return _questID; } }
        virtual public string text { get { return getText(); } }
        virtual public bool completed { get { return _completed; } }

        [SerializeField] private string _questName;
        [SerializeField] private string _questID;
        [SerializeField] private bool _completed;
        public void SetQuestName(string questName)
        {
            _questName = questName;
        }

        public void SetQuestID(string questID)
        {
            _questID = questID;
        }
        public void SetCompleted()
        {
            setCompleted();
        }

        virtual protected void setCompleted()
        {
            _completed = true;
        }
        
        virtual protected string getText()
        {
            return questName;
        }
    }
}
