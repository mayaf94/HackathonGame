using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Tween : MonoBehaviour
{
    [SerializeField] private float colorChangeDuration = 3f;
    [SerializeField] private float delayBeforeDisappear = 1.5f;
    
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
            _letterText.DOColor(Color.red, 1f).SetEase(Ease.OutQuint).OnComplete(() => OnLetterEffectEnd(letter));
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
}
