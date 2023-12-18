using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MixedManager : MonoBehaviour
{
    [SerializeField] private QuestionsDB db;

    [Header("objectsFromScene"), SerializeField]
    private TextMeshProUGUI questionOnly;
    [SerializeField] private TextMeshProUGUI questionWithImage;
    [SerializeField] private Image questionImage;

    [SerializeField] private MixedButtonsAnswers[] buttons;

    [Header("End Game"), SerializeField] 
    private GameObject endgameGroup;
    [SerializeField] private CanvasGroup background;
    [SerializeField] private Transform flag;


    [HideInInspector] public bool inAction;
    
    
    private static MixedManager self;
    private int indexOfQuestion;
    
    private void Awake()
    {
        if (self == null)
            self = this;
    }

    private void Start()
    {
        indexOfQuestion = 0;
        questionImage.preserveAspect = true;
        inAction = false;
        LoadQuestion();
    }

    public static MixedManager Shared()
    {
        return self;
    }

    private void LoadQuestion()
    {
        MixedQuestion cur = db.questions[indexOfQuestion];
        if (cur.haveImage)
        {
            questionOnly.gameObject.SetActive(false);
            questionImage.gameObject.SetActive(true);
            questionWithImage.gameObject.SetActive(true);
            questionImage.sprite = cur.image;
            questionWithImage.text = cur.question;
        }
        else
        {
            questionOnly.gameObject.SetActive(true);
            questionImage.gameObject.SetActive(false);
            questionWithImage.gameObject.SetActive(false);
            questionOnly.text = cur.question;
        }
        buttons[0].LoadText(cur.answer1);
        buttons[1].LoadText(cur.answer2);
        buttons[2].LoadText(cur.answer3);
        buttons[3].LoadText(cur.answer4);
    }

    public void AnswerQuestion(int i)
    {
        if(inAction)
            return;
        inAction = true;
        buttons[db.questions[indexOfQuestion].GetCorrectIndex()].ColorAnimation(Color.green);
        if (!db.questions[indexOfQuestion].IsAnswerRight(i))
        {
            buttons[i-1].ColorAnimation(Color.red);
        }
        StartCoroutine(NextLevelAfterAnimation());
    }

    private IEnumerator NextLevelAfterAnimation()
    {
        yield return new WaitWhile(() => inAction);
        indexOfQuestion++;
        if (indexOfQuestion >= db.questions.Count)
        {
            EndGame();
            yield break;
        }
        LoadQuestion();
    }
    
    private void EndGame()
    {
        endgameGroup.SetActive(true);
        background.alpha = 0;
        background.LeanAlpha(1, 0.5f);
        float beforePos = flag.localPosition.y;
        flag.localPosition = new Vector2(0, Screen.height);
        flag.LeanMoveLocalY(beforePos, 0.5f).setEaseOutExpo().delay = 0.1f;
    }
}
