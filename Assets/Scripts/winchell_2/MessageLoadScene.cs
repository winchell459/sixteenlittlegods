using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell_2
{
    [CreateAssetMenu(fileName = "MessageLoadScene", menuName = "ScriptableObjects/MessageLoadScene_winchell_2")]
    public class MessageLoadScene : MessageQuest
    {
        [SerializeField] private string sceneName;
        override public string GetMessage()
        {
            if (_active || checkOnStates(triggerOnStates))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            }
            return _message;
        }
    }
}
