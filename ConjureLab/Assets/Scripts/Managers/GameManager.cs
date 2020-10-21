using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
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
    public Objective[] ObjectiveList { get => objectiveList;}

    [SerializeField] Objective[] objectiveList;

    private void Start()
    {
        ResetScriptableObjects();
    }

    private void ResetScriptableObjects()
    {
        foreach (var objective in ObjectiveList)
        {
            objective.CurrentGoalAmt = 0;
            objective.objectiveCompleted = false;
        }
    }

    public Objective GetObjective(string objectiveTag)
    {
        foreach(var objective in ObjectiveList)
        {
            if(objective.objectiveTag == objectiveTag)
            {
                return objective;
            }
        }

        return null;
    }

    public int GetObjectiveIndex(Objective objective)
    {
        for (int i = 0; i < ObjectiveList.Length; i++)
        {
            if(ObjectiveList[i].objectiveTag == objective.objectiveTag)
            {
                return i;
            }
        }

        return -1;
    }

    public void GiveObjectiveProgress(Objective objective)
    {

        if(objective.CurrentGoalAmt < objective.requiredGoalAmt)
        {
            objective.CurrentGoalAmt++;
            string newText = objective.objectiveText + " , [" + objective.CurrentGoalAmt + "/ " + objective.requiredGoalAmt + "]";
            UIManager.Instance.UpdateObjectiveText(GetObjectiveIndex(objective), newText);
        }
        if(objective.CurrentGoalAmt >= objective.requiredGoalAmt)
        {
            CompleteObjective(objective);
        }
    }

    public void CompleteObjective(Objective objective)
    {
        UIManager.Instance.UpdateObjectiveText(GetObjectiveIndex(objective), objective.completedObjectiveText);
        objective.objectiveCompleted = true;
    }

}

