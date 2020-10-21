using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.Instance.GiveObjectiveProgress(GameManager.Instance.GetObjective("VisitRooms"));
            Destroy(this.gameObject);
        }
    }
}
