using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    public class StoryTrigger : CollisionTrigger
    {
        protected override void handlePlayerTagCollision(Collision2D collision)
        {
            displayMessage("testing");
        }
    }
}

