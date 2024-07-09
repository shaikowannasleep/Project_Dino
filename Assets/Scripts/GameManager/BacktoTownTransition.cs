using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoTownTransition : MonoBehaviour
{

    public string loadScene;
    public Vector2 playerLocation;
    public objectVector playerTemp;



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !GameManager.instance.dialogActive)
        {
            playerTemp.initial = playerLocation;
            SceneManager.LoadScene(loadScene);
            PlayerController.instance.GetComponent<Transform>().position = playerLocation;
        }
    }
}
