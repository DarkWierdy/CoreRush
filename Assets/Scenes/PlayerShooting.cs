using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float range = 100f;
    public GameObject hitEffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            // Spawn hit effect
            Instantiate(hitEffect, hit.point, Quaternion.identity);

            // Damage enemy
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
        }
    }
}