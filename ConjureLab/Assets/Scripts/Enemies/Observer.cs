using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    public bool inSight;

    protected NavMeshAgent nav;
    protected EnemyHolder holder;

    bool m_IsPlayerInRange;

    public virtual void Start()
    {
        nav = GetComponentInParent<NavMeshAgent>();

        //Add observer to enemy list
        holder = EnemyHolder.Instance;
        holder.EnemyList.Add(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    public virtual void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player && !inSight)
                {
                    PlayerInSight();
                    inSight = true; //Only once flag
                }
            }
        }
    }

    public abstract void PlayerInSight();
}
