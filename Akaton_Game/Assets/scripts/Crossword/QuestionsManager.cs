using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DefaultExecutionOrder(-999)]
public class QuestionsManager : MonoBehaviour
{
    [HideInInspector] public Word currentWord;
    
    [SerializeField] private List<Word> wordsList;

    [SerializeField] private GameObject[] rows;

    private static QuestionsManager self;

    private void Awake()
    {
        if (self == null)
            self = this;
    }

    public static QuestionsManager Shared()
    {
        return self;
    }


    public void InsertLCharacter(char character)
    {
        if(currentWord == null)
            return;
        currentWord.FillAndStep(character);
    }

    public List<Letter> GridToLetters(ArrayLayout grid)
    {
        return null;
    }

    public bool CheckWin()
    {
        foreach (Word word in wordsList)
        {
            if (!word.IsWordFilled())
                return false;
        }
        return true;
    }
}
