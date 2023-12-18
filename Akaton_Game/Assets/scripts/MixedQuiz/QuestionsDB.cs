using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MixedQuiz/QuestionsDB")]
public class QuestionsDB : ScriptableObject
{
    public List<MixedQuestion> questions;
}

[Serializable]
public class MixedQuestion
{
    [TextArea(1, 6)] public string question;
    public bool haveImage;
    public Sprite image;
    [TextArea(1, 2)]public string answer1;
    [TextArea(1, 2)]public string answer2;
    [TextArea(1, 2)]public string answer3;
    [TextArea(1, 2)]public string answer4;
    [SerializeField] private int correctAnswer;

    public bool IsAnswerRight(int ans)
    {
        return ans == correctAnswer;
    }

    public int GetCorrectIndex()
    {
        return correctAnswer - 1;
    }
}