using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{

    public Animation clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && GameManager.Instance.GetObjective("KeyPickup").objectiveCompleted)
        {
            clip.Play();
        }
    }
}
