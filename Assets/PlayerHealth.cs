using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject gameOverUI;

    void Start()
    {
        currentHealth = maxHealth;

        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 1;
        }
    }

    void Die()
    {
        currentHealth = 0;

        if (gameOverUI != null)
            gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}