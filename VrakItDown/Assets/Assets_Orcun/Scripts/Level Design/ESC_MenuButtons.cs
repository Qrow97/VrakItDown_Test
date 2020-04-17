using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ESC_MenuButtons : MonoBehaviour
{
    SavePlayerPosition playerPositionData;
    private void Start()
    {
        playerPositionData = FindObjectOfType<SavePlayerPosition>();

    }
    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SaveButton()
    {
        playerPositionData.PlayerPositionSave();
    }

}
