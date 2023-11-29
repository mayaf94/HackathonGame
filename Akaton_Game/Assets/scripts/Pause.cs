using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Pause : MonoBehaviour
{
    [SerializeField] GameObject PauseBT;
    [SerializeField] GameObject RYSButtons;
    [SerializeField] CanvasGroup Background;
    [SerializeField] GameObject background;
    [SerializeField] GameObject QHeader;
    [SerializeField] TextMeshProUGUI Header;
    void Start()
    {
        transform.localScale = Vector2.zero;
    }

    public void Open()
    {
        PauseBT.SetActive(true);
        RYSButtons.SetActive(false);
        background.SetActive(true);
        Background.alpha = 0;
        Background.LeanAlpha(1, 0.5f);
        transform.LeanScale(Vector2.one, 0.5f);
        Header.text = "Game Paused";
    }

    public void Reset()
    {
        PauseBT.SetActive(false);
        RYSButtons.SetActive(true);
        QHeader.SetActive(true);
        Header.text = "Are You Sure?";
    }

    public void Close()
    {
        transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
        Background.LeanAlpha(0, 0.5f);
        background.SetActive(false);
        QHeader.SetActive(false);
    }
}
