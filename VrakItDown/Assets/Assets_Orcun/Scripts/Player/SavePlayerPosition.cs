using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePlayerPosition : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        //if saved
        if(PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {
            float pX = player.transform.position.x;
            float pY = player.transform.position.y;

            pX = PlayerPrefs.GetFloat("p_x");
            pY = PlayerPrefs.GetFloat("p_y");
            player.transform.position = new Vector2(pX, pY);
            PlayerPrefs.SetInt("TimeToLoad", 0);
         
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
        }
        
    }
    public void PlayerPositionSave()
    {
        PlayerPrefs.SetFloat("p_x", player.transform.position.x);
        PlayerPrefs.SetFloat("p_y", player.transform.position.y);
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
    }
    public void PlayerPositionLoad()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }
}
