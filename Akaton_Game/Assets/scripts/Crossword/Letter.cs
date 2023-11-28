using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public bool isFilled = false;
    [SerializeField] private TextMeshProUGUI letterText;
    private char _letter;

    private Image background;
    
    
    private Color _defaultColor;

    private void Awake()
    {
        background = GetComponent<Image>();
        _defaultColor = background.color;
    }

    private void Start()
    {
        letterText = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public void ChangeLetterColor(Color newColor)
    {
        background.color = newColor;
    }

    public void SetLetter(char letter)
    {
        _letter = letter;
        letterText.SetText(letter.ToString());
    }

    public char GetLetter()
    {
        return _letter;
    }

    public void ResetLetter()
    {
        letterText.SetText('\0'.ToString());
        ChangeLetterColor(_defaultColor);
        isFilled = false;
    }

    public void SelectCellAnimationStart()
    {
        
        transform.DOScale(1.1f, 1).SetLoops(-1, LoopType.Yoyo);
        
    }

    public void SelectCellAnimationEnd()
    {
        transform.DOKill();
        transform.localScale = Vector3.one;
    }
}
