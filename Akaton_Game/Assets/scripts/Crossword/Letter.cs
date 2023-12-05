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

    private Color _currentWantedColor;
    
    private Color _defaultColor;
    private Color _defaultTextColor;

    private void Awake()
    {
        background = GetComponent<Image>();
        _defaultColor = background.color;
    }

    private void Start()
    {
        letterText = GetComponentInChildren<TextMeshProUGUI>();
        _defaultTextColor = letterText.color;
        _currentWantedColor = _defaultColor;
    }
    
    public void ChangeLetterColor(Color newColor)
    {
        background.color = newColor;
        _currentWantedColor = newColor;
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
        
        transform.DOScale(1.2f, 0.6f).SetLoops(-1, LoopType.Yoyo);
        transform.SetAsLastSibling();
        transform.parent.SetAsLastSibling();
        ChangeLetterColor(Color.yellow);
        _currentWantedColor = Color.yellow;
        
    }

    public void SelectCellAnimationEnd()
    {
        transform.DOKill();
        ChangeLetterColor(_defaultColor);
        _currentWantedColor = _defaultColor;
        transform.localScale = Vector3.one;
    }

    public Color GetDefaultLetterColor()
    {
        return _defaultColor;
    }

    public Color GetWantedColor()
    {
        return _currentWantedColor;
    }

    public TextMeshProUGUI GetTextComponent()
    {
        return letterText;
    }

    public Color GetDefaultTextColor()
    {
        return _defaultTextColor;
    }

    public void SetTextColor(Color newColor)
    {
        letterText.color = newColor;
    }

    public Image GetBackgroundImage()
    {
        return background;
    }
}
