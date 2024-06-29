using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjectDeactivate : MonoBehaviour
{
    public GameObject objectToDeactivate;

    public string questToCheck;

    public bool deactiveIfComplete;

    private bool initialCheckDone;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!initialCheckDone)
        {
            initialCheckDone = true;

            CheckCompletion();
        }
    }

    public void CheckCompletion()
    {
        if (QuestManager.instance.CheckIfComplete(questToCheck))
        {
            objectToDeactivate.SetActive(!deactiveIfComplete);
        }
    }
}
