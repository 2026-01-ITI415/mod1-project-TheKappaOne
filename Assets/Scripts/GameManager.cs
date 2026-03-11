using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int health = 5;
    public int ammo = 0;
    public int score = 0;

    public Text healthText;
    public Text ammoText;
    public Text scoreText;
    public GameObject gameOverText;

    private bool gameOver = false;

    void Start()
    {
        UpdateUI();

        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }
    }

    void Update()
    {
        if (health <= 0 && !gameOver)
        {
            GameOver();
        }
    }

    public void UpdateUI()
    {
        if (healthText != null)
            healthText.text = "Health: " + health;

        if (ammoText != null)
            ammoText.text = "Ammo: " + ammo;

        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
    void GameOver()
    {
        gameOver = true;

        if (gameOverText != null)
            gameOverText.SetActive(true);

        Time.timeScale = 0f;   // freezes the game

        Debug.Log("Game Over");
    }
}