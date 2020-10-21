using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance = null;
    private int currentTurn;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
            }
            return _instance;
        }
    }
    #endregion

    [SerializeField] TextMeshProUGUI[] objectiveText;
    [SerializeField] GameObject questPanel;

    private void Start()
    {

    }


    public void UpdateObjectiveText(int index, string text)
    {
        objectiveText[index].text = text;
    }
}
