using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;

    public GameObject Player;

    public float distanceRun = 4.0f;

    public float detectionRadius = 1.0f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Checks where the player is relative to the AI, and if it is within a certain distance, move to the player
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance < distanceRun)
        {
            Vector3 toPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position - toPlayer;

            // Updated destination
            agent.SetDestination(newPos);
        }
    }

    // Creates a visible wireframe sphere to represent the detection radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }   
}
