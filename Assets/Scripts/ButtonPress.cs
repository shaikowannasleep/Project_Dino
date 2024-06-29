using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject Enemy;

    private static bool redButtonPressed, blueButtonPressed;

    private static bool enemiesNotYetSpawned;

    void Start()
    {
        redButtonPressed = false;
        blueButtonPressed = false;
        enemiesNotYetSpawned = true;
    }

    void Update()
    {
        if (enemiesNotYetSpawned && blueButtonPressed && redButtonPressed)
        {
            Instantiate(Enemy, new Vector3(-9, 1, 0), Quaternion.identity);
            enemiesNotYetSpawned = false;
          
        }


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (gameObject.CompareTag("redbtn"))
        {
            if (other.gameObject.CompareTag("redBox"))
            {
                redButtonPressed = true;


            }
        }
        else if (gameObject.CompareTag("bluebtn"))
        {
            if (other.gameObject.CompareTag("blueBox"))
            {
                blueButtonPressed = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (gameObject.CompareTag("bluebtn"))
        {
            if (other.gameObject.CompareTag("blueBox"))
            {
                blueButtonPressed = false;
               

            }
        }
        else if (gameObject.CompareTag("redbtn"))
        {
            if (other.gameObject.CompareTag("redBox"))
            {
                redButtonPressed = false;
            }

        }
    }


}
