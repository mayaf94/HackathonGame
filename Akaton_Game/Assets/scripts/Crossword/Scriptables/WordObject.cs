using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrossWord/Word")]
public class WordObject : ScriptableObject
{
    public string questionContent;
    public string answer;
    public ArrayLayout locationOnBoard;
}
