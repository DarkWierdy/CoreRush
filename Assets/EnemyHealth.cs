using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

 void Die()
{
    if (ScoreManager.instance != null)
    {
        ScoreManager.instance.AddScore(10);
    }

    Destroy(gameObject);
}
}