using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    public class SceneLoadTrigger : CollisionTrigger
    {
        [SerializeField] private string sceneName;
        protected override void handlePlayerTagCollisionEnter(Collision2D collision)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

        }

        protected override void handlePlayerTagCollisionExit(Collision2D collision)
        {
            throw new System.NotImplementedException();
        }
    }
}

