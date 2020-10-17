using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] keyList;


    void Start()
    {
        int rand = Random.Range(0, keyList.Length);
        keyList[rand].SetActive(true);

    }
}
