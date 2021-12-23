using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    [CreateAssetMenu(fileName = "Problem", menuName = "ScriptableObject/Quest/Problem")]
    public class QuestScriptableObject : ScriptableObject
    {
        public Problem quest;
    }
}
