using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsManager : MonoBehaviour
{
    [SerializeField] private List<Word> wordsList;

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
