using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Draw : MonoBehaviour
{
    public GameObject[] images;
    public bool[] answers;
    private bool correct;
    private int i = 0;
    private int Qnum = 0;
    public TextMeshProUGUI window;
    public string[] Qu = { "The Oslo Accords were a series of agreements between Israel and the Palestine Liberation Organization (PLO) that were signed in the 1990s.",
    "In 1948, the Arab states invaded Israel in an attempt to prevent its establishment. Israel defeated the Arab armies and expanded its territory beyond the borders of the UN partition plan.",
    "The Jewish people had never lived in the land of Israel before the founding of the state.",
    "In 1947, the United Nations voted to partition Palestine into two states, one Arab and one Jewish. The Arab leadership rejected the partition plan and called for a united Arab state in Palestine.",
    "The French Mandate for Palestine was a period of French rule over Palestine from 1922 to 1948.",
    "The First and Second Intifadas were a series of violent attacks by Palestinian terrorists on Israeli civilians, including Bombing public transport and shooting Israeli babies.",
    "In 1947, the United Nations voted to partition Palestine into two states, one Arab and one Jewish. The Jewish leadership rejected the partition  and called for an all Jewish state.",
    "While negotiating Oslo agreements, Israel has refused to withdraw or give up any of its territories."};

    public Transform flag;
    public CanvasGroup background;
    public GameObject EndGameGroup;
    public Animator animatorFake;
    public Animator animatorFact;
    private bool fake = false;
    private bool fact = false;

    public void Start()
    {
        window.text = Qu[Qnum];
        for (int j = 0; j < 7; j++)
        {
            images[j].transform.localScale = Vector2.zero;
        }
    }


    public void Update()
    {

        if (fake)
        {
            animatorFake.SetTrigger("Release");
            fake = false;
        }
        if (fact)
        {
            animatorFact.SetTrigger("Release");
            fact = false;
        }

    }
    public void Fake()
    {
        animatorFake.SetTrigger("Press");
        if (answers[Qnum] == false)
        {
            correct = true;
        }
        else
        {
            correct = false;
        }
        fake = true;
        Show();

    }

    public void Fact()
    {

        animatorFact.SetTrigger("Press");
        if (answers[Qnum] == true)
        {
            correct = true;
        }
        else
        {
            correct = false;
        }
        fact = true;
        Show();

    }

    public void Show()
    {
        //if (i == 0 && !correct) return;
        if (i == 6)
        {
            EndGameGroup.SetActive(true);
            EndGame();
        }
        else
            if (correct)
        {
            //images[i].transform.LeanScale(Vector2.zero, 0.1f);
            i++;
            images[i].LeanScale(Vector2.one, 0.1f);
        }
        else
        {
            if (i != 0)
            {
                images[i].transform.LeanScale(Vector2.zero, 0.1f);
                i--;
                //images[i].LeanScale(Vector2.one, 0.8f);
            }
        }

        Qnum++;
        if (Qnum < 8)
        {
            window.text = Qu[Qnum];
        }
        else
        {
            EndGameGroup.SetActive(true);
            EndGame();
        }
    }

    public void EndGame()
    {
        background.alpha = 0;
        background.LeanAlpha(1, 0.5f);

        flag.localPosition = new Vector2(0, Screen.height);
        flag.LeanMoveLocalY(600, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void CloseDialog()
    {
        background.LeanAlpha(0, 0.5f);
        flag.LeanMoveLocalY(Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnClose);
        ResetGame();
    }

    void OnClose()
    {
        EndGameGroup.SetActive(false);
    }

    public void ResetGame()
    {
        i = 0;
        Qnum = 0;
        window.text = Qu[Qnum];
        for (int j = 0; j < 7; j++)
        {
            images[j].transform.localScale = Vector2.zero;
        }
    }

}
