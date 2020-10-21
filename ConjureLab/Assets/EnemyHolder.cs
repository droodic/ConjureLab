using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolder : MonoBehaviour
{

    #region Singleton
    private static EnemyHolder _instance = null;
    public static EnemyHolder Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<EnemyHolder>();
            }
            return _instance;
        }
    }
    #endregion

    // Start is called before the first frame update
    [SerializeField] List<Observer> enemyList = new List<Observer>();

    public List<Observer> EnemyList { get => enemyList; set => enemyList = value; }

    // Update is called once per frame
}
