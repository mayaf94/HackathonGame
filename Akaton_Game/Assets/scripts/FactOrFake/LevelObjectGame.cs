using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(menuName = "FactOrFake/Level")]
public class LevelObjectGame : ScriptableObject
{
    [SerializeField] private string Q1;
    [SerializeField] private string Q2;
    [SerializeField] private string Q3;
    [SerializeField] private string Q4;
    [SerializeField] private string Q5;
    [SerializeField] private string Q6;
    [SerializeField] private string Q7;
    [SerializeField] private string Q8;

    [SerializeField] private bool A1;
    [SerializeField] private bool A2;
    [SerializeField] private bool A3;
    [SerializeField] private bool A4;
    [SerializeField] private bool A5;
    [SerializeField] private bool A6;
    [SerializeField] private bool A7;
    [SerializeField] private bool A8;

    [HideInInspector] public string[] quastions;
    [HideInInspector] public bool[] answers;

    public void BuildList()
    {
        quastions = new string[] { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8 };
        answers = new bool[] { A1, A2, A3, A4, A5, A6, A7, A8 };
    }
}
