using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    [CreateAssetMenu(fileName = "MessageQuest", menuName = "ScriptableObject/Message/MessageQuest")]
    public abstract class MessageQuest : MessageText
    {
        [SerializeField] private QuestScriptableObject questScriptable;
        [SerializeField] protected Quest quest { get { return questScriptable.quest; } }
        [SerializeField] protected QuestKeys questKeys;
        protected override string getMessage()
        {

            return quest.text;
        }
        

        protected string translateKeys(string message)
        {
            foreach(QuestKey key in questKeys.mapObjects)
            {
                while (message.Contains(key.key))
                {
                    message = message.Replace(key.key, key.obj);
                }
            }
            return message;
        }

    }

    [System.Serializable]
    public class QuestKeys
    {
        public List<QuestKey> mapObjects;
        public string this[string key]
        {
            get => FindObject(key);
            set => SetObject(key, value);
        }
        string FindObject(string key)
        {
            string obj = default;
            foreach (QuestKey mapObject in mapObjects)
            {
                if (key == mapObject.key) obj = mapObject.obj;
            }
            return obj;
        }

        void SetObject(string key, string value)
        {
            
            foreach (QuestKey mapObject in mapObjects)
            {
                if (key == mapObject.key)
                {
                    //mapObjects.Add(new QuestKey(key, value));
                    mapObject.obj = value;
                }
            }
            
        }
    }

    [System.Serializable]
    public class QuestKey
    {
        public string key;
        public string obj;

        public QuestKey(string key, string obj)
        {
            this.key = key;
            this.obj = obj;
        }
    }
}
