using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    //create a script that will be able to pull these things into our scene as we go.
    // obviously need to put in the UI canvas ( UIScreen) created.
    public GameObject UIScreen; 
    public GameObject player;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        if (UIFade.instance == null)
        {
            UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>();
        }

        if (PlayerController.instance == null)
        {
            //Why clone? Cos there must be onlu one player exist at the time being ,
            //if there was another -> in playerControll Destroy(gameObject) called so i think i call clone version of any thing that be called be ok;
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }

        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }










    }

}
