using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResultResources", menuName = " Drag n Drop 2D/ResultResources", order = 0)]
public class ResultResources : ScriptableObject {
    public new string name;
    public string type;
    public string answer;
    public GameObject actionObject;
}