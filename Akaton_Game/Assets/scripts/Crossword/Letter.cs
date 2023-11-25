using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Letter : MonoBehaviour
{
    public bool isFilled = false;
    [SerializeField] private TextMeshProUGUI letterText;
    private char _letter;

    private void Start()
    {
        letterText = GetComponent<TextMeshProUGUI>();
    }
    
    public void ChangeLetterColor(Color newColor) //TODO: might want to also change the color of the gameobject itself
    {
        letterText.color = newColor;
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
}
