using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


[DefaultExecutionOrder(-999)]

public class GameManager : MonoBehaviour
{
    [HideInInspector] public const string CROSSWORD_USER_SOLVED_LEVEL_TAG = "crosswordLevel";
    [HideInInspector] public const string TRUTH_LIE_USER_SOLVED_LEVEL_TAG = "TruthLieLevel";
    private const float MAX_SCORE = 100;
    private const int AMOUNT_OF_GAMES = 2;
    private const string SCORE_TAG = "score";
    private const float MINIGAME_MAX_SCORE = MAX_SCORE / AMOUNT_OF_GAMES;

    [SerializeField] private ProgressBar[] progressBars;
    [SerializeField] private TextMeshProUGUI progressCounter;
    private static GameManager self;
    private float score;


    private void Awake()
    {
        // // Ensure there is only one instance of the GameManager
        // if (self == null)
        // {
        //     self = this;
        //     DontDestroyOnLoad(gameObject);
        // }
        // else
        // {
        //     // If an instance already exists, destroy the duplicate
        //     Destroy(gameObject);
        // }
        if (self == null)
        {
            self = this;
        }
    }

    public static GameManager Shared()
    {
        return self;
    }

    private void Start()
    {
        CheckPlayerPrefs();
        UpdateProgress();
    }

    private void UpdateProgress()
    {
        foreach (var progressBar in progressBars)
        {
            progressBar.FillBar(GetFillPercentage());
        }
        if (progressCounter != null) // If a progress counter exists in the scene, it will update it.
            progressCounter.SetText((int)(GetFillPercentage() * 100) + "%");
    }

    private void CheckPlayerPrefs()
    {
        // PlayerPrefs.SetInt(TRUTH_LIE_USER_SOLVED_LEVEL_TAG, -1);    //TODO: remove - only for check
        // PlayerPrefs.SetInt(CROSSWORD_USER_SOLVED_LEVEL_TAG, -1); //TODO: remove - only for check
        // PlayerPrefs.SetInt(SCORE_TAG, 0); //TODO: remove - only for check
        
        if (!PlayerPrefs.HasKey(SCORE_TAG))
        {
            score = 0;
            PlayerPrefs.SetFloat(SCORE_TAG, 0);
        }
        
        if (!PlayerPrefs.HasKey(CROSSWORD_USER_SOLVED_LEVEL_TAG))
            PlayerPrefs.SetInt(CROSSWORD_USER_SOLVED_LEVEL_TAG, -1);
        if (!PlayerPrefs.HasKey(TRUTH_LIE_USER_SOLVED_LEVEL_TAG))
            PlayerPrefs.SetInt(TRUTH_LIE_USER_SOLVED_LEVEL_TAG, -1);
        score = PlayerPrefs.GetFloat(SCORE_TAG);
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
        score += increaseBy * MINIGAME_MAX_SCORE;
        PlayerPrefs.SetFloat(SCORE_TAG, score);
        UpdateProgress();
    }

    // public void ResetMinigame(string minigameTag)
    // {
    //     PlayerPrefs.SetInt(minigameTag, -1);
    // }
    
}
