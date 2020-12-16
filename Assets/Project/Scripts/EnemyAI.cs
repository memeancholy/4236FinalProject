using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;

    public GameObject Player;

    public float distanceRun = 4.0f;

    public float detectionRadius = 4.0f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance < distanceRun)
        {
            Vector3 toPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position - toPlayer;

            agent.SetDestination(newPos);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }   
}
