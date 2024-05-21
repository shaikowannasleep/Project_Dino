using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
  //  public static UIFade instance;
   

    private static UIFade instance;
    public static UIFade GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<UIFade>();
            if (instance == null)
            {
                GameObject obj = new GameObject("UIFade");
                instance = obj.AddComponent<UIFade>();
            }
        }
        return instance;
    }

    public Image fadeScreen;
    public float fadeSpeed;

     [SerializeField]
    private bool shouldFadeToBlack;
    [SerializeField]
    private bool shouldFadeFromBlack;

    void Start()
    {
       // instance = this;
        // this may get error then 

    }

    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            // If the alpha value has reached 1, turn off the shouldFadeToBlack flag
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }
        // If the shouldFadeFromBlack flag is set, gradually decrease the alpha value of the screen to 0
        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            // If the alpha value has reached 0, turn off the shouldFadeFromBlack flag
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }
}
