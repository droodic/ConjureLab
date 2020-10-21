using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    GameManager gm;
    UIManager ui;

    private void Awake()
    {
        GetComponentInParent<KeySpawner>().keyList.Add(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        ui = UIManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !gm.GetObjective("KeyPickup").objectiveCompleted)
        {
            gm.CompleteObjective(gm.GetObjective("KeyPickup"));
        
            Destroy(this.gameObject);
        }
    }
}
