using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    public class CollisionTrigger : MonoBehaviour
    {
        [SerializeField] private string defaultMessage = "Defualt Message";

        private string message
        {
            get
            {
                string storyMessage = FindObjectOfType<StoryHandler>().GetMessage(this);
                if (storyMessage == "Default Message") return defaultMessage;
                else return storyMessage;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            displayMessage(message);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) handlePlayerTagCollision(collision);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) handlePlayerTagCollisionExit(collision);
        }

        private void handlePlayerTagCollision(Collision2D collision)
        {
            displayMessage(message);
        }
        private void displayMessage(string message)
        {
            Debug.Log(message);
            FindObjectOfType<DisplayHandler>().DisplayMessage(message);
        }
        private void displayClose()
        {
            FindObjectOfType<DisplayHandler>().CloseDisplay();
        }

        private void handlePlayerTagCollisionExit(Collision2D collision)
        {
            displayClose();
        }
    }
}