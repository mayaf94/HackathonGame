using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[DefaultExecutionOrder(-999)]
public class QuestionsManager : MonoBehaviour
{
    [HideInInspector] public Word currentWord;
    
    [SerializeField] private List<Word> wordsList;

    [SerializeField] private GameObject[] rows;

    private static QuestionsManager self;
    [HideInInspector] public Letter[][] letters2DArray;

    private void Awake()
    {
        if (self == null)
            self = this;
    }

    private void Start()
    {
        Get2DLettersArray();
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

    private void Get2DLettersArray()
    {
        letters2DArray = new Letter[rows.Length][];
        for (int i = 0; i < rows.Length; i++)
        {
            Letter[] lettersInRow = rows[i].GetComponentsInChildren<Letter>();
            for (int j = 0; j < lettersInRow.Length; j++)
            {
                letters2DArray[i][j] = lettersInRow[j];
            }
        }
    }

    public void ResetArray()
    {
        for (int i = 0; i < letters2DArray.Length; i++)
        {
            for (int j = 0; j < letters2DArray[i].Length; j++)
            {
                letters2DArray[i][j].gameObject.SetActive(false);
            }
        }
    }

    public void ActivateLettersInWords()
    {
        foreach (var word in wordsList)
        {
            word.ActivateWord();
        }
    }
}
