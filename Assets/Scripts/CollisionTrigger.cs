using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    [SerializeField] private string defaultMessage = "Default Message";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) displayMessage(defaultMessage);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) displayClose();
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
