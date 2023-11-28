using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tween : MonoBehaviour
{
    [Header("Color change on fail")]
    [SerializeField] private float colorChangeDuration = 1f;

    [Header("Shine")]
    [SerializeField] private float shineDuration = 1.0f;
    [SerializeField] private Color shineColor = Color.green;

    [Header("Word success jump")]
    
    
    private static Tween self;
    private TextMeshProUGUI _letterText;

    private void Awake()
    {
        if (self == null)
            self = this;
    }
    
    public static Tween Shared()
    {
        return self;
    }

    public void WrongLetterEffect(Letter letter)
    {

        _letterText = letter.GetTextComponent();

        if (_letterText != null)
        {
            _letterText.DOColor(Color.red, colorChangeDuration).SetEase(Ease.OutQuint).OnComplete(() => OnLetterEffectEnd(letter));
        }
        else
        {
            Debug.LogWarning("Text component is null.");
        }
    }

    private void OnLetterEffectEnd(Letter letter)
    {
        letter.SetLetter('\0');
        letter.SetTextColor(letter.GetDefaultTextColor());
    }
    
    public void OnWordSuccess(Word word)
    {
        float inDelay = 0f;
        float outDelay = 0.8f + word.GetLength() * 0.1f;
        float scaling = 0.25f;
        int i = 1;
        
        foreach (Letter letter in word.letters)
        {
            Transform letterTransform = letter.transform;
            Image background = letter.GetBackgroundImage();
            float xOriginalVal = letterTransform.localScale.x;
            float yOriginalVal = letterTransform.localScale.y;
            float zOriginalVal = letterTransform.localScale.z;
            float scale = 1 + scaling * i;
            
            letterTransform.DOScale(
                new Vector3(xOriginalVal * scale, yOriginalVal * scale,
                    zOriginalVal), shineDuration).SetEase(Ease.OutBack).SetDelay(inDelay);
            
            MakeLetterShine(background, inDelay, outDelay);

            letterTransform.DOScale(
                new Vector3(xOriginalVal, yOriginalVal,
                    zOriginalVal), shineDuration).SetEase(Ease.InBack).SetDelay(outDelay);
            inDelay += 0.2f;
            outDelay -= 0.1f;
            i++;
        }

    }

    private void MakeLetterShine(Image background, float inDelay, float outDelay)
    {
        Color originalColor = background.color;
        background.DOColor(shineColor, shineDuration).SetEase(Ease.OutBack).SetDelay(inDelay);
        background.DOColor(originalColor, shineDuration).SetEase(Ease.InBack).SetDelay(outDelay);
    }
}
