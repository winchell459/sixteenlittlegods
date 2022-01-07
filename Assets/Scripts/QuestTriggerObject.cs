using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTriggerObject : MonoBehaviour
{
    //[SerializeField] protected Quest quest;
    //[SerializeField] protected Quest.QuestState[] activeOnStates;

    [SerializeField] private Quest triggerQuest;
    [SerializeField] private Quest.QuestState triggerState;
    [SerializeField] private Quest.QuestState[] triggerOnStates;

    [SerializeField] private bool destroyOnTriggered;

    // Start is called before the first frame update
    void Start()
    {
        destroyCheck();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if(checkOnStates(triggerOnStates))
            {
                triggerQuest.State = triggerState;
                destroyCheck();
            }
        }
    }

    private void destroyCheck()
    {
        if(destroyOnTriggered && triggerQuest.State >= triggerState)
        {
            Destroy(gameObject);
        }
    }

    protected bool checkOnStates(Quest.QuestState[] questStates)
    {
        foreach (Quest.QuestState questState in questStates)
        {
            if (triggerQuest.State == questState) return true;
        }
        return false;
    }
}
