using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingAI : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float groundDetectionLaser;      // Give it a value otherwise it will be infinity!!

    private bool movingRight = true;

    public Transform groundDetection;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, groundDetectionLaser);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
