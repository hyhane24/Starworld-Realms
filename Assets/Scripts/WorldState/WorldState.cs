using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldState : MonoBehaviour
{
    public Button restartButton;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(player.transform.position.y);
        if (player.transform.position.y < 26.5f)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+30f, player.transform.position.z);
            RestartGame();
        }
    }

    void RestartGame()
    {
        Debug.Log("Restarting");
        // Application.LoadLevel(Application.loadedLevel);
        GameObject alien = GameObject.FindGameObjectWithTag("EnclosingSphere");
        StaticDataHolder.maxlives -= 1;
        if (StaticDataHolder.maxlives < 0)
        {
            alien.GetComponent<EnclosingSphereContact>().GameOver();
        }
        else
        {
            alien.GetComponent<EnclosingSphereContact>().Restart();
        }
    }
}
