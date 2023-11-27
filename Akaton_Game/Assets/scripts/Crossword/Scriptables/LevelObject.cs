using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrossWord/Level")]
public class LevelObject : ScriptableObject
{
    [SerializeField] private WordObject word1;
    [SerializeField] private WordObject word2;
    [SerializeField] private WordObject word3;
    [SerializeField] private WordObject word4;
    [SerializeField] private WordObject word5;
    [SerializeField] private WordObject word6;

    [HideInInspector] public WordObject[] wordList;

    public void BuildList()
    {
        wordList = new WordObject[] { word1, word2, word3, word4, word5, word6};
    }
}
