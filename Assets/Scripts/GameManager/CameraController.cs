using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{

    //[SerializeField]
    public Transform target;

    public Tilemap theMap;
       
    Vector3 bottomLeftLimit;
    Vector3 topRightLimit;

    float halfHeight;
    float halfWidth;


    public int musicToPlay;
    private bool musicStarted;
    void Start()
    {
       // target = playerController.transform;
        target = PlayerController.instance.transform;
       
        if (theMap != null)
        {
            theMap.CompressBounds();

            halfHeight = Camera.main.orthographicSize;
            halfWidth = halfHeight * Camera.main.aspect;

            bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
            topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f); ;


            PlayerController.instance.SetBounds(theMap.localBounds.min, theMap.localBounds.max);
        }
        else
        {
            Debug.LogWarning("theMap is not assigned in the CameraController script.");
        }
    }
    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

            // keep the camera inside the bounds
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
                Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);

            if (!musicStarted)
            {
                musicStarted = true;
                AudioManager.instance.PlayBGM(musicToPlay);
            }
        }
    }
}