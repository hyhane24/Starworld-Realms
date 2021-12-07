using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    // Start is called before the first frame update

    //private EnclosingSphereContact esc;

    public void StartGame() {

            SceneManager.LoadScene("tutorial"); 
            Time.timeScale = 1f;
    }

    

} 
