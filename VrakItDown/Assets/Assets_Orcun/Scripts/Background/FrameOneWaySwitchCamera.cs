using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameOneWaySwitchCamera : MonoBehaviour
{
    public GameObject currentFrame;
    public GameObject nextFrame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentFrame.active == true)
        {
            currentFrame.SetActive(false);
            nextFrame.SetActive(true);
           
           // transform.GetComponent<BoxCollider2D>().isTrigger = false;
        }
      
    }

   
}
