using UnityEngine;
using System.Collection;
using System.Collection.Generic;

public class WordScript : MonoBehaviour
{
    public String wordToGuess;
    public TextMeshProUGUI[] wordButtonsTexts;
    public gameObject[] wordButtons;
    public Color rightColor;
    public Color wrongColor;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void checkWord()
    {
        bool isOk = true;
        for (int i = 0; i < wordToGuess.length; i++)
        {
            if (!wordButtonsTexts[i].text.length) return;
            if (wordButtonsTexts[i].text != wordToGuess[i]) isOk = false;
        }
        if (isOk)
        {
            ColorButtons(rightColor, true);
        }
        ColorButtons(wrongColor, false);
    }

    public void ColorButtons(Color color,bool disableButton)
    {
        for (int i = 0; i < wordToGuess.length; i++)
        {
            if (wordButtons[i].getComponent<Image>.color == rightColor) continue;
            wordButtons[i].getComponent<Image>.color = color;
            wordButtons[i].setActive(disableButton);
        }
    }
}
