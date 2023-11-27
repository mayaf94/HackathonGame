using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAnimation : MonoBehaviour
{
    public Transform flag;
    public CanvasGroup background;
    public GameObject EndGameGroup;
    
    public void StartFlagAnimation()
    {
        EndGameGroup.SetActive(true);
        background.alpha = 0;
        background.LeanAlpha(1, 0.5f);

        flag.localPosition = new Vector2(0, Screen.height);
        flag.LeanMoveLocalY(600, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void CloseDialog()
    {
        background.LeanAlpha(0, 0.5f);
        flag.LeanMoveLocalY(Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnClose);
    }

    void OnClose()
    {
        EndGameGroup.SetActive(false);
    }
}
