using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[DefaultExecutionOrder(-999)]

public class GameManager : MonoBehaviour
{
    [SerializeField] private ProgressBar progressBar;
    
    private static GameManager self;
    private float score;
    private float minigameMaxScore;

    [HideInInspector] public const string CROSSWORD_USER_SOLVED_LEVEL_TAG = "crosswordLevel";
    [HideInInspector] public const string TRUTH_LIE_USER_SOLVED_LEVEL_TAG = "TruthLieLevel";
    private const float MAX_SCORE = 100;
    private const int AMOUNT_OF_GAMES = 2;
    private const string SCORE_TAG = "score";


    private void Awake()
    {
        if (self == null)
            self = this;
    }

    public static GameManager Shared()
    {
        return self;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        minigameMaxScore = MAX_SCORE / AMOUNT_OF_GAMES;
        CheckPlayerPrefs();
        if (progressBar != null) //TODO: when opening a minigame - use the function
        {
            progressBar.FillBar(GetFillPercentage());
        }
    }

    private void CheckPlayerPrefs()
    {
        PlayerPrefs.SetInt(CROSSWORD_USER_SOLVED_LEVEL_TAG, -1); //TODO: remove - only for check
        PlayerPrefs.SetInt(SCORE_TAG, 0); //TODO: remove - only for check
        
        if (!PlayerPrefs.HasKey(SCORE_TAG))
        {
            score = 0;
            PlayerPrefs.SetInt(SCORE_TAG, 0);
        }
        
        if (!PlayerPrefs.HasKey(CROSSWORD_USER_SOLVED_LEVEL_TAG))
            PlayerPrefs.SetInt(CROSSWORD_USER_SOLVED_LEVEL_TAG, -1);
        if (!PlayerPrefs.HasKey(TRUTH_LIE_USER_SOLVED_LEVEL_TAG))
            PlayerPrefs.SetInt(TRUTH_LIE_USER_SOLVED_LEVEL_TAG, -1);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenMainScene()
    {
        SceneManager.LoadScene("MainScreen");
    }

    private float GetFillPercentage()
    {
        return score/MAX_SCORE;
    }

    public void IncreaseScore(int levelIndex, int minigameLevels, string minigameTag)
    {
        int currSolvedLevel = PlayerPrefs.GetInt(minigameTag);
        if (levelIndex == minigameLevels || levelIndex <= currSolvedLevel)
        {
            return;
        }
        
        PlayerPrefs.SetInt(minigameTag, levelIndex);
        float increaseBy = (float) 1/minigameLevels;
        score += increaseBy * minigameMaxScore;
        PlayerPrefs.SetFloat(SCORE_TAG, score);
        progressBar.FillBar(GetFillPercentage());
        print("score: " + score);
        print("GetFillPercentage: " + GetFillPercentage());
    }

    // public void ResetMinigame(string minigameTag)
    // {
    //     PlayerPrefs.SetInt(minigameTag, -1);
    // }
    
}
