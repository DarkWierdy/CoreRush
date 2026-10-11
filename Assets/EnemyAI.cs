using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    public int damage = 10;
    public float attackRange = 2f;
    public float attackCooldown = 1f;

    private float lastAttackTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Player not found. Make sure your Player object is tagged 'Player'.");
        }
    }

    void Update()
{
    if (agent == null || player == null) return;

    agent.SetDestination(player.position);

    float distance = Vector3.Distance(transform.position, player.position);

    if (distance <= attackRange && Time.time > lastAttackTime + attackCooldown)
    {
        AttackPlayer();
        lastAttackTime = Time.time;
    }
}
    void AttackPlayer()
{
    PlayerHealth health = player.GetComponent<PlayerHealth>();

    if (health != null)
    {
        health.TakeDamage(damage);
    }
}
}