using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GargoyleBehavior : Observer
{

    public override void PlayerInSight()
    {
        foreach (Observer observer in holder.EnemyList)
        {
            if ((GhostBehavior)observer != null)
            {
                observer.GetComponent<GhostBehavior>().Investigate(player.transform);
            }
        }
    }

    // Start is called before the first frame update
    public override void Start()
    {
        holder = FindObjectOfType<EnemyHolder>().GetComponent<EnemyHolder>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
