using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    public abstract class CollisionTrigger : MonoBehaviour
    {
        

        private void Start()
        {
            
        }
       

        //public void OnTriggerEnter2D(Collider2D collision)
        //{
        //    displayMessage(message);
        //}

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) handlePlayerTagCollisionEnter(collision);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) handlePlayerTagCollisionExit(collision);
        }

        protected abstract void handlePlayerTagCollisionEnter(Collision2D collision);
        protected abstract void handlePlayerTagCollisionExit(Collision2D collision);
    }
}