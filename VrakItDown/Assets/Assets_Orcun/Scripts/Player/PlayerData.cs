using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData 
{
    public int health;
    public int level;
    public float[] position;

    public PlayerData(Player player)
    {
        

        level = SceneManager.GetActiveScene().buildIndex;
        
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
		health = player.currentHealth;
    }
}
