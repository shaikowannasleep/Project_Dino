using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CharacterStat[] playerStats;

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}