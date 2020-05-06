using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitchGate : MonoBehaviour
{

    public int whichLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            switch (whichLevel)
            {
                case 1:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    break;
                case 2:
                    SceneManager.LoadScene("MainMenu");
                    break;
            }
        }
    }

    
}
