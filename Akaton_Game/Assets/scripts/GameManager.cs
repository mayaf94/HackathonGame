using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[DefaultExecutionOrder(-999)]

public class GameManager : MonoBehaviour
{

    private static GameManager self;
    private int score;

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
        if (!PlayerPrefs.HasKey("Score"))
        {
            score = 0;
            PlayerPrefs.SetInt("Score", 0);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
