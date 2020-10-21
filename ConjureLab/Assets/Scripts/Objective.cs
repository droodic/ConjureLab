using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Objective", menuName = "ScriptableObjects/Objective", order = 1)]
public class Objective : ScriptableObject
{
    public string objectiveTag;
    public string objectiveText;
    public string completedObjectiveText;
    public int requiredGoalAmt;
    public bool objectiveCompleted;
    
    [SerializeField] int currentGoalAmt;
    public int CurrentGoalAmt { get => currentGoalAmt; set => currentGoalAmt = value; }

}
