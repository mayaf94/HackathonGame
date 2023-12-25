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

    public void ColorAnimation(Color color, bool isWrong)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(btnImage.DOColor(color, MixedManager.Shared().durationForAnimation));
        if(isWrong)
            sequence.AppendInterval(MixedManager.Shared().GetExplanationTime());
        sequence.Append(btnImage.DOColor(Color.white, MixedManager.Shared().durationForAnimation));
        sequence.AppendCallback(() => { MixedManager.Shared().inAction = false; });
    }
}
