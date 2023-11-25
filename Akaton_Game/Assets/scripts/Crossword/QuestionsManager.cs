using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsManager : MonoBehaviour
{
    public Word currentWord;
    
    [SerializeField] private List<Word> wordsList;

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
        print("Check1");
        if(currentWord == null)
            return;
        currentWord.FillAndStep(character);
        print("Check2");
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
