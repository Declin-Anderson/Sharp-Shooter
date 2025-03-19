using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Handles the AI for the Robot enemies
/// </summary>
public class Robot : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
    }

    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
