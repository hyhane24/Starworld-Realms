using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class EnclosingSphereContact : MonoBehaviour
{
    private bool isGrounded = false;

    public int maxHealth = 100;
    public int maxLives = 3;
    public int healthDecrementStep = 30;

    public int health;
    public int lives;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI youWinText;
    public TextMeshProUGUI bulletsText;
    public Button restartButton;
    
    private GameObject alien;
    private bool attackEntered = false;
    private bool attackExit = true;
    private EnclosingSphereContact enclosingSphereContact;
    private GroundDetection groundDetection;
    private GameObject baseDetect;
    private FiringScript firingScript;

    private bool restart = false;
    private int beforeLife = 0;
    private int beforeHealth = 0;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        alien = this.transform.parent.parent.gameObject;

        health = StaticDataHolder.health;
        lives = StaticDataHolder.maxlives;

        restart = false;

        if (healthText == null)
            Debug.Log("Health text not found");

        if (livesText == null)
            Debug.Log("Lives text not found");

        if (bulletsText == null)
            Debug.Log("Bullets text not found");

        if (gameOverText == null) 
            Debug.Log("GameOver text not found");
        else
            gameOverText.enabled = false;
        if(restartButton!=null)
            restartButton.gameObject.SetActive(false);

        enclosingSphereContact = this.GetComponent<EnclosingSphereContact>();
        if (enclosingSphereContact == null)
            Debug.Log("Enclosing sphere contact script not found");

        groundDetection = this.gameObject.transform.GetChild(1).GetComponent<GroundDetection>();

        if (groundDetection == null)
            Debug.Log("Ground contact not found");

        if (youWinText == null)
            Debug.Log("YouWin text not found");
        else
            youWinText.enabled = false;

        firingScript = this.gameObject.transform.parent.GetChild(1).GetComponent<FiringScript>();
        if (firingScript == null)
            Debug.Log("Firing script not found");
        firingScript.SetNumBullets(StaticDataHolder.bullets);

        Debug.Log(maxLives);
        Debug.Log(restart);

        SetHealthText();
        SetLivesText();
        SetBulletsText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "EnemyProjectile" && !(attackEntered && !attackExit))
        {
            Debug.Log("Hit by enemy t");
            DecrementHealth();
            audioSource.Play();
            Debug.Log("Audio Played");
        } else if (other.transform.gameObject.tag == "Key")
        {
            SceneManager.LoadScene("End"); 
            Time.timeScale = 1f;
            Debug.Log("You win!");
        } else if (other.transform.gameObject.tag == "bulletRefill")
        {
            firingScript.ResetNumBullets();
            other.transform.gameObject.SetActive(false);
            SetBulletsText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.tag == "EnemyProjectile" && attackEntered)
        {
            Debug.Log("Exit hit by enemy t");
            attackExit = true;
        }
    }

    public bool GetIsGrounded()
    {
        return groundDetection.GetIsGrounded();
    }

    public void ForceSetIsGrounded(bool isGrounded)
    {
        groundDetection.ForceSetIsGrounded(isGrounded);
    }

    void SetLivesText()
    {
        if (livesText != null)
        {
            if (restart)
            {
                livesText.text = "Lives: " + beforeLife.ToString();
            }
            else
            {
                livesText.text = "Lives: " + lives.ToString();
            }
        }
    }

    public void SetHealthText()
    {
        if (healthText != null)
        {
            if (restart)
            {
                healthText.text = "Health: " + beforeHealth.ToString();
            }
            else
            {
                healthText.text = "Health: " + health.ToString();
            }
        }
    }

    public void SetBulletsText()
    {
        if(bulletsText != null)
            bulletsText.text = "Bullets: " + firingScript.GetNumBullets();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.collider.gameObject.name);
        if (collision.collider.gameObject.tag == "EnemyProjectile" && !(attackEntered && !attackExit))
        {
            Debug.Log("Hit by enemy");
            DecrementHealth();
            audioSource.Play();
            Debug.Log("Audio Played");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.collider.gameObject.tag == "EnemyProjectile" && attackEntered)
        {
            Debug.Log("Exit hit by enemy");
            attackExit = true;
        }
    }

    void DecrementHealth()
    {
        if (healthText != null)
        {
            if (health - healthDecrementStep <= 0)
            {
                if (lives - 1 < 0)
                {
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 30f, player.transform.position.z);
                    GameOver();
                }
                else
                {
                    lives = lives - 1;
                    StaticDataHolder.maxlives -= 1;
                    Restart();
                    // health = maxHealth;
                }
                firingScript.ResetNumBullets();
                SetBulletsText();
                SetHealthText();
                SetLivesText();
            }
            else
            {
                health = health - healthDecrementStep;
                StaticDataHolder.health = health;
                SetHealthText();
            }
        }
    }

    public void GameOver(string text="GAME OVER")
    {
        //gameOverText.enabled = true;
        //gameOverText.text = text;
        Debug.Log("Gameover maxlives is " + maxLives);
        StaticDataHolder.maxlives = StaticDataHolder.maximumLives;
        StaticDataHolder.health = StaticDataHolder.maxHealth;
        firingScript.ResetNumBullets();
        alien.SetActive(false);
        //restartButton.gameObject.SetActive(true);
        SceneManager.LoadScene("GameOver"); 
        Time.timeScale = 1f;
    }

    // game over restart
    // pause menu restart is via Game Starter 

    public void Restart() {
        StaticDataHolder.health = maxHealth;
        lives = StaticDataHolder.maxlives;
        firingScript.ResetNumBullets();
        if (lives < 0)
        {
            lives = maxLives;
            health = maxHealth;
            SceneManager.LoadScene("lvl1");
            Time.timeScale = 1f;
        } else {
            restart = true;
            beforeLife = lives;
            beforeHealth = health;
            int curr = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(curr, LoadSceneMode.Single);
            Time.timeScale = 1f;
        }
    }

    public void RestartButton()
    {
        Debug.Log("maxlives is " + maxLives);
        StaticDataHolder.maxlives = StaticDataHolder.maximumLives;
        StaticDataHolder.health = StaticDataHolder.maxHealth;
        firingScript.ResetNumBullets();
        SceneManager.LoadScene("lvl1");
        Time.timeScale = 1f;
    }
}
