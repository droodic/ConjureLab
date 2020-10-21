using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> keyList;


    void Start()
    {
        DeactivateKeys();
        SpawnRandomKey();
    }

    void DeactivateKeys()
    {
        foreach(var key in keyList)
        {
            key.SetActive(false);
        }
    }

    void SpawnRandomKey()
    {
        int rand = Random.Range(0, keyList.Count);
        keyList[rand].SetActive(true);
    }
}
