using UnityEngine;

public class FallingItems : MonoBehaviour
{
    public bool isGoodItem = true;
    public int ammoAmount = 1;
    public int damageAmount = 1;
    public int scoreAmount = 10;
    public float groundLifetime = 3f;

    private bool hasHitGround = false;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " hit " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager gm = FindObjectOfType<GameManager>();

            if (gm != null)
            {
                if (isGoodItem)
                {
                    gm.ammo += ammoAmount;
                    gm.score += scoreAmount;
                    Debug.Log("Good item collected. Ammo: " + gm.ammo + " Score: " + gm.score);
                }
                else
                {
                    gm.health -= damageAmount;
                    Debug.Log("Bad item hit player. Health: " + gm.health);
                }

                gm.UpdateUI();
            }
            else
            {
                Debug.LogError("GameManager not found!");
            }

            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.CompareTag("Ground") && !hasHitGround)
        {
            hasHitGround = true;
            Destroy(gameObject, groundLifetime);
        }
    }
}