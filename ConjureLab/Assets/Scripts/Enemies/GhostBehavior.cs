using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : Observer
{
    [SerializeField] WaypointPatrol patrol;
    [SerializeField] float minDistance;
    [SerializeField] float maxDistance;
    public EnemyHolder holder;

    public bool chasing;
    public bool investigating;
    Vector3 investigationPosition;


    public override void Start()
    {
        base.Start();
        holder = FindObjectOfType<EnemyHolder>().GetComponent<EnemyHolder>();
        holder.EnemyList.Add(this);
    }

    public void Investigate(Transform target)
    {
        investigationPosition = target.position;
        nav.SetDestination(target.position);
        investigating = true;
    }

    public override void PlayerInSight()
    {
        if (investigating)
        {
            investigating = false;
        }

        chasing = true;
    }

    public override void Update()
    {
        base.Update();
        if (chasing)
        {
            transform.LookAt(player);
            nav.SetDestination(player.position);

            if (nav.remainingDistance >= maxDistance)
            {
                Debug.Log("Resuming patrol!");
                Reset();
            }
            else if(nav.remainingDistance <= minDistance)
            {
                gameEnding.CaughtPlayer();
            }
        }
        else if (investigating)
        {
            if (Vector3.Distance(this.transform.position, investigationPosition) <= 1f)
            {
                Debug.Log("Resuming patrol! - Investigation failed");
                Reset();
            }
        }
    }


    private void Reset()
    {
        //Should use some state design pattern instead
        chasing = false;
        investigating = false;
        inSight = false;
        patrol.ResumePatrol();
    }
}
