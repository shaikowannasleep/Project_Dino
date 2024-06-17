using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string transitionName;
    [SerializeField]
    private Transform spawnPosition;
    void Start()
    {
        if (transitionName == PlayerController.instance.areaTransitionName)
        {
            if (spawnPosition != null)
            {
                PlayerController.instance.transform.position = spawnPosition.position;
            }
            else
            {
                PlayerController.instance.transform.position = transform.position;
            }
        }
        UIFade.instance.FadeFromBlack();
        GameManager.instance.fadingBetweenAreas = false;

    }
}
