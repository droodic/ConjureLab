using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{

    GameManager gm;
    public Animation clip;


    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gm.HasKey)
        {
            clip.Play();
        }
    }
}
