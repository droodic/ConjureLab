using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    #region Singleton
    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    #endregion

    [SerializeField] bool[] completed;

    [SerializeField] bool hasKey;

    public bool HasKey { get => hasKey; set => hasKey = value; }

    private void Start()
    {
        
    }

}

