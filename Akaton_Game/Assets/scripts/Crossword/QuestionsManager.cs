using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


[DefaultExecutionOrder(-900)]
public class QuestionsManager : MonoBehaviour
{
    [HideInInspector] public Word currentWord;

    [HideInInspector] public bool isActionActive;
    
    [SerializeField] private List<Word> wordsList;

    [SerializeField] private GameObject[] rows;

    [SerializeField] private LevelObject[] levelsToLoad;

    private static QuestionsManager self;
    [HideInInspector] public Letter[][] letters2DArray;
    
    [Header("Endgame")]
    public Transform flag;
    public CanvasGroup background;
    public GameObject endGameGroup;

    private int levelIndex;

    private void Awake()
    {
        if (self == null)
            self = this;
    }

    private void Start()
    {
        levelIndex = 0;
        Get2DLettersArray();
        ResetArray();
        LoadLevel(levelsToLoad[0]);
        ActivateLettersInWords();
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
        List<Letter> output = new List<Letter>();
        for (int i = 0; i < grid.rows.Length; i++)
        {
            for (int j = 0; j < grid.rows[i].row.Length; j++)
            {
                if(grid.rows[i].row[j])
                    output.Add(letters2DArray[i][j]);
            }
        }
        return output;
    }

    public void CheckWin()
    {
        foreach (Word word in wordsList)
        {
            if (!word.IsWordFilled())
                return;
        }
        GameManager.Shared().IncreaseScore(levelIndex, levelsToLoad.Length,
                                            GameManager.CROSSWORD_USER_SOLVED_LEVEL_TAG);
        levelIndex++;
        StartCoroutine(Winning());
    }

    private IEnumerator Winning()
    {
        yield return new WaitForSeconds(4);
        if (levelIndex < levelsToLoad.Length)
        {
            ResetArray();
            LoadLevel(levelsToLoad[levelIndex]);
            ActivateLettersInWords();
        }
        else
        {
            endGameGroup.SetActive(true);
            EndGame();
        }
    }
    
    private void EndGame()
    {
        background.alpha = 0;
        background.LeanAlpha(1, 0.5f);
        float beforePos = flag.localPosition.y;
        flag.localPosition = new Vector2(0, Screen.height);
        print(flag.GetComponent<RectTransform>().rect.height);
        flag.LeanMoveLocalY(beforePos, 0.5f).setEaseOutExpo().delay = 0.1f;
        
    }
    
    private void Get2DLettersArray()
    {
        letters2DArray = new Letter[rows.Length][];
    
        for (int i = 0; i < rows.Length; i++)
        {
            Letter[] lettersInRow = rows[i].GetComponentsInChildren<Letter>();
        
            // Initialize the inner array
            letters2DArray[i] = new Letter[lettersInRow.Length];

            for (int j = 0; j < lettersInRow.Length; j++)
            {
                letters2DArray[i][j] = lettersInRow[j];
            }
        }
    }


    public void ResetArray()
    {
        DOTween.KillAll();
        for (int i = 0; i < letters2DArray.Length; i++)
        {
            for (int j = 0; j < letters2DArray[i].Length; j++)
            {
                letters2DArray[i][j].ResetLetter();
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

    private void LoadLevel(LevelObject level)
    {
        level.BuildList();
        for (int i = 0; i < 6; i++)
        {
            wordsList[i].ResetAllValues(level.wordList[i]);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("LeeyamCrossword");
    }
    
}
