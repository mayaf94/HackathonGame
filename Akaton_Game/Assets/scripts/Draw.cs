using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public GameObject P1;
    public GameObject P2;
    public void Start()
    {
        window.text = Qu[Qnum];
    }
    public void Fake()
    {
        if(answers[Qnum] == false)
        {
            correct = true;
        }
        else
        {
            correct = false;
        }
        Show();
    }

    public void Fact()
    {
        if (answers[Qnum] == true)
        {
            correct = true;
        }
        else
        {
            correct = false;
        }
        Show();
    }

    public void Show()
    {
        if (i == 0 && !correct) return;
        if (i == 6 && correct)
        {
            P1.SetActive(true);
            P2.SetActive(true);
        }
        else
            if(correct)
        {
            images[i].SetActive(false);
            i++;
            images[i].SetActive(true);
        }
        else
        {
            images[i].SetActive(false); ;
            i--;
            images[i].SetActive(true); ;
        }
        Qnum++;
        if (Qnum < 8)
        {
            window.text = Qu[Qnum];
        }
        else
        {
            P1.SetActive(true);
            P2.SetActive(true);
        }
    }

}
