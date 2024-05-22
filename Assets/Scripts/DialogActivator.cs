using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
///what i want to do, as i said, is when a player walks into the trigger zone, i're going to say,okay, the player is here.
//when the player is in this area, check and see if they press the button.
//to do that, i need to have a bool that i will use to say i'll call this can activate.
//this will basically mean the player is in the correct area.
/// </summary>
/// 


public class DialogActivator : MonoBehaviour
{
    public string[] lines;

    bool canActivate;

    public bool isPerson = true;

    void Update()
    {
        if (canActivate && Input.GetButtonDown("Fire1") && !DialogManager.instance.dialogBox.activeInHierarchy)
        {
            DialogManager.instance.ShowDialog(lines, isPerson);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = true;
          //  Debug.Log("canActivate");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = false;
        }
    }
}
