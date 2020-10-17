using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPatrol : MonoBehaviour
{
    public GhostBehavior observer;
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    //public bool chasing = false;

    int m_CurrentWaypointIndex;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        if (!observer.chasing && !observer.investigating && navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
    public void ResumePatrol()
    {
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }
}
