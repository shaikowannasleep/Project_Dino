using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string transitionName;
    [SerializeField]
    private Transform spawnPosition;

    private string previousTransitionName;
    void Start()
    {

        /*  previousTransitionName = PlayerController.instance.areaTransitionName;
        //  Debug.Log("Transition Name: " + transitionName);
         // Debug.Log("Previous Transition Name: " + previousTransitionName);

          // if (transitionName == PlayerController.instance.areaTransitionName)
          if (transitionName == previousTransitionName)
          {
              if (spawnPosition != null)
              {
                  PlayerController.instance.transform.position = spawnPosition.position;

                  Debug.Log("Setting player position to spawn position: " + spawnPosition.position);
              }
              else
              {
                  PlayerController.instance.transform.position = transform.position;
                  Debug.Log("Setting player position to AreaEntrance position: " + transform.position);
              }
          }

          GameManager.instance.fadingBetweenAreas = false;
           UIFade.instance.FadeFromBlack(); */
        if (transitionName == PlayerController.instance.areaTransitionName)
        {
            PlayerController.instance.transform.position = transform.position;
        }
        GameManager.instance.fadingBetweenAreas = false;
        UIFade.instance.FadeFromBlack();
       

    }





}
