using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MixedButtonsAnswers : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Image btnImage;
    private RectTransform rectTransform;
    
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        btnImage = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void LoadText(string textToLoad)
    {
        text.text = textToLoad;
        rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, text.preferredHeight + 10);
    }

    public void ClickOnAnswer(int i)
    {
        MixedManager.Shared().AnswerQuestion(i);
    }

    public void ColorAnimation(Color color)
    {
        btnImage.DOColor(color, 0.5f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            MixedManager.Shared().inAction = false;
            
        });
    }
}
