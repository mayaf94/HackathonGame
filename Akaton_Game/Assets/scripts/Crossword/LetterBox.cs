using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class LetterBox : MonoBehaviour
{
    public bool isFilled = false;

    [SerializeField] private TextMeshProUGUI letterText;
    // [SerializeField]
    // private bool show = true;

    private void Start()
    {
        // if (!show)
        //     gameObject.SetActive(false);
        
        letterText = GetComponent<TextMeshProUGUI>();
    }
    
    public void ChangeLetterColor(Color newColor)
    {
        letterText.color = newColor;
    }
}
