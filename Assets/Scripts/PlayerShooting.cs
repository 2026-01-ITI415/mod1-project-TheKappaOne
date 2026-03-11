using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileForce = 700f;

    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (gm == null)
        {
            Debug.LogWarning("GameManager not found.");
            return;
        }

        if (gm.ammo <= 0)
        {
            Debug.Log("No ammo!");
            return;
        }

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * projectileForce);
        }

        gm.ammo -= 1;
        Debug.Log("Shot fired! Ammo left: " + gm.ammo);
    }
}