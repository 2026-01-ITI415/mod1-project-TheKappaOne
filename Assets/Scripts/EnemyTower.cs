using UnityEngine;

public class EnemyTower : MonoBehaviour
{
    public int health = 3;
    public int scoreValue = 50;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            health--;
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                GameManager gm = FindObjectOfType<GameManager>();

                if (gm != null)
                {
                    gm.score += scoreValue;
                    gm.UpdateUI();
                }

                Destroy(gameObject);
            }
        }
    }
}