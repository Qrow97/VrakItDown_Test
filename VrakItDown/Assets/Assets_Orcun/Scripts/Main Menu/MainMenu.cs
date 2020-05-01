using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //deleting all the keys when new game starts
        PlayerPrefs.DeleteAll();
        //SceneManager.LoadScene("Level1"); for spesificly to go scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //going next one in the index
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    public void LoadGame()
    {
        //SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));

        PlayerData data = SaveSystem.LoadPlayer();

        int level = data.level;

        SceneManager.LoadScene(level);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }


    
}
