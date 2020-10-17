using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GargoyleBehavior : Observer
{
    EnemyHolder holder;
 
    public override void PlayerInSight()
    {
        foreach(var ghost in holder.EnemyList)
        {
            ghost.GetComponent<GhostBehavior>().Investigate(player.transform);
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
