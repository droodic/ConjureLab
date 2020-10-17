using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    GameManager gm;
    UIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        ui = FindObjectOfType<UIManager>().GetComponent<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !gm.HasKey)
        {
            gm.HasKey = true;
            ui.UpdateObjectiveText("Find the exit.");
            Destroy(this);
        }
    }
}
