using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EssentialsLoader : MonoBehaviour
{
    //create a script that will be able to pull these things into our scene as we go.
    // obviously need to put in the UI canvas ( UIScreen) created.
    public GameObject UIScreen; 
    public GameObject player;
    public GameObject gameManager;
    public GameObject audioMan;
    public Vector2 defaultspawn;
    // Start is called before the first frame update
    void Start()
    {
      

        if (PlayerController.instance == null)
        {
            //Why clone? Cos there must be onlu one player exist at the time being ,
            //if there was another -> in playerControll Destroy(gameObject) called so i think i call clone version of any thing that be called be ok;
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            clone.GetComponent<Transform>().position = defaultspawn;
            PlayerController.instance = clone;
            
        }

        if (UIFade.instance == null)
        {
            UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>();
            
        }

        if (GameManager.instance == null)
        {
            GameManager.instance = Instantiate(gameManager).GetComponent<GameManager>();
        }


        if (AudioManager.instance == null)
        {
            AudioManager.instance = Instantiate(audioMan).GetComponent<AudioManager>();
        }

    }

}
