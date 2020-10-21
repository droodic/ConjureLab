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

    [SerializeField] TextMeshProUGUI objectivePrefab;
    [SerializeField] List<TextMeshProUGUI> objectiveText = new List<TextMeshProUGUI>();
    [SerializeField] GameObject questPanel;

    private void Start()
    {
        InitObjectiveTexts();
    }

    public void InitObjectiveTexts()
    {
        for (int i = 0; i < GameManager.Instance.ObjectiveList.Length; i++)
        {
            objectiveText.Add(Instantiate<TextMeshProUGUI>(objectivePrefab, questPanel.transform));
            objectiveText[i].text = GameManager.Instance.ObjectiveList[i].objectiveText;
           
        }
    }

    public void UpdateObjectiveText(int index, string text)
    {
        objectiveText[index].text = text;
    }
}
