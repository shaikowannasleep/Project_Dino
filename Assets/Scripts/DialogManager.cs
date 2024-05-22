using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;

    public int currentLine;
    bool justStarted;

    public static DialogManager instance;


    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    void Update()
    { // Check if the dialogue box is active
        if (dialogBox.activeInHierarchy)
        {
            // Check if the player has input to continue the dialogue
            if (ContinueDialogInput())
            {
                if (!justStarted)
                {
                    currentLine++;

                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
                        // allow player move outside the dialog
                        PlayerController.instance.canMove = true;
                    }
                    else
                    {
                        CheckIfName();
                        dialogText.text = dialogLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;

                }
            }
        }
    }

   
    internal void ShowDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;
        currentLine = 0;
        CheckIfName();
        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);
        justStarted = true;
        nameBox.SetActive(isPerson);
        PlayerController.instance.canMove = false;
    }


    public void CheckIfName()
    {
        if (dialogLines[currentLine].StartsWith("name-"))
        {
            nameText.text = dialogLines[currentLine].Substring(5);
            nameBox.SetActive(true);
            currentLine++;
        }
       
    }

    // Check if the player has input to continue the dialogue
    bool ContinueDialogInput()
    {
        return Input.GetKeyDown(KeyCode.F) || (Input.GetButtonUp("Fire1"));
    }

}
