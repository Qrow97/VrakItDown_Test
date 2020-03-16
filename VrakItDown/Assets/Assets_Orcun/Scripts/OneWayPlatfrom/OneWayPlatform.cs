using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    // One way Collision platfrom script, to use it select platfrom, add Box Collider(check the Used By Effector box), Platfrom Effector 2D, and add this script!!

    private PlatformEffector2D effector;
    public float waitTime;
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.5f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if(waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                effector.rotationalOffset = 0;
            }
        }
    }
}
