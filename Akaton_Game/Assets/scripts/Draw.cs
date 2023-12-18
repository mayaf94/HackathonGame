using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Draw : MonoBehaviour
{
    public GameObject[] images;
    private bool correct;
    private int i = 0;
    public int Qnum = 0;
    public TextMeshProUGUI window;
   
    [SerializeField] private LevelObjectGame[] levelsToLoad;
    public Transform flag;
    public CanvasGroup background;
    public GameObject EndGameGroup;
    //public Animator animatorFake;
   // public Animator animatorFact;
    [SerializeField] TMP_Text Header;
    [SerializeField] GameObject EndGameButtons;
    [SerializeField] private int Level = 0;
    //[SerializeField] GameObject PauseGameButtons;


    public void Start()
    {
        levelsToLoad[Level].BuildList();
        for (int j = 0; j < 7; j++)
        {
            images[j].transform.localScale = Vector2.zero;
        }
        window.text = levelsToLoad[Level].quastions[Qnum];

    }


    public void Update()
    {

        //if (fake)
        //{
        //    animatorFake.SetTrigger("Release");
        //    fake = false;
        //}
        //if (fact)
        //{
        //    animatorFact.SetTrigger("Release");
        //    fact = false;
        //}

    }
    public void Fake()
    {
        //animatorFake.SetTrigger("Press");
        if (levelsToLoad[Level].answers[Qnum] == false)
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

        //animatorFact.SetTrigger("Press");
        if (levelsToLoad[Level].answers[Qnum] == true)
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
        //if (i == 0 && !correct) return;
        if (i == 6)
        {
            EndGameGroup.SetActive(true);
            GameManager.Shared().UpdateProgress();
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
            window.text = levelsToLoad[Level].quastions[Qnum];
        }
        if(Qnum >= 8 || i == 6)
        {
            EndGameGroup.SetActive(true);
            GameManager.Shared().UpdateProgress();
            Header.text = "Good Job!";
            //EndGameButtons.SetActive(true);
            //PauseGameButtons.SetActive(false);
            EndGame();
        }
    }

    public void EndGame()
    {
        background.alpha = 0;
        background.LeanAlpha(1, 0.5f);

        flag.localPosition = new Vector2(0, Screen.height);
        flag.LeanMoveLocalY(600, 0.5f).setEaseOutExpo().delay = 0.1f;

        if (Level < levelsToLoad.Length - 1)
        {
            GameManager.Shared().IncreaseScore(Level, levelsToLoad.Length, 
                GameManager.TRUTH_LIE_USER_SOLVED_LEVEL_TAG);
            Level++;
        }
        else
        {
            Level = 0;
        }
        levelsToLoad[Level].BuildList();
    }

    public void CloseDialog()
    {
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
        window.text = levelsToLoad[Level].quastions[Qnum];
        for (int j = 0; j < 7; j++)
        {
            images[j].transform.localScale = Vector2.zero;
        }
        background.LeanAlpha(0, 0.5f);
        flag.LeanMoveLocalY(Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnClose);
    }

    //public void Pause()
    //{
    //    EndGameGroup.SetActive(true);
    //    //EndGameButtons.SetActive(false);
    //    //PauseGameButtons.SetActive(true);
    //    Header.text = "Pause";
    //    EndGame();
    //}

}
