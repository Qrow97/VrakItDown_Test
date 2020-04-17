using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitchCamera : MonoBehaviour
{

    public GameObject activeFrame;
    public GameObject[] deactiveFrames;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            activeFrame.SetActive(true);
            for(int i = 0; i < deactiveFrames.Length; i++)
            {
                deactiveFrames[i].SetActive(false);
            }
        }
        
    }

}
