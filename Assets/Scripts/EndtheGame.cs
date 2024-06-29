using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndtheGame : MonoBehaviour
{

    public string gameOverScene;

 

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !GameManager.instance.dialogActive)
        {
            StartCoroutine(GameOverCo());
        }
    }


    public IEnumerator GameOverCo()
    {
        UIFade.instance.FadeToBlack();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(gameOverScene);
    }
}
