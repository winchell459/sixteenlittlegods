using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell_2
{
    [CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest_winchell_2")]
    public class Quest : ScriptableObject
    {
        public string Name;
        public string ID;
        [TextArea] string Description;
        public QuestState State;

        public enum QuestState
        {
            inactive,
            triggered,
            start,
            in_progress,
            completed,
            done
        }
    }
}