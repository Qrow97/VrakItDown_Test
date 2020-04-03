using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitchCamera : MonoBehaviour
{

    public GameObject currentFrame;
    public GameObject nextFrame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(currentFrame.active == true)
        {
            currentFrame.SetActive(false);
            nextFrame.SetActive(true);
        }else if(currentFrame.active == false)
        {
            currentFrame.SetActive(true);
            nextFrame.SetActive(false);
        }
    }

}
