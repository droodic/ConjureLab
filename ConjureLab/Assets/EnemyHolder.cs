using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Observer> enemyList = new List<Observer>();

    public List<Observer> EnemyList { get => enemyList; set => enemyList = value; }

    // Update is called once per frame
}
