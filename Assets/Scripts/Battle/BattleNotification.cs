﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleNotification : MonoBehaviour {

    public float awakeTime;
    private float awakeCounter;
    public Text theText;

	// Update is called once per frame
	void Update () {
		if(awakeCounter > 0)
        {
            awakeCounter -= Time.deltaTime;
            if(awakeCounter <= 0)
            {
                gameObject.SetActive(false);
            }
        }
	}

    public void Activate()
    {
        gameObject.SetActive(true);
        awakeCounter = awakeTime;
    }
}
