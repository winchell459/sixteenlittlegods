using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    [SerializeField] private string defaultMessage = "Default Message";

    private static bool messaging = false;
    public static bool Messaging { get { return messaging; } }

    [SerializeField] private string[] message;
    private int messageIndex = 0;
    private bool messageComplete = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            handlePlayerTagCollisionEnter(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) displayClose();
    }

    virtual protected void handlePlayerTagCollisionEnter(Collision2D collision)
    {
        if (message.Length > 0 && messageComplete)
        {
            messageIndex = 0;
            messaging = true;
            messageComplete = false;
            displayMessage(message[messageIndex]);
        }
        else
        {
            exitMessage();
        }
    }

    virtual protected void exitMessage()
    {
        messaging = false;
        displayClose();
        messageComplete = true;
    }
    private void Update()
    {
        if (!messageComplete)
        {
            if (Input.anyKeyDown)
            {
                messageIndex += 1;
                if(messageIndex < message.Length)
                {
                    displayMessage(message[messageIndex]);
                }
                else
                {
                    exitMessage();
                }
            }
        }
    }




    private void displayMessage(string message)
    {
        FindObjectOfType<DisplayHandler>().DisplayMessage(message);
    }

    private void displayClose()
    {
        FindObjectOfType<DisplayHandler>().CloseDisplay();
    }
}
