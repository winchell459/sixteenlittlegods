using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    public class StoryHandler : MonoBehaviour
    {
        [SerializeField] private List<CollisionTrigger> collisionTriggers;
        [SerializeField] private string[] Messages = { "Ouch!", "Stop that!", "I'm serious!", "That's it!" };

        public string GetMessage(CollisionTrigger trigger)
        {
            if (collisionTriggers.Contains(trigger)) return randomMessage();
            else return "Default Message";
        }

        private string randomMessage()
        {
            int randInt = Random.Range(0, Messages.Length);
            return Messages[randInt];
        }
    }
}

